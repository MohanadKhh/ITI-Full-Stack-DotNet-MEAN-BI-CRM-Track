using Grpc.Net.Client;
using Grpc.Core;
using ITI.InventoryService.Server.Protos;
using ITI.PaymentService.Server.Protos;
using static ITI.InventoryService.Server.Protos.InventoryService;
using static ITI.PaymentService.Server.Protos.PaymentService;

namespace ITI.OrderService.Client
{
    public class Worker(ILogger<Worker> logger, IHostApplicationLifetime hostLifetime, int orderId) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var paymentChannel = GrpcChannel.ForAddress("https://localhost:7161");
            var paymentClient = new PaymentServiceClient(paymentChannel); 
            var inventoryChannel = GrpcChannel.ForAddress("https://localhost:7169"); 
            var inventoryClient = new InventoryServiceClient(inventoryChannel);

            var random = new Random();
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var inventoryMessage = new ProductDetails
                    {
                        OrderId = orderId,
                        ProductId = random.Next(1, 500),
                        Quantity = random.Next(1, 2001),
                    };

                    var paymentMessage = new UserDetails
                    {
                        OrderId = orderId,
                        UserId = random.Next(1, 100),
                        Balance = random.Next(0, 2001)
                    };

                    var paymentResponse = await paymentClient.DeductBalanceAsync(paymentMessage);
                    var inventoryResponse = await inventoryClient.DeductQuantityAsync(inventoryMessage);

                    logger.LogInformation("Message Sent, User's Balance: {balance}, Product's Quantity: {qty}," +
                                        " Payment's Approval: {paymentSuccess}, Inventory's Approval: {inventorySuccess}, Order's Approval: {success}",
                        paymentMessage.Balance,
                        inventoryMessage.Quantity,
                        paymentResponse.Success,
                        inventoryResponse.Success,
                        paymentResponse.Success && inventoryResponse.Success);

                    await Task.Delay(1000, stoppingToken);
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable || ex.StatusCode == StatusCode.Unauthenticated)
                {
                    logger.LogError("Server unavailable: {message}. Stopping client.", ex.Message);
                    hostLifetime.StopApplication();
                    break;
                }
                catch (HttpRequestException ex)
                {
                    logger.LogError("Connection error: {message}. Stopping client.", ex.Message);
                    hostLifetime.StopApplication();
                    break;
                }
                catch (OperationCanceledException)
                {
                    logger.LogInformation("Worker stopping gracefully.");
                    break;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Unexpected error occurred. Stopping client.");
                    hostLifetime.StopApplication();
                    break;
                }
            }
        }
    }
}
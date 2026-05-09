using Grpc.Core;
using ITI.InventoryService.Server.Protos;
using static ITI.InventoryService.Server.Protos.InventoryService;

namespace ITI.InventoryService.Server.Services
{
    public class QuantityService(ILogger<QuantityService> logger) : InventoryServiceBase
    {
        public override Task<InventoryApproval> DeductQuantity(ProductDetails request, ServerCallContext context)
        {
            logger.LogInformation("Message Received, Order Id: {OrderId} - Product Id: {ProductId} - Quantity: {Qty}",
                request.OrderId,
                request.ProductId,
                request.Quantity);

            if (request.Quantity > 1000)
            {
                return Task.FromResult(new InventoryApproval { Success = true });
            }
            else
            {
                return Task.FromResult(new InventoryApproval { Success = false });
            }
        }
    }
}

using Grpc.Core;
using ITI.PaymentService.Server.Protos;
using static ITI.PaymentService.Server.Protos.PaymentService;

namespace ITI.PaymentService.Server.Services
{
    public class BalanceService(ILogger<BalanceService> logger) : PaymentServiceBase
    {
        public override Task<PaymentApproval> DeductBalance(UserDetails request, ServerCallContext context)
        {
            logger.LogInformation("Received User Details of ID: {UserId} and Balance: {Balance} for Order ID: {orderId}",
                request.UserId,
                request.Balance,
                request.OrderId);

            if (request.Balance > 1000)
            {
                return Task.FromResult(new PaymentApproval { Success = true });
            }
            else
            {
                return Task.FromResult(new PaymentApproval { Success = false });
            }
        }
    }
}

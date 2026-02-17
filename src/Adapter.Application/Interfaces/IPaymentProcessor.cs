using Adapter.Application.Dtos.Payment;
using Adapter.Domain.Payment;

namespace Adapter.Application.Interfaces
{
    public interface IPaymentProcessor
    {
        PaymentResult ProcessPayment(PaymentRequest request);
        bool RefundPayment(string transactionId, decimal amount);
        PaymentStatus CheckStatus(string transactionId);
    }
}
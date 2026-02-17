using Adapter.Application.Dtos.Payment;
using Adapter.Application.Helpers;
using Adapter.Application.Interfaces;
using Adapter.Domain.Payment;

namespace Adapter.Infra.Adapters
{
    public class PaymentAdapter(IPaymentLegacyClient client) : IPaymentProcessor
    {
        private readonly IPaymentLegacyClient _client = client;

        public PaymentStatus CheckStatus(string transactionId)
        {
            var result = _client.QueryTransactionStatus(transactionId);

            return result.ToUpper() switch
            {
                "APPROVED" => PaymentStatus.Approved,
                "DECLINED" => PaymentStatus.Declined,
                "PENDING" => PaymentStatus.Pending,
                _ => throw new Exception("Status não mapeado")
            };
        }

        public PaymentResult ProcessPayment(PaymentRequest request)
        {
            var legacyReq = new
            {
                CardNumber = request.CreditCardNumber,
                Cvv = request.Cvv.ToInt(),
                ExpMonth = request.ExpirationDate.Month.ToString().ToInt(),
                ExpYear = request.ExpirationDate.Year.ToString().ToInt(),
                Amount = (double)request.Amount * 100,
                Customer = request.CustomerEmail
            };

            var response = _client.AuthorizeTransaction(
                legacyReq.CardNumber,
                legacyReq.Cvv,
                legacyReq.ExpMonth,
                legacyReq.ExpYear,
                legacyReq.Amount,
                legacyReq.Customer);

            return new PaymentResult
            {
                Success = response.ResponseCode == "00",
                TransactionId = response.TransactionRef,
                Message = response.ResponseMessage
            };
        }

        public bool RefundPayment(string transactionId, decimal amount)
        {
            return _client.ReverseTransaction(transactionId, (double)amount * 100);
        }
    }
}
using Adapter.Application.Dtos.Payment;

namespace Adapter.Application.Interfaces
{
    public interface IPaymentLegacyClient
    {
        LegacyTransactionResponse AuthorizeTransaction(
            string cardNum,
            int cvvCode,
            int expMonth,
            int expYear,
            double amountInCents,
            string customerInfo);

        bool ReverseTransaction(string transRef, double amountInCents);
        string QueryTransactionStatus(string transRef);
    }
}
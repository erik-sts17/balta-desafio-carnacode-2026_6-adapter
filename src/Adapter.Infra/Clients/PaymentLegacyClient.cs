using Adapter.Application.Dtos.Payment;
using Adapter.Application.Interfaces;

namespace Adapter.Infra.Clients
{
    public class PaymentLegacyClient : IPaymentLegacyClient
    {
        public LegacyTransactionResponse AuthorizeTransaction(
           string cardNum,
           int cvvCode,
           int expMonth,
           int expYear,
           double amountInCents,
           string customerInfo)
        {
            Console.WriteLine($"[Sistema Legado] Autorizando transação...");
            Console.WriteLine($"Cartão: {cardNum}");
            Console.WriteLine($"Valor: {amountInCents / 100:C}");

            // Simulação de processamento
            IsValid(cvvCode, expMonth, expYear, customerInfo);

            //Retorno
            var response = new LegacyTransactionResponse
            {
                AuthCode = Guid.NewGuid().ToString()[..8].ToUpper(),
                ResponseCode = "00",
                ResponseMessage = "TRANSACTION APPROVED",
                TransactionRef = $"LEG{DateTime.Now.Ticks}"
            };
            return response;
        }

        public bool ReverseTransaction(string transRef, double amountInCents)
        {
            Console.WriteLine($"[Sistema Legado] Revertendo transação {transRef}");
            Console.WriteLine($"Valor: {amountInCents / 100:C}");
            return true;
        }

        public string QueryTransactionStatus(string transRef)
        {
            Console.WriteLine($"[Sistema Legado] Consultando transação {transRef}");
            return "APPROVED";
        }

        private static void IsValid(int cvvCode, int expMonth, int expYear, string customer) 
        {
            Console.WriteLine($"Validando os dados: {cvvCode} - {expMonth}/{expYear} - {customer}");
        }
    }
}
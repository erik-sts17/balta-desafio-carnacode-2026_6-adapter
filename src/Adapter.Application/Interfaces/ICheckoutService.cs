namespace Adapter.Application.Interfaces
{
    public interface ICheckoutService
    {
        void CompleteOrder(string customerEmail, decimal amount, string cardNumber);
    }
}
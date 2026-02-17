using Adapter.Application.Interfaces;
using Adapter.Application.Services;
using Adapter.Infra.Adapters;
using Adapter.Infra.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Adapter.Console.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddServices(this IServiceCollection services) 
        {
            services.AddTransient<IPaymentProcessor, PaymentAdapter>();
            services.AddTransient<IPaymentLegacyClient, PaymentLegacyClient>();
            services.AddTransient<ICheckoutService, CheckoutService>();
        }
    }
}
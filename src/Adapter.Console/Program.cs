using Adapter.Application.Interfaces;
using Adapter.Console.Configurations;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddServices();

var provider = services.BuildServiceProvider();

var checkoutService = provider.GetRequiredService<ICheckoutService>();

checkoutService.CompleteOrder("cliente@email.com", 150.00m, "4111111111111111");
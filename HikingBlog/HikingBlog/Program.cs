using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Destinations.Seasides.Commands.CreateDestination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
 static async Task MainFunc(string[] args)
{
    var serviceCollection = new ServiceCollection()
        .AddMediatR(typeof(IDestinationRepository))
        .BuildServiceProvider();

    var mediator = serviceCollection.GetRequiredService<IMediator>();

    await mediator.Send(new CreateSeasideCommand
    {
        Name = "Konstantin and Elena Beach",

    })

         var orderId = await mediator.Send(new CreateOrderCommand
         {
             BuyerName = "TheBuyer",
             OrderItems = new List<OrderItemDto>
                {
                    new() { Quantity = 1, Price = 5, ProductName = "Telefon" },
                    new() { Quantity = 2, Price = 7, ProductName = "TV" }
                }
         });

    Console.WriteLine($"Order created with {orderId}");


    var orders = await mediator.Send(new GetOrdersListQuery());

    var productId = await mediator.Send(new CreateProductCommand { Name = "test", Price = 10 });
    var products = await mediator.Send(new GetProductsListQuery());
}
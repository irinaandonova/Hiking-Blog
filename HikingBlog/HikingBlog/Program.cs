using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited;
using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Destinations.Seasides.Commands.CreateDestination;
using System;
using System.Reflection;
using System.Threading.Tasks;
using NatureBlog.Infrastructure.Repositories;

var serviceCollection = new ServiceCollection()
    .AddMediatR(Assembly.GetExecutingAssembly())
    .AddScoped(typeof(IDestinationRepository), typeof(DestinationRepository))
    .BuildServiceProvider();
    

var mediator = serviceCollection.GetRequiredService<IMediator>();

bool result = await mediator.Send(new CreateSeasideCommand
{
    Name = "Konstantin and Elena Beach",
    CreatorId = Guid.NewGuid(),
    Description = "Great beach",
    ImageUrl = "img.jpg",
    Region = "Varna",
    IsGuarded = true,
    OffersUmbrella = true
});

var destinations = await mediator.Send(new GetMostVisitedQuery());
foreach (var destination in destinations)
    Console.WriteLine(destination.Name);


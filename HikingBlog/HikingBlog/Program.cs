using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using Application;
using Application.Interfaces;
using Infrastructure.Repositories;
using Application.App.Destinations.Seasides.Commands.CreateSeaside;
using Application.App.Destinations.Destinations.Queries.GetMostVisited;

var serviceCollection = new ServiceCollection()
    .AddMediatR(typeof(AssemblyMarker).Assembly)
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
foreach(var destination in destinations)
    Console.WriteLine(destination.Name);
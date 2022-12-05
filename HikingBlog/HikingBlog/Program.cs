using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NatureBlog.Application;
using NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited;
using NatureBlog.Application.Destinations.Seasides.Commands.CreateSeaside;
using NatureBlog.Application.Repositories;
using NatureBlog.Infrastructure.Repositories;
using System;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatureBlog.Application.Destinations.Parks.Commands.CreatePark;

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

await mediator.Send(new CreateHikingTrailCommand
{
    Name = "Rilski ezera",
    CreatorId = Guid.NewGuid(),
    Description = "Amazing views",
    ImageUrl = "img.jpg",
    Region = "Rila",
    Difficulty = 2,
    Duration = 180
});

await mediator.Send(new CreateParkCommand
{
    Name = "Lauta",
    CreatorId = Guid.NewGuid(),
    Description = "Big park with lots of activities",
    ImageUrl = "img.jpg",
    Region = "Plovdiv",
    IsDogFriendly = false,
    HasPlayground = true
});


var destinations = await mediator.Send(new GetMostVisitedQuery());
foreach (var destination in destinations)
    Console.WriteLine(destination.Name);


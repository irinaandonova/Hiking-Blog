using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NatureBlog.Application;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatureBlog.Application.Destinations.Parks.Commands.CreatePark;
using NatureBlog.Application.Destinations.Seasides.Commands.CreateSeaside;
using NatureBlog.Application.Repositories;
using NatureBlog.Infrastructure.Repositories;
using System;
using NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside;
using NatureBlog.Application.Destinations.HikingTrails.Queries.GetAllHikingTrail;
using NatureBlog.Application.Destinations.Parks.Queries.GetAllPark;
using NatureBlog.Application.Destinations.HikingTrails.Commands.ChangeDifficulty;
using NatureBlog.Application.Destinations.AllDestinations.Queries.GetDestination;
using NatureBlog.Domain.Models;
using System.Collections.Generic;
using NatureBlog.Application.Destinations.Parks.Queries.FilterParks;

var serviceCollection = new ServiceCollection()
    .AddMediatR(typeof(AssemblyMarker).Assembly)
    .AddScoped(typeof(IDestinationRepository), typeof(DestinationRepository))
    .BuildServiceProvider();


var mediator = serviceCollection.GetRequiredService<IMediator>();


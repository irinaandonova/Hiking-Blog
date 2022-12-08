using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NatureBlog.Application;
using NatureBlog.Application.App;
using NatureBlog.Application.Repositories;
using NatureBlog.Infrastructure;
using NatureBlog.Infrastructure.Repositories;
using NatuteBlog.Application.Regions;
using System;
using System.Reflection;

try
{
    var serviceCollection = new ServiceCollection()
        .AddMediatR(typeof(AssemblyMarker).Assembly)
        .AddScoped(typeof(IDestinationRepository), typeof(DestinationRepository))
        .AddScoped(typeof(IRegion), typeof(RegionRepository))
        .BuildServiceProvider();


    var mediator = serviceCollection.GetRequiredService<IMediator>();

    await mediator.Send(new CreateRegionCommand
    {
        Name = "Rila",
        Cordinates = "1728:762"
    });
    /*
    await mediator.Send(new CreateHikingTrailCommand
    {
        Name = "Seven Rila lakes",
        CreatorId = Guid.NewGuid(),
        Description = "Great hiking Trail",
        ImageUrl = "img.com",
        Region = region,
        Difficulty = 2,
        Duration = 180
    });
    */
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

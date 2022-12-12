using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NatureBlog.Application;
using NatureBlog.Application.Repositories;
using NatureBlog.Infrastructure;
using NatureBlog.Infrastructure.Repositories;
using System;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatuteBlog.Application.Regions;

try
{
    var serviceCollection = new ServiceCollection()
        .AddMediatR(typeof(AssemblyMarker).Assembly)
        .AddScoped(typeof(IDestinationRepository), typeof(DestinationRepository))
        .AddScoped(typeof(IRegionRepository), typeof(RegionRepository))
        .AddScoped(typeof(IUserRepository), typeof(UserRepository))
        .AddDbContext<AppDBContext>()
        .BuildServiceProvider();


    var mediator = serviceCollection.GetRequiredService<IMediator>();
    /*
    await mediator.Send(new CreateHikingTrailCommand
    {
        Name = "Seven Rila Lakes",
        Description = "Amazing trail",
        CreatorId = Guid.Parse(9A39DC77-08E8-4204-A3CF-A304D05F2597),
        ImageUrl = "img.com",
        Region = Guid.Parse("9E3B6769 - F222 - 4915 - BC9A - 8C2928BC80F9"),
        Difficulty = 2,
        Duration = 90
    });
 */

    await mediator.Send(new CreateRegionCommand
    {
        Name = "Pirin",
        Cordinates = " 41°32'34.4\"N 23°33'34.3\"E"
    });
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

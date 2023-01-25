using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NatureBlog.Application;
using NatureBlog.Application.Repositories;
using NatureBlog.Infrastructure;
using NatureBlog.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo { Title = "Authentication-Authorization-Sample", Version = "v1" });

    o.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
    {
        Description = "OAuth2 AuthorizationCodeFlow",
        Name = "OAuth2",
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri(builder.Configuration["SwaggerAzureAD:AuthorizatoinUrl"]),
                TokenUrl = new Uri(builder.Configuration["SwaggerAzureAD:TokenUrl"]),
                Scopes = new Dictionary<string, string>
                            {
                                {builder.Configuration["SwaggerAzureAD:Scope"], "Access API as User" }
                            }
            }
        }
    });

    o.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference{ Type = ReferenceType.SecurityScheme, Id = "OAuth2"}
                        },
                        new[] { builder.Configuration["SwaggerAzureAD:Scope"] }
                    }
                });
});

builder.Services.AddCors(o =>
    o.AddDefaultPolicy(b =>
        b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICommentRepository, CommentsRepository>();
builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddMediatR(typeof(AssemblyMarker).Assembly);
builder.Services.AddAutoMapper(typeof(AssemblyMarker).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(o =>
    {
        o.OAuthClientId(builder.Configuration["SwaggerAzureAD:ClientId"]);

        o.OAuthUsePkce();

         o.OAuthScopeSeparator(" "); // For more than one scope
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();

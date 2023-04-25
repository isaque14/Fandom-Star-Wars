using CleanArchMvc.Infra.IoC;
using FandomStarWars.API.Controllers;
using FandomStarWars.Domain.Account;
using FandomStarWars.Infra.IoC;
using Serilog;
using System.Text.Json.Serialization;
using FandomStarWars.Application.Interfaces;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureExternalApiClients(builder.Configuration);
builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureHealthChecks(builder.Configuration);
builder.Services.AddInfrastructureSendGrid(builder.Configuration);
builder.Services.AddInfrastructureSwagger();
builder.Services.AddHttpClient<CuriositiesWithChatGptController>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(DependencyInjectionSerilog.AddInfrastructureSerilog(builder.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Famdom Star Wars API V1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

app.UseRouting();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var seedUserRoleInitial = services.GetRequiredService<ISeedUserRoleInitial>();
    var seedbankInitial = services.GetRequiredService<ISeedDataBankService>();

    seedUserRoleInitial.SeedRoles();
    seedUserRoleInitial.SeedUsers();
    await seedbankInitial.InsertData();
}

app.UseHealthChecks("/health", new HealthCheckOptions
{
    Predicate = p => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(options => { options.UIPath = "/dashbord"; });

app.MapHealthChecksUI();

app.UseStatusCodePages();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
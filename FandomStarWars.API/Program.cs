using CleanArchMvc.Infra.IoC;
using FandomStarWars.API.Controllers;
using FandomStarWars.Domain.Account;
using FandomStarWars.Infra.IoC;
using Serilog;
using System.Text.Json.Serialization;
using SendGrid.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using FandomStarWars.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureExternalApiClients(builder.Configuration);
builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpClient<CuriositiesWithChatGptController>();
IConfiguration config = builder.Configuration;
var keySecret = config["ConnectionStrings:Default"];

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.PostgreSQL(keySecret, "Logs", needAutoCreateTable: true)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddSendGrid(opt =>
{
    opt.ApiKey = builder
    .Configuration.GetSection("SendGridEmailSettings").GetValue<string>("APIKey");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI()//c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Famdom Star Wars API V1");
    //    c.RoutePrefix = "/swagger";
    //});
}

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

app.UseStatusCodePages();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
using CleanArchMvc.Infra.IoC;
using FandomStarWars.API.Controllers;
using FandomStarWars.Domain.Account;
using FandomStarWars.Infra.IoC;
using Serilog;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog.Sinks.PostgreSQL;
using Microsoft.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Host.UseSerilog(Log.Logger);

builder.Services.AddInfrastructureExternalApiClients(builder.Configuration);
builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

//using (var serviceScope = app.Services.CreateScope())
//{
//    var services = serviceScope.ServiceProvider;
//    var seedUserRoleInitial = services.GetRequiredService<ISeedUserRoleInitial>();

//    seedUserRoleInitial.SeedRoles();
//    seedUserRoleInitial.SeedUsers();
//}



app.UseStatusCodePages();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
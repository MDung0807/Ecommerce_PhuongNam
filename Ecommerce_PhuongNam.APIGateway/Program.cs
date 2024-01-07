using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Configuration.AddJsonFile("ocelot.json", optional: true, reloadOnChange: true);
services.AddOcelot(builder.Configuration);
var app = builder.Build();

//ocelot
await app.UseOcelot();
app.Run();
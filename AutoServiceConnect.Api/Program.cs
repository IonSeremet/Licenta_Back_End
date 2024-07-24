using System.Text.Json.Serialization;
using AutoServiceConnect.Api;
using AutoServiceConnect.Api.Database;
using AutoServiceConnect.Api.Middlewares;
using AutoServiceConnect.Api.Services;
using AutoServiceConnect.Api.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});;

var folder = System.AppDomain.CurrentDomain.BaseDirectory;
var dbPath = System.IO.Path.Join(folder, "AutoServiceConnect.db"); // TODO: To be replaced later with a MsSQL Db


var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);
builder.Services.AddSingleton(appSettings);

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AutoServiceDbContext>(options =>
    options.UseSqlServer(appSettings.SqlConnectionString));
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<GoogleAuthenticationService>();
builder.Services.AddScoped<AutoServiceService>();
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

app.Run();

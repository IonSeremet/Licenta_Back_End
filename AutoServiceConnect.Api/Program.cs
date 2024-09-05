using System.Text.Json.Serialization;
using AutoServiceConnect.Api;
using AutoServiceConnect.Api.Database;
using AutoServiceConnect.Api.Middlewares;
using AutoServiceConnect.Api.Services;
using AutoServiceConnect.Api.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auto Service Management", Version = "v1" }); 
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});
builder.Services.AddDbContext<AutoServiceDbContext>(options =>
    options.UseSqlServer(appSettings.SqlConnectionString));
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<GoogleAuthenticationService>();
builder.Services.AddScoped<AutoServiceService>();
builder.Services.AddScoped<CarService>();
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

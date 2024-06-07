using System.Reflection;
using System.Text;
using AutoServiceConnect.Api;
using AutoServiceConnect.Api.Database;
using AutoServiceConnect.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var folder = System.AppDomain.CurrentDomain.BaseDirectory;
var dbPath = System.IO.Path.Join(folder, "AutoServiceConnect.db"); // TODO: To be replaced latee with a MsSQL Db



var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);
builder.Services.AddSingleton(appSettings);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AutoServiceDbContext>(options => 
    options.UseSqlite($"Data Source={dbPath}"));
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<GoogleAuthenticationService>();
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.Events = new JwtBearerEvents
        {
            OnTokenValidated = async context =>
            {
                var userService = context.HttpContext.RequestServices.GetRequiredService<UserService>();
                var userId = context.Principal?.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
                if (userId == null)
                    context.Fail("Unauthorized");
                var userExists = await userService.GetUserById(Int32.Parse(userId!));
                if (userExists == null)
                    context.Fail("Unauthorized");
            }
        };
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(appSettings.JwtSecret)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

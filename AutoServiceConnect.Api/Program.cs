using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using AutoServiceConnect.Api;
using AutoServiceConnect.Api.Database;
using AutoServiceConnect.Api.Middlewares;
using AutoServiceConnect.Api.Services;
using AutoServiceConnect.Api.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AutoServiceDbContext>(options => 
    options.UseSqlite($"Data Source={dbPath}"));
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<GoogleAuthenticationService>();
builder.Services.AddScoped<AutoServiceService>();
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddCors();
// builder.Services.AddAuthentication(x =>
//     {
//         x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//         x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     })
//     .AddJwtBearer(x =>
//     {
//         x.Events = new JwtBearerEvents
//         {
//             OnTokenValidated = async context =>
//             {
//                 var userService = context.HttpContext.RequestServices.GetRequiredService<UserService>();
//                 var userId = context.Principal?.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
//                 if (userId == null)
//                     context.Fail("Unauthorized");
//                 var userExists = await userService.GetUserById(Int32.Parse(userId!));
//                 if (userExists == null)
//                     context.Fail("Unauthorized");
//             }
//         };
//         x.RequireHttpsMetadata = false;
//         x.SaveToken = true;
//         x.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(
//                 Encoding.ASCII.GetBytes(appSettings.JwtSecret)),
//             ValidateIssuer = false,
//             ValidateAudience = false
//         };
//     });
// builder.Services.AddAuthorization();



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

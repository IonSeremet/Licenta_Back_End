using System.Security.Authentication;
using AutoServiceConnect.Api.CustomAttributes;
using AutoServiceConnect.Api.Database.Models;
using AutoServiceConnect.Api.Services;
using AutoServiceConnect.Api.ViewModels.Car;
using AutoServiceConnect.Api.ViewModels.ServiceAppointment;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceConnect.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private readonly CarService _carService;

    public CarController(CarService carService)
    {
        _carService = carService;
    }
    
    [AuthorizeRoles(Role.Customer)]
    [HttpPost]
    public async Task<IActionResult> AddCar(
        [FromBody] CarRequest car)
    {
        var userId = ((User) (HttpContext.Items["User"] ?? throw new AuthenticationException())).Id;
        await _carService.AddCar(car, userId);
        return Created(); // TODO: Add created link
    }

    [AuthorizeRoles()]
    [HttpPut("{carId}")]
    public async Task<IActionResult> EditCar(
        [FromRoute] int carId,
        [FromBody] CarRequest car)
    {
        // await _autoServiceService.CreateAutoService(request);
        return Created(); // TODO: Add created link
    }

    // [AuthorizeRoles()]
    [HttpGet("{carId}")]
    public async Task<CarResponse> GetCar(
        [FromRoute] int carId)
    {

        return new CarResponse(){
            Id = 1,
            Brand = "Tesla",
            Rating = 112,
            CarName = "Tesla Malibu",
            ImgUrl = "img01",
            Model = "Model 3",
            Price = 50,
            Speed = "20kmpl",
            Gps = "GPS Navigation",
            SeatType = "Heated seats",
            Automatic = "Automatic",
            Description =
                " Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam. Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam.",
        };
    }

    // [AuthorizeRoles()]
    [HttpGet("user/{userId}")]
    public async Task<IEnumerable<CarResponse>> GetCarsOfUser(
        [FromRoute] int userId)
    {
        var cars =
        new List<CarResponse>
        {
            new()
            {
                Id = 1,
                Brand = "Tesla",
                Rating = 112,
                CarName = "Tesla Malibu",
                ImgUrl = "img01",
                Model = "Model 3",
                Price = 50,
                Speed = "20kmpl",
                Gps = "GPS Navigation",
                SeatType = "Heated seats",
                Automatic = "Automatic",
                Description =
                    " Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam. Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam.",
            },

            new()
            {
                Id = 2,
                Brand = "Toyota",
                Rating = 102,
                CarName = "Toyota Aventador",
                ImgUrl = "img02",
                Model = "Model-2022",
                Price = 50,
                Speed = "20kmpl",
                Gps = "GPS Navigation",
                SeatType = "Heated seats",
                Automatic = "Automatic",
                Description =
                    " Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam. Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam.",
            },

            new()
            {
                Id = 3,
                Brand = "BMW",
                Rating = 132,
                CarName = "BMW X3",
                ImgUrl = "img03",
                Model = "Model-2022",
                Price = 65,
                Speed = "20kmpl",
                Gps = "GPS Navigation",
                SeatType = "Heated seats",
                Automatic = "Automatic",
                Description =
                    " Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam. Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam.",
            },

            new()
            {
                Id = 4,
                Brand = "Nissan",
                Rating = 102,
                CarName = "Nissan Mercielago",
                ImgUrl = "img04",
                Model = "Model-2022",
                Price = 70,
                Speed = "20kmpl",
                Gps = "GPS Navigation",
                SeatType = "Heated seats",
                Automatic = "Automatic",
                Description =
                    " Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam. Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam.",
            },

            new()
            {
                Id = 5,
                Brand = "Ferrari",
                Rating = 94,
                CarName = "Ferrari Camry",
                ImgUrl = "img05",
                Model = "Model-2022",
                Price = 45,
                Speed = "20kmpl",
                Gps = "GPS Navigation",
                SeatType = "Heated seats",
                Automatic = "Automatic",
                Description =
                    " Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam. Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam.",
            },

            new()
            {
                Id = 6,
                Brand = "Mercedes",
                Rating = 119,
                CarName = "Mercedes Benz XC90",
                ImgUrl = "img06",
                Model = "Model-2022",
                Price = 85,
                Speed = "20kmpl",
                Gps = "GPS Navigation",
                SeatType = "Heated seats",
                Automatic = "Automatic",
                Description =
                    " Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam. Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam.",
            },

            new()
            {
                Id = 7,
                Brand = "Audi",
                Rating = 82,
                CarName = "Audi Fiesta",
                ImgUrl = "img07",
                Model = "Model 3",
                Price = 50,
                Speed = "20kmpl",
                Gps = "GPS Navigation",
                SeatType = "Heated seats",
                Automatic = "Automatic",
                Description =
                    " Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam. Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam.",
            },

            new()
            {
                Id = 8,
                Brand = "Colorado",
                Rating = 52,
                CarName = "Rolls Royce Colorado",
                ImgUrl = "img08",
                Model = "Model 3",
                Price = 50,
                Speed = "20kmpl",
                Gps = "GPS Navigation",
                SeatType = "Heated seats",
                Automatic = "Automatic",
                Description =
                    " Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam. Dolor labore lorem no accusam sit justo sadipscing labore invidunt voluptua, amet duo et gubergren vero gubergren dolor. At diam.",
            }
        };
        return cars;
    }

    [AuthorizeRoles([Role.Customer])]
    [HttpDelete("/{carId}")]
    public async Task RemoveCar(
        [FromRoute] int carId)
    {
        return;
    }
}
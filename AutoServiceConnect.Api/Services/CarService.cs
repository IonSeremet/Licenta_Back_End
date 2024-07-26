using AutoServiceConnect.Api.Database;
using AutoServiceConnect.Api.Database.Models;
using AutoServiceConnect.Api.ViewModels.Car;

namespace AutoServiceConnect.Api.Services;

public class CarService
{
    private readonly AutoServiceDbContext _context;

    public CarService(AutoServiceDbContext context)
    {
        _context = context;
    }

    public async Task AddCar(CarRequest carRequest, int customerId)
    {
        var car = new Car
        {
            CustomerId = customerId,
            Brand = carRequest.Brand,
            Model = carRequest.Model,
            Year = carRequest.Year,
            VIN = carRequest.VIN,
            LicencePlace = carRequest.LicencePlace,
            Mileage = carRequest.Mileage,
            Color = carRequest.Color,
            EngineType = carRequest.EngineType,
            Rating = carRequest.Rating,
            ImgUrl = carRequest.ImgUrl,
            Speed = carRequest.Speed,
            HasGps = carRequest.HasGps,
            SeatType = carRequest.SeatType,
            Automatic = carRequest.Automatic,
            Description = carRequest.Description
        };
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<Car> GetCarsOfCustomer(int? customerId)
    {
        return _context.Cars.Where(c => c.CustomerId == customerId);
    }
}
using AutoServiceConnect.Api.Database;
using AutoServiceConnect.Api.Database.Models;
using AutoServiceConnect.Api.Services.Models;
using AutoServiceConnect.Api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AutoServiceConnect.Api.Services;

public class CustomerService
{
    private readonly UserService _userService;
    private readonly AutoServiceDbContext _dbContext;

    public CustomerService(UserService userService, AutoServiceDbContext dbContext)
    {
        _userService = userService;
        _dbContext = dbContext;
    }
    public async Task<LoginCustomerResponse> CustomerLogin(RegisterLoginUserRequest request)
    {
        var (user, token) = await _userService.Login(request.Email, request.Password);
        Customer? customer = null;
        if (user.Role == Role.Customer)
            customer =  await _dbContext.Customers.FirstOrDefaultAsync(u => u.CustomerId == user.CustomerId);
        else
            throw new UnauthorizedAccessException();
        return new LoginCustomerResponse
        {
            Email = user.Email,
            ContactInformation = customer?.ContactInformation,
            Name = user.FullName,
            ProfilePicture = user.ProfilePicture,
            Token = token
        };
    }
}
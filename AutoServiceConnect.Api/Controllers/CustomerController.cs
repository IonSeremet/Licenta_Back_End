using AutoServiceConnect.Api.Services;
using AutoServiceConnect.Api.Services.Models;
using AutoServiceConnect.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using LoginUserResponse = AutoServiceConnect.Api.ViewModels.LoginUserResponse;

namespace AutoServiceConnect.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController: ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpPut("login")]
    public async Task<LoginCustomerResponse> UpdateInfo([FromBody] RegisterLoginUserRequest request)
    {
        var result = await _customerService.CustomerLogin(request);
        return result;
    }
    
    [HttpPost("login")]
    public async Task<LoginCustomerResponse> Login([FromBody] RegisterLoginUserRequest request)
    {
        var result = await _customerService.CustomerLogin(request);
        return result;
    }
}
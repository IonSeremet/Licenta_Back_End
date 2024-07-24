using AutoServiceConnect.Api.Services;
using AutoServiceConnect.Api.Services.Models;
using AutoServiceConnect.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceConnect.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AutoServiceManagerController: ControllerBase
{
    private readonly AutoServiceService _autoServiceService;

    public AutoServiceManagerController(AutoServiceService autoServiceService)
    {
        _autoServiceService = autoServiceService;
    }

    [HttpPost("login")]
    public async Task<LoginAutoServiceResponse> Login([FromBody] RegisterLoginUserRequest request)
    {
        var result = await _autoServiceService.AutoServiceLogin(request);
        return result;
    }
}
using AutoServiceConnect.Api.CustomAttributes;
using AutoServiceConnect.Api.Database.Models;
using AutoServiceConnect.Api.Services;
using AutoServiceConnect.Api.Services.Models;
using AutoServiceConnect.Api.ViewModels;
using AutoServiceConnect.Api.ViewModels.AutoService;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceConnect.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AutoServiceController: ControllerBase
{
    private readonly AutoServiceService _autoServiceService;

    public AutoServiceController(AutoServiceService autoServiceService)
    {
        _autoServiceService = autoServiceService;
    }
    
    [AuthorizeRoles([Role.Admin, Role.AutoServiceManager])]
    [HttpPost]
    public async Task<IActionResult> CreateAutoService(CreateAutoServiceRequest request)
    {
        await _autoServiceService.CreateAutoService(request);
        return Created();
    }
    
    [AuthorizeRoles([Role.Admin,Role.AutoServiceManager])]
    [HttpPut]
    public async Task<IActionResult> UpdateAutoService(CreateAutoServiceRequest request)
    {
        await _autoServiceService.CreateAutoService(request);
        return Created();
    }

    [HttpGet("{id}")]
    public async Task<AutoService> GetAutoService(int id)
    {
        return await _autoServiceService.GetAutoServiceById(id);
    }
    
    [HttpGet()] //47.010453,28.86381
    public async Task<IEnumerable<AutoService>> GetAutoServicesInProximity(int id, [FromQuery] float? longitude, [FromQuery] float? latitude)
    {
        return [await _autoServiceService.GetAutoServiceById(id)];
    }
}
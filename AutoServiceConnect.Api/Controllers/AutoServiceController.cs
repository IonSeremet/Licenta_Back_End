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
        // return await _autoServiceService.GetAutoServiceById(id);
        return new AutoService()
        {
            Name = "Auto Repair",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam facilisis dolor in vehicula finibus. Phasellus dapibus, velit at laoreet bibendum, nibh nisi sollicitudin neque, in maximus lectus massa non nulla. Phasellus ornare nisl vitae erat lobortis pellentesque. Curabitur a velit eget augue euismod sagittis id et purus.",
            Address = "Timisoara str. Timeoclului 1",
            MapCoordinates = "47.019974, 28.833351",
            Rating = "10",
            ImageLink =
                "https://cdn.vectorstock.com/i/500p/57/48/auto-repair-service-logo-badge-emblem-template-vector-49765748.jpg"
        };
    }
    
    [HttpGet()] //47.010453,28.86381
    public async Task<IEnumerable<AutoService?>> GetAutoServicesInProximity([FromQuery] float? longitude, [FromQuery] float? latitude)
    {
        return await _autoServiceService.GetAutoServicesByProximity(longitude, latitude);
    }
}
using AutoServiceConnect.Api.Services;
using AutoServiceConnect.Api.ViewModels.AutoService;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceConnect.Api.Controllers;

public class AutoServiceController: ControllerBase
{
    private readonly AutoServiceService _autoServiceService;

    public AutoServiceController(AutoServiceService autoServiceService)
    {
        _autoServiceService = autoServiceService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAutoService(CreateAutoServiceRequest request)
    {
        await _autoServiceService.CreateAutoService(request);
        return Created();// TODO: Add created link
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAutoService(int id)
    {
        return Ok(await _autoServiceService.GetAutoServiceById(id));
    }
}
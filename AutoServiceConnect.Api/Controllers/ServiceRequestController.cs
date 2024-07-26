using AutoServiceConnect.Api.CustomAttributes;
using AutoServiceConnect.Api.Database.Models;
using AutoServiceConnect.Api.ViewModels.AutoService;
using AutoServiceConnect.Api.ViewModels.ServiceAppointment;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceConnect.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceAppointmentController: ControllerBase
{
    [AuthorizeRoles([Role.Customer])]
    [HttpPost("{serviceId}")]
    public async Task<IActionResult> CreateServiceRequest(
        [FromRoute] string serviceId, 
        [FromBody] CreateServiceAppointmentRequest appointment)
    {
        // await _autoServiceService.CreateAutoService(request);
        return Created();// TODO: Add created link
    }
    
    [AuthorizeRoles([Role.Customer])]
    [HttpPost]
    public async Task<IActionResult> CreateServiceRequest(CreateServiceAppointmentRequest Appointment)
    {
        // await _autoServiceService.CreateAutoService(request);
        return Created();// TODO: Add created link
    }
    
    [AuthorizeRoles([Role.Customer])]
    [HttpGet]
    public async Task<IEnumerable<ServiceAppointmentResponse>> GetCustomersServiceRequests()
    {
        // await _autoServiceService.CreateAutoService(request);
        return [new ServiceAppointmentResponse()];// TODO: Add created link
    }
    
    [AuthorizeRoles([Role.Customer])]
    [HttpGet("{serviceRequestId}")]
    public async Task<ServiceAppointmentResponse> GetServiceRequest(string serviceRequestId)
    {
        // await _autoServiceService.CreateAutoService(request);
        return new ServiceAppointmentResponse();// TODO: Add created link
    }
}
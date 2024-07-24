using AutoServiceConnect.Api.Database;
using AutoServiceConnect.Api.Database.Models;
using AutoServiceConnect.Api.Services.Models;
using AutoServiceConnect.Api.ViewModels;
using AutoServiceConnect.Api.ViewModels.AutoService;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoServiceConnect.Api.Services;

public class AutoServiceService
{
    private readonly AutoServiceDbContext _autoServiceDbContext;
    private readonly UserService _userService;
    private readonly AutoServiceDbContext _dbContext;

    public AutoServiceService(
        AutoServiceDbContext autoServiceDbContext, 
        UserService userService,
        AutoServiceDbContext dbContext)
    {
        _autoServiceDbContext = autoServiceDbContext;
        _userService = userService;
        _dbContext = dbContext;
    }

    public Task CreateAutoService(CreateAutoServiceRequest createAutoServiceRequest)
    {
        _autoServiceDbContext.AutoServices.Add(new AutoService()
        {
            Name = createAutoServiceRequest.Name,
            Description = createAutoServiceRequest.Description,
            Address = createAutoServiceRequest.Address,
            MapCoordinates = createAutoServiceRequest.MapCoordinates,
            Rating = createAutoServiceRequest.Rating
        });
        return _autoServiceDbContext.SaveChangesAsync();
    }

    public async Task<AutoService?> GetAutoServiceById(int autoServiceId)
    {
        return await _autoServiceDbContext.AutoServices.FindAsync(autoServiceId);
    }
    
    public Task<IEnumerable<AutoService?>> GetAutoServicesByCity(string city)
    {
        // TODO: Connect Google maps API ?
        throw new NotImplementedException();
    }
    
    public Task<IEnumerable<AutoService?>> GetAutoServicesByProximity(string address)
    {
        // TODO: Connect Google maps API ?
        throw new NotImplementedException();
    }
    
    public async Task<AutoService> UpdateAutoService(int autoServiceId, CreateAutoServiceRequest createAutoServiceRequest)
    {
        var autoServiceToUpdate = new AutoService()
        {
            AutoServiceId = autoServiceId,
            Name = createAutoServiceRequest.Name,
            Description = createAutoServiceRequest.Description,
            Address = createAutoServiceRequest.Address,
            MapCoordinates = createAutoServiceRequest.MapCoordinates,
            Rating = createAutoServiceRequest.Rating
        };

        var updatedAutoService = _autoServiceDbContext.AutoServices.Update(autoServiceToUpdate);
        await _autoServiceDbContext.SaveChangesAsync();
        return updatedAutoService.Entity;
    }
    
    public async Task<LoginAutoServiceResponse> AutoServiceLogin(RegisterLoginUserRequest request)
    {
        var (user, token) = await _userService.Login(request.Email, request.Password);
        AutoService autoservice = null;
        if (user.Role == Role.Customer)
            autoservice = await _dbContext.AutoServices.FirstOrDefaultAsync(u => u.AutoServiceId == user.Id);
        else
            throw new UnauthorizedAccessException();
        return new LoginAutoServiceResponse
        {
            ContactEmail = user.Email,
            Address = autoservice.Address,
            Name = autoservice.Name,
            MapCoordinates = autoservice.MapCoordinates,
            Token = token,
            PhoneNumber = autoservice.PhoneNumber
        };
    }
}
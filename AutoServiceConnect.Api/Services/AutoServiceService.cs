using AutoServiceConnect.Api.Database;
using AutoServiceConnect.Api.Database.Models;
using AutoServiceConnect.Api.ViewModels.AutoService;

namespace AutoServiceConnect.Api.Services;

public class AutoServiceService
{
    private readonly AutoServiceDbContext _autoServiceDbContext;

    public AutoServiceService(AutoServiceDbContext autoServiceDbContext)
    {
        _autoServiceDbContext = autoServiceDbContext;
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
            Id = autoServiceId,
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
}
using TadataNet.Common.Models.Settings;

namespace TadataNet.Common.Services;

public interface ISettingsService
{
    Task<SettingsResponse> GetSettingsAsync();
    Task<UpdateSettingsResponse> UpdateSettingsAsync();
    Task<CreateSettingsResponse> CreateSettingsAsync();
}

public class SettingsService : ISettingsService
{
    public Task<CreateSettingsResponse> CreateSettingsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SettingsResponse> GetSettingsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UpdateSettingsResponse> UpdateSettingsAsync()
    {
        throw new NotImplementedException();
    }
}

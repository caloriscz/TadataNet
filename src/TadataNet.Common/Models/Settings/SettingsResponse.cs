using TadataNet.Common.Entities;

namespace TadataNet.Common.Models.Settings;

public class SettingsResponse
{
    public List<UserSetting> Settings { get; set; }
}
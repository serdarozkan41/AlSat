using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YerYok.Mobile.SettingService
{
    public interface ISettingsService
    {
        bool GetValueOrDefault(string key, bool defaultValue);
        string GetValueOrDefault(string key, string defaultValue);
        Task AddOrUpdateValue(string key, bool value);
        Task AddOrUpdateValue(string key, string value);
    }
}

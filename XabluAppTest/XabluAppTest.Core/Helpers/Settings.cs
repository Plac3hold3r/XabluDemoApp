// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace XabluAppTest.Core.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        private const string UserLoginKey = "UserLogin_key";
        private static readonly string UserLoginDefault = string.Empty;

        private const string UserPasswordKey = "UserPassword_key";
        private static readonly string UserPasswordDefault = string.Empty;

        private const string RememberLoginKey = "RememberLogin_key";
        private static readonly bool RememberLoginDefault = false;

        private const string RememberApiServiceKey = "RememberApiService";
        private static readonly string RememberApiServiceDefault = string.Empty;
        #endregion


        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
            }
        }

        public static string UserLogin
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(UserLoginKey, UserLoginDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(UserLoginKey, value);
            }
        }

        public static string UserPassword
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(UserPasswordKey, UserPasswordDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(UserPasswordKey, value);
            }
        }

        public static bool RememberLogin
        {
            get
            {
                return AppSettings.GetValueOrDefault<bool>(RememberLoginKey, RememberLoginDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<bool>(RememberLoginKey, value);
            }
        }

        public static string RememberApiService
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(RememberApiServiceKey, RememberApiServiceDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(RememberApiServiceKey, value);
            }
        }

    }
}
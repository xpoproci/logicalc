using Blazored.LocalStorage;

namespace UI.Tools
{
    public class Preferences
    {
        public string Color { get; set; } = string.Empty;
        public string DarkMode { get; set; } = string.Empty;
    }

    public enum ColorTheme
    {
        Blue, Green, Red, Amber
    }

    public class ThemeService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly string _key = "preferences";

        public ThemeService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task ToggleDarkMode()
        {
            var pref = await GetPreferencesAsync();
            pref.DarkMode = string.IsNullOrEmpty(pref.DarkMode) ? "dark" : string.Empty;
            await _localStorageService.SetItemAsync(_key, pref);
        }

        public async Task ToggleColorMode(ColorTheme theme)
        {
            var pref = await GetPreferencesAsync();
            var suffix = "-theme";
            var color = theme.ToString().ToLower() + suffix;
            if(theme == ColorTheme.Blue)
            {
                color = string.Empty;
            }
            pref.Color = color;
            await _localStorageService.SetItemAsync(_key, pref);
        }

        public async Task<Preferences> GetPreferencesAsync()
        {
            return await _localStorageService.GetItemAsync<Preferences>(_key) ?? new();
        }
    }
}

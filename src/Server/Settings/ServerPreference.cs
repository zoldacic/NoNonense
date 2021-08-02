using System.Linq;
using NowWhat.Shared.Constants.Localization;
using NowWhat.Shared.Settings;

namespace NowWhat.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}
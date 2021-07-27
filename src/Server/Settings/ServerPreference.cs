using System.Linq;
using NoNonense.Shared.Constants.Localization;
using NoNonense.Shared.Settings;

namespace NoNonense.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}
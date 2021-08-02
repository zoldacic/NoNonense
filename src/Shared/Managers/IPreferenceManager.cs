using NowWhat.Shared.Settings;
using System.Threading.Tasks;
using NowWhat.Shared.Wrapper;

namespace NowWhat.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}
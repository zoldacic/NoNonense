using NoNonense.Shared.Settings;
using System.Threading.Tasks;
using NoNonense.Shared.Wrapper;

namespace NoNonense.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}
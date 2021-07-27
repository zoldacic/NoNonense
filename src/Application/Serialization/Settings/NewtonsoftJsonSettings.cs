
using NoNonense.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace NoNonense.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}
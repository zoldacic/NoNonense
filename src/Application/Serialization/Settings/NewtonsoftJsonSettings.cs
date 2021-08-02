
using NowWhat.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace NowWhat.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}
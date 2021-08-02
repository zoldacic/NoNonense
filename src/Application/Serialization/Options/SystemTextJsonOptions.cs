using System.Text.Json;
using NowWhat.Application.Interfaces.Serialization.Options;

namespace NowWhat.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}
using System.Text.Json;
using NoNonense.Application.Interfaces.Serialization.Options;

namespace NoNonense.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}
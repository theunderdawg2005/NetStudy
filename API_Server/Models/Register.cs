
using Microsoft.VisualBasic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API_Server.Models
{
    public class Register
    {
        public string? Name { get; set; }
        public string? Username { get; set; }

        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }   
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }

    public class JsonDateConverter : JsonConverter<DateTime>
    {
        private const string Format = "dd/MM/yyyy";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), Format, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }
}

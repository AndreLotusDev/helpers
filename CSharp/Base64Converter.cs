using System.Text.Json;
using System.Text.Json.Serialization;
public class Base64Converter : JsonConverter<object>
{
    //WIP
    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var value = reader.GetString();
            if (IsBase64String(value))
            {
                return value; 
            }
            return value;
        }

        if (reader.TokenType == JsonTokenType.StartObject)
        {
            var array = JsonSerializer.Deserialize<object[]>(ref reader, options);


        }

        try
        {
            return JsonSerializer.Deserialize<object>(ref reader);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }

    private static bool IsBase64String(string base64)
    {
        Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
        return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
    }
}

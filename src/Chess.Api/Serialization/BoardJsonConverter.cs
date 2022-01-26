// using System.Text.Json;
// using System.Text.Json.Serialization;
// using Chess.Game;

// namespace Chess.Api.Controllers;

// public class BoardJsonConverter : JsonConverter<Board>
// {
// 	public override Board Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
// 	{
// 		var boardJson = reader.GetString();
// 		return new Board();
// 	}

// 	public override void Write(Utf8JsonWriter writer, Board value, JsonSerializerOptions options)
// 	{
// 		writer.WriteStringValue(JsonSerializer.Serialize(value));
// 	}
// }

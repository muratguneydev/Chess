using System.Text.Json;
using System.Text.Json.Serialization;

namespace Chess.Api.Controllers;

public record SessionSerializable
{
	[JsonConstructor]
	public SessionSerializable(PlayerSerializable whitePlayer, PlayerSerializable blackPlayer,
		BoardSerializable board, SessionStateSerializable currentState, IEnumerable<MoveSerializable> moveHistory)
	{
		this.WhitePlayer = whitePlayer;
		this.BlackPlayer = blackPlayer;
		this.Board = board;
		this.CurrentState = currentState;
		MoveHistory = moveHistory;
	}

	public PlayerSerializable WhitePlayer { get; }
	public PlayerSerializable BlackPlayer { get; }
	public BoardSerializable Board { get; }
	public SessionStateSerializable CurrentState { get; }
	public IEnumerable<MoveSerializable> MoveHistory { get; }

	public async Task<string> Serialize()
	{
		string json = string.Empty;
		using (var stream = new MemoryStream())
		{
			await JsonSerializer.SerializeAsync(stream, this);
			stream.Position = 0;
			using var reader = new StreamReader(stream);
			json = await reader.ReadToEndAsync();
		}
		return json;
	}

	public static SessionSerializable DeSerialize(string serializedSession)
	{
		return JsonSerializer.Deserialize<SessionSerializable>(serializedSession);
	}
}

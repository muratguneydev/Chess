using System.Text.Json.Serialization;

namespace Chess.Api.Controllers;

public record SessionSerializable
{
	[JsonConstructor]
	public SessionSerializable(PlayerSerializable whitePlayer, PlayerSerializable blackPlayer,
		BoardSerializable board, SessionStateSerializable currentState)
	{
		this.WhitePlayer = whitePlayer;
		this.BlackPlayer = blackPlayer;
		this.Board = board;
		this.CurrentState = currentState;
	}

	public PlayerSerializable WhitePlayer { get; }
	public PlayerSerializable BlackPlayer { get; }
	public BoardSerializable Board { get; }
	public SessionStateSerializable CurrentState { get; }
}

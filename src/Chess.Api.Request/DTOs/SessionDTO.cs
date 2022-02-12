namespace Chess.Api.Request;

public record SessionDTO
{
	public SessionDTO(SessionIdDTO id, BoardDTO board,
		PlayerDTO whitePlayer, PlayerDTO blackPlayer, PlayerDTO currentPlayer, PlayerDTO waitingPlayer, SideColor playerTurnColor,
		IEnumerable<MoveDTO> moveHistory, string currentState, RequestResult lastRequestResult)
	{
		this.Id = id;
		this.Board = board;
		this.WhitePlayer = whitePlayer;
		this.BlackPlayer = blackPlayer;
		this.CurrentPlayer = currentPlayer;
		this.WaitingPlayer = waitingPlayer;
		this.PlayerTurnColor = playerTurnColor;
		this.MoveHistory = moveHistory;
		this.CurrentState = currentState;
		this.LastRequest = lastRequestResult;
	}

	public SessionIdDTO Id { get; }
	public BoardDTO Board { get; }
	public PlayerDTO WhitePlayer { get; }
	public PlayerDTO BlackPlayer { get; }
	public PlayerDTO CurrentPlayer { get; }
	public PlayerDTO WaitingPlayer { get; }
	public SideColor PlayerTurnColor { get; }
	public IEnumerable<MoveDTO> MoveHistory { get; }
	public string CurrentState { get; }
	public RequestResult LastRequest { get; }
}

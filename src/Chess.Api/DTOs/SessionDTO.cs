using Chess.Api.Requests;
using Chess.Game;

namespace Chess.Api.DTO;
public record SessionDTO
{
	private readonly Session session;
	private readonly PieceDTOFactory pieceDTOFactory;

	// public SessionDTO(Session session, SessionIdDTO id, PieceDTOFactory pieceDTOFactory)
	// {
	// 	this.session = session;
	// 	this.Id = id;
	// 	this.pieceDTOFactory = pieceDTOFactory;
	// 	this.LastRequest = new SuccessfulRequestResult(new CreateSessionRequest(new SessionId(id.Value)));
	// }

	public SessionDTO(Session session, SessionId id, PieceDTOFactory pieceDTOFactory, RequestResult lastRequestResult)
	{
		this.session = session;
		this.Id = new SessionIdDTO(id);
		this.pieceDTOFactory = pieceDTOFactory;
		this.LastRequest = lastRequestResult;
	}

	public BoardDTO Board => new BoardDTO(this.session.Board, this.pieceDTOFactory);
	public IEnumerable<MoveDTO> MoveHistory => this.session.MoveHistory.Select(move => new MoveDTO(move, this.pieceDTOFactory));
	public PlayerDTO WhitePlayer => new PlayerDTO(this.session.WhitePlayer);
	public PlayerDTO BlackPlayer => new PlayerDTO(this.session.BlackPlayer);
	public PlayerDTO CurrentPlayer => new PlayerDTO(this.session.CurrentPlayer);
	public PlayerDTO WaitingPlayer => new PlayerDTO(this.session.WaitingPlayer);
	public Color PlayTurnColor => this.session.PlayTurn;
	public string CurrentState => this.session.CurrentState.GetType().Name;
	public SessionIdDTO Id { get; }
	public RequestResult LastRequest { get; }
}

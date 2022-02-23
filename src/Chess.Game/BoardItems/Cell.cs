namespace Chess.Game;

public record Cell
{
	private readonly Board board;

	public Cell(Coordinate coordinate, Board board)
	{
		this.Coordinate = coordinate;
		this.board = board;
		this.Piece = EmptyBoardPiece.BoardPiece;
	}

	public Cell(int x, int y, Board board, IBoardPiece piece)
		: this(new Coordinate(x, y), board)
	{
		this.Piece = piece;
	}

	public Cell(int x, int y, Board board)
		: this(new Coordinate(x, y), board)
	{
		this.Piece = EmptyBoardPiece.BoardPiece;
	}

	public Coordinate Coordinate { get; }
	public int X => this.Coordinate.X;
	public int Y => this.Coordinate.Y;
	public IBoardPiece Piece { get; private set; }

	public bool IsOccupied => !this.Piece.IsEmpty;
	public bool IsEmpty => this is EmptyCell;

	public void SetPiece(IBoardPiece piece)
	{
		this.Piece = piece;
		this.Piece.RecordCurrentCellInHistory(this.Coordinate);
	}

	public void GoBack(IBoardPiece piece)
	{
		this.Piece = piece;
		this.Piece.PopLastCellFromHistory();
	}

	public virtual Move GetMove(Cell destinationCell)
	{
		var move = new Move(this, destinationCell);
		if (!this.Piece.CanMove(move))
	 		return new InvalidMove(this, destinationCell);

		if (this.Piece.GetMovePath(move).IsEnPassant && this.Piece.IsWhite)
			return new WhiteEnPassantMove(this, destinationCell);
		if (this.Piece.GetMovePath(move).IsEnPassant && this.Piece.IsBlack)
			return new BlackEnPassantMove(this, destinationCell);

		return move;
	}

	public override string ToString()
	{
		return $"{this.Piece.GetType().Name} {this.Coordinate}";
	}

	public virtual void MakeEmpty()
	{
		this.SetPiece(EmptyBoardPiece.BoardPiece);
	}

	public Cell GetCellOnSameBoard(int x, int y)
	{
		return this.board.GetCell(x, y);
	}

	public Cell GetCellOnSameBoard(Coordinate coordinate)
	{
		return this.GetCellOnSameBoard(coordinate.X, coordinate.Y);
	}

	// public Cell Copy()
	// {
	// 	return new Cell(this);
	// }
}

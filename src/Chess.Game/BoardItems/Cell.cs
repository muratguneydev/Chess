namespace Chess.Game;

public class Cell
{
	public Cell(Coordinate coordinate)
	{
		this.Coordinate = coordinate;
		this.Piece = EmptyBoardPiece.Piece;
	}

	public Cell(int x, int y)
	{
		this.Coordinate = new Coordinate(x, y);
		this.Piece = EmptyBoardPiece.Piece;
	}

	public int X => this.Coordinate.X;
	public int Y => this.Coordinate.Y;
	public IBoardPiece Piece { get; private set; }
	public Board Board => this.Piece.Board;

	public Coordinate Coordinate { get; }

	public bool IsOccupied => !this.Piece.IsEmpty;
	public bool IsEmpty => this is EmptyCell;

	public void SetPiece(IBoardPiece piece)
	{
		this.Piece = piece;
		this.Piece.RecordCurrentCellInHistory(this);
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

		if (this.Piece.GetMovePath(move).IsEnPassant)
			return new EnPassantMove(this, destinationCell);

		return move;
	}

	public override bool Equals(object? obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		
		var otherCell = (Cell)obj;
		return this.Coordinate == otherCell.Coordinate;
	}
	
	
	public override int GetHashCode()
	{
		return this.Coordinate.GetHashCode();
	}

	public override string ToString()
	{
		return $"{this.Piece.GetType().Name} {this.Coordinate}";
	}

	public virtual void MakeEmpty()
	{
		this.SetPiece(EmptyBoardPiece.Piece);
	}
}

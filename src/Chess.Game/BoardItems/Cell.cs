namespace Chess.Game;

public class Cell
{
	public Cell(Coordinate coordinate)
	{
		this.Coordinate = coordinate;
		this.Piece = EmptyBoardPiece.Piece;
	}

	public int X => this.Coordinate.X;
	public int Y => this.Coordinate.Y;
	public IBoardPiece Piece { get; private set; }

	public Coordinate Coordinate { get; }

	public bool IsOccupied => !this.Piece.IsEmpty;

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

	public virtual Move Move(Cell destinationCell)
	{
		if (!this.Piece.CanMove(this, destinationCell))
	 		return new InvalidMove(this, destinationCell);

		var move = new Move(this, destinationCell);
		destinationCell.SetPiece(this.Piece);
		this.MakeEmpty();
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

	private void MakeEmpty()
	{
		this.SetPiece(EmptyBoardPiece.Piece);
	}
}

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

	public void Initialize(IBoardPiece piece)
	{
		this.Piece = piece;
	}

	public void MakeEmpty()
	{
		this.Initialize(EmptyBoardPiece.Piece);
	}

	public virtual Move Move(Cell destinationCell)
	{
		return this.Piece.Move(destinationCell);
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
}

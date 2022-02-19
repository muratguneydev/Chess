namespace Chess.Game;

public record Board
{
	private readonly Cell[,] cells;

	public Board()
	{
		this.cells = this.CreateCells();
	}

	public Board(Cell[,] cellTable)
	{
		this.cells = new Cell[cellTable.GetUpperBound(0)+1, cellTable.GetUpperBound(1)+1];
		for (var x = 0; x <= cellTable.GetUpperBound(0); x++)
		{
			for (var y = 0; y <= cellTable.GetUpperBound(1); y++)
			{
				this.cells[x, y] = new Cell(x, y, this, cellTable[x, y].Piece);
			}
		}
	}

	public Cell EmptyCell => new EmptyCell(this);//return single instance per board?
	public Move EmptyMove => new EmptyMove(this);//return single instance per board?
	public int XSize => 8;
	public int YSize => 8;

	//for serialization
	public Cell[,] Cells => this.cells;

	public Cell a1 => cells[0, 0];
	public Cell b1 => cells[1, 0];
	public Cell c1 => cells[2, 0];
	public Cell d1 => cells[3, 0];
	public Cell e1 => cells[4, 0];
	public Cell f1 => cells[5, 0];
	public Cell g1 => cells[6, 0];
	public Cell h1 => cells[7, 0];

	public Cell a2 => cells[0, 1];
	public Cell b2 => cells[1, 1];
	public Cell c2 => cells[2, 1];
	public Cell d2 => cells[3, 1];
	public Cell e2 => cells[4, 1];
	public Cell f2 => cells[5, 1];
	public Cell g2 => cells[6, 1];
	public Cell h2 => cells[7, 1];

	public Cell a3 => cells[0, 2];
	public Cell b3 => cells[1, 2];
	public Cell c3 => cells[2, 2];
	public Cell d3 => cells[3, 2];
	public Cell e3 => cells[4, 2];
	public Cell f3 => cells[5, 2];
	public Cell g3 => cells[6, 2];
	public Cell h3 => cells[7, 2];

	public Cell a4 => cells[0, 3];
	public Cell b4 => cells[1, 3];
	public Cell c4 => cells[2, 3];
	public Cell d4 => cells[3, 3];
	public Cell e4 => cells[4, 3];
	public Cell f4 => cells[5, 3];
	public Cell g4 => cells[6, 3];
	public Cell h4 => cells[7, 3];
	
	public Cell a5 => cells[0, 4];
	public Cell b5 => cells[1, 4];
	public Cell c5 => cells[2, 4];
	public Cell d5 => cells[3, 4];
	public Cell e5 => cells[4, 4];
	public Cell f5 => cells[5, 4];
	public Cell g5 => cells[6, 4];
	public Cell h5 => cells[7, 4];


	public Cell a6 => cells[0, 5];
	public Cell b6 => cells[1, 5];
	public Cell c6 => cells[2, 5];
	public Cell d6 => cells[3, 5];
	public Cell e6 => cells[4, 5];
	public Cell f6 => cells[5, 5];
	public Cell g6 => cells[6, 5];
	public Cell h6 => cells[7, 5];

	public Cell a7 => cells[0, 6];
	public Cell b7 => cells[1, 6];
	public Cell c7 => cells[2, 6];
	public Cell d7 => cells[3, 6];
	public Cell e7 => cells[4, 6];
	public Cell f7 => cells[5, 6];
	public Cell g7 => cells[6, 6];
	public Cell h7 => cells[7, 6];

	public Cell a8 => cells[0, 7];
	public Cell b8 => cells[1, 7];
	public Cell c8 => cells[2, 7];
	public Cell d8 => cells[3, 7];
	public Cell e8 => cells[4, 7];
	public Cell f8 => cells[5, 7];
	public Cell g8 => cells[6, 7];
	public Cell h8 => cells[7, 7];

	public void SetOpeningPosition()
	{
		this.a1.SetPiece(new WhitePieceDecorator(new Rook(), new CellHistory()));
		this.b1.SetPiece(new WhitePieceDecorator(new Knight(), new CellHistory()));
		this.c1.SetPiece(new WhitePieceDecorator(new Bishop(), new CellHistory()));
		this.d1.SetPiece(new WhitePieceDecorator(new Queen(), new CellHistory()));
		this.e1.SetPiece(new WhitePieceDecorator(new King(), new CellHistory()));
		this.f1.SetPiece(new WhitePieceDecorator(new Bishop(), new CellHistory()));
		this.g1.SetPiece(new WhitePieceDecorator(new Knight(), new CellHistory()));
		this.h1.SetPiece(new WhitePieceDecorator(new Rook(), new CellHistory()));

		this.a2.SetPiece(new WhitePieceDecorator(new WhitePawn(), new CellHistory()));
		this.b2.SetPiece(new WhitePieceDecorator(new WhitePawn(), new CellHistory()));
		this.c2.SetPiece(new WhitePieceDecorator(new WhitePawn(), new CellHistory()));
		this.d2.SetPiece(new WhitePieceDecorator(new WhitePawn(), new CellHistory()));
		this.e2.SetPiece(new WhitePieceDecorator(new WhitePawn(), new CellHistory()));
		this.f2.SetPiece(new WhitePieceDecorator(new WhitePawn(), new CellHistory()));
		this.g2.SetPiece(new WhitePieceDecorator(new WhitePawn(), new CellHistory()));
		this.h2.SetPiece(new WhitePieceDecorator(new WhitePawn(), new CellHistory()));

		this.a7.SetPiece(new BlackPieceDecorator(new BlackPawn(), new CellHistory()));
		this.b7.SetPiece(new BlackPieceDecorator(new BlackPawn(), new CellHistory()));
		this.c7.SetPiece(new BlackPieceDecorator(new BlackPawn(), new CellHistory()));
		this.d7.SetPiece(new BlackPieceDecorator(new BlackPawn(), new CellHistory()));
		this.e7.SetPiece(new BlackPieceDecorator(new BlackPawn(), new CellHistory()));
		this.f7.SetPiece(new BlackPieceDecorator(new BlackPawn(), new CellHistory()));
		this.g7.SetPiece(new BlackPieceDecorator(new BlackPawn(), new CellHistory()));
		this.h7.SetPiece(new BlackPieceDecorator(new BlackPawn(), new CellHistory()));

		this.a8.SetPiece(new BlackPieceDecorator(new Rook(), new CellHistory()));
		this.b8.SetPiece(new BlackPieceDecorator(new Knight(), new CellHistory()));
		this.c8.SetPiece(new BlackPieceDecorator(new Bishop(), new CellHistory()));
		this.d8.SetPiece(new BlackPieceDecorator(new Queen(), new CellHistory()));
		this.e8.SetPiece(new BlackPieceDecorator(new King(), new CellHistory()));
		this.f8.SetPiece(new BlackPieceDecorator(new Bishop(), new CellHistory()));
		this.g8.SetPiece(new BlackPieceDecorator(new Knight(), new CellHistory()));
		this.h8.SetPiece(new BlackPieceDecorator(new Rook(), new CellHistory()));
	}

	public IEnumerable<IBoardPiece> GetPiecesInCoordinates(IEnumerable<Coordinate> coordinates)
	{
		return coordinates
			.Select(coordinate => this.cells[coordinate.X, coordinate.Y].Piece)
			.Where(piece => !piece.IsEmpty);
	}

	public Cell GetCell(int x, int y)
	{
		if (x >= this.XSize || x < 0 || y >= this.YSize || y < 0)
			return this.EmptyCell;
		return this.cells[x, y];
	}
	
	// private Cell[,] CreateCells(Cell[,] cells)
	// {
	// 	var table = new Cell[XSize, YSize];


	// 	return new [,]
	// 		{
	// 			{new Cell(new Coordinate(0, 0), this), new Cell(new Coordinate(0, 1), this), new Cell(new Coordinate(0, 2), this), new Cell(new Coordinate(0, 3), this), new Cell(new Coordinate(0, 4), this), new Cell(new Coordinate(0, 5), this), new Cell(new Coordinate(0, 6), this), new Cell(new Coordinate(0, 7), this)},
	// 			{new Cell(new Coordinate(1, 0), this), new Cell(new Coordinate(1, 1), this), new Cell(new Coordinate(1, 2), this), new Cell(new Coordinate(1, 3), this), new Cell(new Coordinate(1, 4), this), new Cell(new Coordinate(1, 5), this), new Cell(new Coordinate(1, 6), this), new Cell(new Coordinate(1, 7), this)},
	// 			{new Cell(new Coordinate(2, 0), this), new Cell(new Coordinate(2, 1), this), new Cell(new Coordinate(2, 2), this), new Cell(new Coordinate(2, 3), this), new Cell(new Coordinate(2, 4), this), new Cell(new Coordinate(2, 5), this), new Cell(new Coordinate(2, 6), this), new Cell(new Coordinate(2, 7), this)},
	// 			{new Cell(new Coordinate(3, 0), this), new Cell(new Coordinate(3, 1), this), new Cell(new Coordinate(3, 2), this), new Cell(new Coordinate(3, 3), this), new Cell(new Coordinate(3, 4), this), new Cell(new Coordinate(3, 5), this), new Cell(new Coordinate(3, 6), this), new Cell(new Coordinate(3, 7), this)},
	// 			{new Cell(new Coordinate(4, 0), this), new Cell(new Coordinate(4, 1), this), new Cell(new Coordinate(4, 2), this), new Cell(new Coordinate(4, 3), this), new Cell(new Coordinate(4, 4), this), new Cell(new Coordinate(4, 5), this), new Cell(new Coordinate(4, 6), this), new Cell(new Coordinate(4, 7), this)},
	// 			{new Cell(new Coordinate(5, 0), this), new Cell(new Coordinate(5, 1), this), new Cell(new Coordinate(5, 2), this), new Cell(new Coordinate(5, 3), this), new Cell(new Coordinate(5, 4), this), new Cell(new Coordinate(5, 5), this), new Cell(new Coordinate(5, 6), this), new Cell(new Coordinate(5, 7), this)},
	// 			{new Cell(new Coordinate(6, 0), this), new Cell(new Coordinate(6, 1), this), new Cell(new Coordinate(6, 2), this), new Cell(new Coordinate(6, 3), this), new Cell(new Coordinate(6, 4), this), new Cell(new Coordinate(6, 5), this), new Cell(new Coordinate(6, 6), this), new Cell(new Coordinate(6, 7), this)},
	// 			{new Cell(new Coordinate(7, 0), this), new Cell(new Coordinate(7, 1), this), new Cell(new Coordinate(7, 2), this), new Cell(new Coordinate(7, 3), this), new Cell(new Coordinate(7, 4), this), new Cell(new Coordinate(7, 5), this), new Cell(new Coordinate(7, 6), this), new Cell(new Coordinate(7, 7), this)}
	// 		};
	// }

	private Cell[,] CreateCells()
	{
		return new [,]
			{
				{new Cell(new Coordinate(0, 0), this), new Cell(new Coordinate(0, 1), this), new Cell(new Coordinate(0, 2), this), new Cell(new Coordinate(0, 3), this), new Cell(new Coordinate(0, 4), this), new Cell(new Coordinate(0, 5), this), new Cell(new Coordinate(0, 6), this), new Cell(new Coordinate(0, 7), this)},
				{new Cell(new Coordinate(1, 0), this), new Cell(new Coordinate(1, 1), this), new Cell(new Coordinate(1, 2), this), new Cell(new Coordinate(1, 3), this), new Cell(new Coordinate(1, 4), this), new Cell(new Coordinate(1, 5), this), new Cell(new Coordinate(1, 6), this), new Cell(new Coordinate(1, 7), this)},
				{new Cell(new Coordinate(2, 0), this), new Cell(new Coordinate(2, 1), this), new Cell(new Coordinate(2, 2), this), new Cell(new Coordinate(2, 3), this), new Cell(new Coordinate(2, 4), this), new Cell(new Coordinate(2, 5), this), new Cell(new Coordinate(2, 6), this), new Cell(new Coordinate(2, 7), this)},
				{new Cell(new Coordinate(3, 0), this), new Cell(new Coordinate(3, 1), this), new Cell(new Coordinate(3, 2), this), new Cell(new Coordinate(3, 3), this), new Cell(new Coordinate(3, 4), this), new Cell(new Coordinate(3, 5), this), new Cell(new Coordinate(3, 6), this), new Cell(new Coordinate(3, 7), this)},
				{new Cell(new Coordinate(4, 0), this), new Cell(new Coordinate(4, 1), this), new Cell(new Coordinate(4, 2), this), new Cell(new Coordinate(4, 3), this), new Cell(new Coordinate(4, 4), this), new Cell(new Coordinate(4, 5), this), new Cell(new Coordinate(4, 6), this), new Cell(new Coordinate(4, 7), this)},
				{new Cell(new Coordinate(5, 0), this), new Cell(new Coordinate(5, 1), this), new Cell(new Coordinate(5, 2), this), new Cell(new Coordinate(5, 3), this), new Cell(new Coordinate(5, 4), this), new Cell(new Coordinate(5, 5), this), new Cell(new Coordinate(5, 6), this), new Cell(new Coordinate(5, 7), this)},
				{new Cell(new Coordinate(6, 0), this), new Cell(new Coordinate(6, 1), this), new Cell(new Coordinate(6, 2), this), new Cell(new Coordinate(6, 3), this), new Cell(new Coordinate(6, 4), this), new Cell(new Coordinate(6, 5), this), new Cell(new Coordinate(6, 6), this), new Cell(new Coordinate(6, 7), this)},
				{new Cell(new Coordinate(7, 0), this), new Cell(new Coordinate(7, 1), this), new Cell(new Coordinate(7, 2), this), new Cell(new Coordinate(7, 3), this), new Cell(new Coordinate(7, 4), this), new Cell(new Coordinate(7, 5), this), new Cell(new Coordinate(7, 6), this), new Cell(new Coordinate(7, 7), this)}
			};
	}
}

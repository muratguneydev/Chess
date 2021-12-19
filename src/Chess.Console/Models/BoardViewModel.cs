using Chess.Game;

namespace Chess.Console;

public class BoardViewModel
{
	private readonly Board board;

	public BoardViewModel(Board board)
	{
		this.board = board;
	}

	public BoardCellViewModel[,] BoardCellViewModelTable => this.PopulateBoardCellViewModelTable();

	public Cell GetCell(string cellName)
	{
		if (cellName.Length != 2)
			throw new InvalidCellNameException(cellName);
		var xName = cellName[0];
		var yName = cellName[1];

		if (xName < 97 || xName > 104) //a -> h
			throw new InvalidCellNameException(cellName);
		if (yName < 49 || yName > 56) //1 -> 8
			throw new InvalidCellNameException(cellName);

		var x = xName - 97;
		var y = yName - 49;
		return this.BoardCellViewModelTable[x, y].Cell;//try to optimize this. this triggers table build every time.
	}

	public string GetCellName(Cell cell)
	{
		return $"{(char)(cell.Coordinate.X+97)}{cell.Coordinate.Y+1}";
	}

	private BoardCellViewModel[,] PopulateBoardCellViewModelTable()
	{
		var boardCellViewModelTable = new BoardCellViewModel[this.board.XSize,this.board.YSize];
		for (var x=0;x < this.board.XSize;x++)
		{
			for (var y=0;y < this.board.YSize;y++)
			{
				boardCellViewModelTable[x,y] = new BoardCellViewModel(this.board.GetCell(x,y));
			}
		}

		return boardCellViewModelTable;
	}



	// private void InitializeBoardCellMapping()
	// {
	// 	this.boardCellMapping.Add(nameof(this.board.a1), this.boardCellViewModelTable[0,0]);
	// 	this.boardCellMapping.Add(nameof(this.board.b1), this.boardCellViewModelTable[1,0]);
	// 	this.boardCellMapping.Add(nameof(this.board.c1), this.boardCellViewModelTable[2,0]);
	// 	this.boardCellMapping.Add(nameof(this.board.d1), this.boardCellViewModelTable[3,0]);
	// 	this.boardCellMapping.Add(nameof(this.board.e1), this.boardCellViewModelTable[4,0]);
	// 	this.boardCellMapping.Add(nameof(this.board.f1), this.boardCellViewModelTable[5,0]);
	// 	this.boardCellMapping.Add(nameof(this.board.g1), this.boardCellViewModelTable[6,0]);
	// 	this.boardCellMapping.Add(nameof(this.board.h1), this.boardCellViewModelTable[7,0]);
	// 	this.boardCellMapping.Add(nameof(this.board.a2), this.boardCellViewModelTable[0,1]);
	// 	this.boardCellMapping.Add(nameof(this.board.b2), this.boardCellViewModelTable[1,1]);
	// 	this.boardCellMapping.Add(nameof(this.board.c2), this.boardCellViewModelTable[2,1]);
	// 	this.boardCellMapping.Add(nameof(this.board.d2), this.boardCellViewModelTable[3,1]);
	// 	this.boardCellMapping.Add(nameof(this.board.e2), this.boardCellViewModelTable[4,1]);
	// 	this.boardCellMapping.Add(nameof(this.board.f2), this.boardCellViewModelTable[5,1]);
	// 	this.boardCellMapping.Add(nameof(this.board.g2), this.boardCellViewModelTable[6,1]);
	// 	this.boardCellMapping.Add(nameof(this.board.h2), this.boardCellViewModelTable[7,1]);
	// 	this.boardCellMapping.Add(nameof(this.board.a3), this.boardCellViewModelTable[0,2]);
	// 	this.boardCellMapping.Add(nameof(this.board.b3), this.boardCellViewModelTable[1,2]);
	// 	this.boardCellMapping.Add(nameof(this.board.c3), this.boardCellViewModelTable[2,2]);
	// 	this.boardCellMapping.Add(nameof(this.board.d3), this.boardCellViewModelTable[3,2]);
	// 	this.boardCellMapping.Add(nameof(this.board.e3), this.boardCellViewModelTable[4,2]);
	// 	this.boardCellMapping.Add(nameof(this.board.f3), this.boardCellViewModelTable[5,2]);
	// 	this.boardCellMapping.Add(nameof(this.board.g3), this.boardCellViewModelTable[6,2]);
	// 	this.boardCellMapping.Add(nameof(this.board.h3), this.boardCellViewModelTable[7,2]);
	// 	this.boardCellMapping.Add(nameof(this.board.a4), this.boardCellViewModelTable[0,3]);
	// 	this.boardCellMapping.Add(nameof(this.board.b4), this.boardCellViewModelTable[1,3]);
	// 	this.boardCellMapping.Add(nameof(this.board.c4), this.boardCellViewModelTable[2,3]);
	// 	this.boardCellMapping.Add(nameof(this.board.d4), this.boardCellViewModelTable[3,3]);
	// 	this.boardCellMapping.Add(nameof(this.board.e4), this.boardCellViewModelTable[4,3]);
	// 	this.boardCellMapping.Add(nameof(this.board.f4), this.boardCellViewModelTable[5,3]);
	// 	this.boardCellMapping.Add(nameof(this.board.g4), this.boardCellViewModelTable[6,3]);
	// 	this.boardCellMapping.Add(nameof(this.board.h4), this.boardCellViewModelTable[7,3]);
	// 	this.boardCellMapping.Add(nameof(this.board.a5), this.boardCellViewModelTable[0,4]);
	// 	this.boardCellMapping.Add(nameof(this.board.b5), this.boardCellViewModelTable[1,4]);
	// 	this.boardCellMapping.Add(nameof(this.board.c5), this.boardCellViewModelTable[2,4]);
	// 	this.boardCellMapping.Add(nameof(this.board.d5), this.boardCellViewModelTable[3,4]);
	// 	this.boardCellMapping.Add(nameof(this.board.e5), this.boardCellViewModelTable[4,4]);
	// 	this.boardCellMapping.Add(nameof(this.board.f5), this.boardCellViewModelTable[5,4]);
	// 	this.boardCellMapping.Add(nameof(this.board.g5), this.boardCellViewModelTable[6,4]);
	// 	this.boardCellMapping.Add(nameof(this.board.h5), this.boardCellViewModelTable[7,4]);
	// 	this.boardCellMapping.Add(nameof(this.board.a6), this.boardCellViewModelTable[0,5]);
	// 	this.boardCellMapping.Add(nameof(this.board.b6), this.boardCellViewModelTable[1,5]);
	// 	this.boardCellMapping.Add(nameof(this.board.c6), this.boardCellViewModelTable[2,5]);
	// 	this.boardCellMapping.Add(nameof(this.board.d6), this.boardCellViewModelTable[3,5]);
	// 	this.boardCellMapping.Add(nameof(this.board.e6), this.boardCellViewModelTable[4,5]);
	// 	this.boardCellMapping.Add(nameof(this.board.f6), this.boardCellViewModelTable[5,5]);
	// 	this.boardCellMapping.Add(nameof(this.board.g6), this.boardCellViewModelTable[6,5]);
	// 	this.boardCellMapping.Add(nameof(this.board.h6), this.boardCellViewModelTable[7,5]);
	// 	this.boardCellMapping.Add(nameof(this.board.a7), this.boardCellViewModelTable[0,6]);
	// 	this.boardCellMapping.Add(nameof(this.board.b7), this.boardCellViewModelTable[1,6]);
	// 	this.boardCellMapping.Add(nameof(this.board.c7), this.boardCellViewModelTable[2,6]);
	// 	this.boardCellMapping.Add(nameof(this.board.d7), this.boardCellViewModelTable[3,6]);
	// 	this.boardCellMapping.Add(nameof(this.board.e7), this.boardCellViewModelTable[4,6]);
	// 	this.boardCellMapping.Add(nameof(this.board.f7), this.boardCellViewModelTable[5,6]);
	// 	this.boardCellMapping.Add(nameof(this.board.g7), this.boardCellViewModelTable[6,6]);
	// 	this.boardCellMapping.Add(nameof(this.board.h7), this.boardCellViewModelTable[7,6]);
	// 	this.boardCellMapping.Add(nameof(this.board.a8), this.boardCellViewModelTable[0,7]);
	// 	this.boardCellMapping.Add(nameof(this.board.b8), this.boardCellViewModelTable[1,7]);
	// 	this.boardCellMapping.Add(nameof(this.board.c8), this.boardCellViewModelTable[2,7]);
	// 	this.boardCellMapping.Add(nameof(this.board.d8), this.boardCellViewModelTable[3,7]);
	// 	this.boardCellMapping.Add(nameof(this.board.e8), this.boardCellViewModelTable[4,7]);
	// 	this.boardCellMapping.Add(nameof(this.board.f8), this.boardCellViewModelTable[5,7]);
	// 	this.boardCellMapping.Add(nameof(this.board.g8), this.boardCellViewModelTable[6,7]);
	// 	this.boardCellMapping.Add(nameof(this.board.h8), this.boardCellViewModelTable[7,7]);
	// }
}

// public class ConsoleCellAdapter
// {
	
// }
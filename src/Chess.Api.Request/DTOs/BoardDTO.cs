namespace Chess.Api.Request;

public record BoardDTO
{
	public BoardDTO(IEnumerable<CellDTO> cells)
	{
		this.Cells = cells;
	}

	public IEnumerable<CellDTO> Cells { get; }
}


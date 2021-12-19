namespace Chess.Game
{
	public class YDirection
	{
		private readonly int plusOrMinusOne;

		public YDirection(int plusOrMinusOne)
		{
			if (plusOrMinusOne != 1 && plusOrMinusOne != -1)
				throw new ArgumentException($"{nameof(plusOrMinusOne)} should be 1 or -1.");

			this.plusOrMinusOne = plusOrMinusOne;
		}

		public int GetYCoordinate(int y) => y + this.plusOrMinusOne;
		
	}

	public class BlackYDirection : YDirection
	{
		public BlackYDirection() : base(-1)
		{
		}
	}

	public class WhiteYDirection : YDirection
	{
		public WhiteYDirection() : base(1)
		{
		}
	}
}
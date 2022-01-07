namespace Chess.Game;

[System.Serializable]
public class InvalidTakeBackMoveException : System.Exception
{
	public InvalidTakeBackMoveException() : base("Invalid take back requested.") { }
}
namespace Chess.Game;

public enum SessionStateTransitionCommand
{
	RegisterBlack,
	RegisterWhite,
	ReadyBlack,
	ReadyWhite,
	MoveWhite,
	MoveBlack,
	Exit
}

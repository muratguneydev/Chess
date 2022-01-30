namespace Chess.Game;

public class DateTimeProvider
{
	public virtual DateTime UtcNow => DateTime.UtcNow;
	public virtual TimeSpan ElapsedSince(DateTime dateTime) => DateTime.UtcNow.Subtract(dateTime);
}
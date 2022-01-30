namespace Chess.Game.Tests.Helpers;

public class TestDateTimeProvider : DateTimeProvider
{
	private readonly DateTime utcNow;
	private readonly Func<DateTime, TimeSpan> elapsedSince;

	public TestDateTimeProvider(DateTime? utcNow = null, Func<DateTime,TimeSpan>? elapsedSince = null)
	{
		this.utcNow = utcNow ?? DateTime.UtcNow;
		this.elapsedSince = elapsedSince ?? (startDateTime => new DateTimeProvider().ElapsedSince(startDateTime));
	}
	public override DateTime UtcNow => this.utcNow;

	public override TimeSpan ElapsedSince(DateTime dateTime) => this.elapsedSince(dateTime);
}
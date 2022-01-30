namespace Chess.Game;

public class Clock : IClock
{
	private readonly DateTimeProvider dateTimeProvider;

	public Clock(DateTimeProvider dateTimeProvider)
	{
		this.PreviousElapsedTime = TimeSpan.Zero;
		this.dateTimeProvider = dateTimeProvider;
		this.StartDateTimeUtc = dateTimeProvider.UtcNow;
	}

	public Clock(TimeSpan previousElapsedTime, DateTime startDateTimeUtc, bool ticking, DateTimeProvider dateTimeProvider)
	{
		this.PreviousElapsedTime = previousElapsedTime;
		this.StartDateTimeUtc = startDateTimeUtc;
		this.Ticking = ticking;
		this.dateTimeProvider = dateTimeProvider;
	}

	public void Start()
	{
		this.Ticking = true;
		this.StartDateTimeUtc = this.dateTimeProvider.UtcNow;
	}

	public void Stop()
	{
		this.PreviousElapsedTime = this.PreviousElapsedTime + this.dateTimeProvider.ElapsedSince(this.StartDateTimeUtc);
		this.Ticking = false;
	}

	public bool Ticking { get; private set; }
	public TimeSpan PreviousElapsedTime { get; private set; }
	public DateTime StartDateTimeUtc { get; private set; }
	public TimeSpan CurrentElapsedTime => this.PreviousElapsedTime + (!this.Ticking ? TimeSpan.Zero : this.dateTimeProvider.ElapsedSince(this.StartDateTimeUtc));
}

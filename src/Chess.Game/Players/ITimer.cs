namespace Chess.Game
{
	public interface ITimer : IDisposable
	{
		void Start();
		void Stop();
	}
}
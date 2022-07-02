namespace Pacman.Code;

public interface IThreadSleeper
{
    public void Sleep(int sleepLength);
}

public class ThreadSleeper : IThreadSleeper
{
    public void Sleep(int sleepLength) => Thread.Sleep(sleepLength);
}
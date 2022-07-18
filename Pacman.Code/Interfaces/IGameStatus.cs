namespace Pacman.Code;

public interface IGameStatus
{
    public int CurrentScore { get; set; }
    public List<string> LivesList { get; set; }
    public bool GodMode { get; set; }
    bool FreezeMode { get; set; }
}
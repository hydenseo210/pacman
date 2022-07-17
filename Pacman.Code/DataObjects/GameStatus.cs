namespace Pacman.Code;

public class GameStatus : IGameStatus
{
    public int CurrentScore { get; set; } = 0;
    public List<string> LivesList { get; set; } = Emojis.DefaultLivesList;
    public bool GodMode { get; set; } = false;
}
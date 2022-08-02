namespace Pacman.Code;

public interface IPrinter
{
    public void WonMessage();
    public void PacmanMessage();
    public void GameOverMessage();
    public void LevelOneCompleteMessage();
    public void DashBoard();
    public void StartMessage();
    public void UpdateGame(IMap map, IGameStatus gameStatus);
    public void PrintGrid();
    public void PrintGameConsole();
}
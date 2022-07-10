namespace Pacman.Code;

public static class Printer
{
    public static void GameOverMessage(IConsoleWrapper _console) => _console.Write(Messages.GameOverMessage);
    public static void StartMessage(IConsoleWrapper _console)
    {
        foreach (var message in Messages.StartMessage)
        {
            Print();
            _console.Write(message);
            Thread.Sleep(2000);
        }
            
        Print();
    }
    private void DashBoard() => _console.Write(Messages.DashBoardMessage(_gameState.CurrentScore, _gameState.TotalScore, _gameState.LivesList));
    private void PacmanMessage() => _console.Write(Messages.Pacman);
}
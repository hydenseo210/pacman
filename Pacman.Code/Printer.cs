namespace Pacman.Code;

public class Printer : IPrinter
{
    private readonly IGameStatus _gameStatus;
    private readonly IMap _map;
    private readonly IConsoleWrapper _console;
    private readonly IThreadSleeper _thread;

    public Printer(IGameStatus gameStatus, IMap map, IConsoleWrapper console, IThreadSleeper _thread)
    {
        _gameStatus = gameStatus;
        _map = map;
        _console = console;
        this._thread = _thread;
    }
    
    public void WonMessage() => _console.Write(Messages.WonMessage);
    public void PacmanMessage() => _console.Write(Messages.Pacman);
    public void GameOverMessage() => _console.Write(Messages.GameOverMessage);
    public void LevelOneCompleteMessage() => _console.Write(Messages.LevelOneMessage); // _threadSleeper.Sleep(2000)
    public void DashBoard() => _console.Write(Messages.DashBoardMessage(_gameStatus.CurrentScore, _map.TotalScore, _gameStatus.LivesList));

    public void StartMessage()
        {
            foreach (var message in Messages.StartMessage)
            {
                PrintGrid();
                _console.Write(message);
                _thread.Sleep(2000);
            }
            PrintGrid();
        }
    public void PrintGrid()
    {
        
        for (var x = 0; x < _map.Height; x++)
        {
            var row = "";
            for (var y = 0; y < _map.Width; y++)
            {
                var coordinate = new Coordinate(x, y);
                var cell = _map.Grid[coordinate].Print();
                row += cell;
            }
            _console.Write(row);
            _console.Write("\n");
        }
    }

    public void PrintGameConsole()
    {
        PacmanMessage();
        PrintGrid();
        DashBoard();
    }
        
        
    
    
}
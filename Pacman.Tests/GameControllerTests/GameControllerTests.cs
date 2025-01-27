namespace Pacman.Tests;

public class GameControllerTests
{
    [Fact]
    public void When_Pacman_Eats_All_The_Pellets_GameState_Is_Changed_To_The_Next_GameState_In_Queue()
    {
        var actualMap = GameDownload.DownloadMapFromFile("../../../GameControllerTests/gameControllerTestMap.txt");
        var expectedMap = GameDownload.DownloadMapFromFile("../../../GameControllerTests/gameControllerTestMap2.txt");
        var mapQueue = new Queue<IMap>(); 
        mapQueue.Enqueue(expectedMap);
        var console = new ConsoleWrapperStub(
                new List<ConsoleKey>
                {
                    ConsoleKey.RightArrow,
                    ConsoleKey.RightArrow,
                    ConsoleKey.RightArrow,
                    ConsoleKey.Q,
                    
                });
        var gameStatus = new GameStatus();
        var pacmanController = new PacmanController();
        var ghostController = new GhostController();
        var thread = new TestThreadSleeper();
        var printer = new Printer(gameStatus, actualMap, console, thread);
        var game = new Game(gameStatus, actualMap, mapQueue, pacmanController, ghostController);
        GameController.Run(game, console, thread, printer);
        
        
        Assert.True(mapQueue.Count == 0);
    }
    
    [Fact]
    public void When_Pacman_Eats_All_The_Pellets_And_It_Is_The_Last_Level_Game_Ends_And_GameState_IsWon_Set_To_True()
    {
        var actualMap = GameDownload.DownloadMapFromFile("../../../GameControllerTests/gameControllerTestMap.txt");
        var mapQueue = new Queue<IMap>();
        var console = new ConsoleWrapperStub(
            new List<ConsoleKey>
            {
                ConsoleKey.RightArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.Q,
                    
            });
        var gameStatus = new GameStatus();
        var pacmanController = new PacmanController();
        var ghostController = new GhostController();
        var thread = new TestThreadSleeper();
        var printer = new Printer(gameStatus, actualMap, console, thread);
        var game = new Game(gameStatus, actualMap, mapQueue, pacmanController, ghostController);
        GameController.Run(game, console, thread, printer);
        
        Assert.True(game.IsLastLevel() && game.IsWon());
    }
    
    [Fact]
    public void When_Pacman_Loses_All_Lives_Game_Is_Lost_And_IsGameOver_Returns_True()
    {
        var actualMap = GameDownload.DownloadMapFromFile("../../../GameControllerTests/gameControllerTestMap3.txt");
        var mapQueue = new Queue<IMap>();
        var console = new ConsoleWrapperStub(
            new List<ConsoleKey>
            {
                ConsoleKey.RightArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.Q,
                    
            });
        var gameStatus = new GameStatus();
        gameStatus.LivesList = Stub.ListOfOneLife;
        var pacmanController = new PacmanController();
        var ghostController = new GhostController();
        var thread = new TestThreadSleeper();
        var printer = new Printer(gameStatus, actualMap, console, thread);
        var game = new Game(gameStatus, actualMap, mapQueue, pacmanController, ghostController);
        GameController.Run(game, console, thread, printer);
        
        
        Assert.True(game.IsGameOver());
        //test
    }

}

public class TestThreadSleeper : IThreadSleeper
{
    public void Sleep(int sleepLength) => Thread.Sleep(0);
}

public class ConsoleWrapperStub : IConsoleWrapper
{
    private IList<ConsoleKey> keyCollection;
    private int keyIndex;

    public ConsoleWrapperStub(IList<ConsoleKey> keyCollection)
    {
        this.keyCollection = keyCollection;
    }

    public string winMessage = string.Empty;
    public string GameOverMessage = string.Empty;

    public ConsoleKeyInfo ReadKey()
    {
        var result = keyCollection[keyIndex];
        keyIndex++;
        return new ConsoleKeyInfo((char)result, result, false, false, false);
    }

    public void Write(string data)
    {
        if (data == Messages.WonMessage) winMessage += data;
        if (data == Messages.GameOverMessage) GameOverMessage += data;
    }

    public string? Read()
    {
        return Console.ReadLine();
    }

    public bool KeyAvailable => true;
}
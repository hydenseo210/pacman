namespace Pacman.Code;

public static class Program
{
    public static void Main(string[] args)
    {
         var currentGameState = GameDownload.DownloadMapFromFile("../../../Assets/Maps/LevelOneMap.txt");
         var gameStateQueue = new Queue<IMap>();
         var nextGameState = GameDownload.DownloadMapFromFile("../../../Assets/Maps/LevelTwoMap.txt");
         gameStateQueue.Enqueue(nextGameState);
         var console = new ConsoleWrapper();
         var gameStatus = new GameStatus();
         var thread = new ThreadSleeper();
         var printer = new Printer(gameStatus, currentGameState, console, thread);
         var pacmanController = new PacmanController();
         var ghostController = new GhostController(new Blinky(new AggressiveBehaviour()), new Pinky(new AggressiveBehaviour()));
         var game = new Game(gameStatus, currentGameState, gameStateQueue, pacmanController, ghostController);
         GameController.Run(game, console, thread, printer);
    }
}
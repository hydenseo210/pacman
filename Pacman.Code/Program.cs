namespace Pacman.Code;

public static class Program
{
    public static void Main(string[] args)
    {
         var currentMap = GameDownload.DownloadMapFromFile("../../../Assets/Maps/LevelOneMap.txt");
         var mapQueue = new Queue<IMap>();
         var nextMap = GameDownload.DownloadMapFromFile("../../../Assets/Maps/LevelTwoMap.txt");
         mapQueue.Enqueue(nextMap);
         var console = new ConsoleWrapper();
         var gameStatus = new GameStatus();
         var thread = new ThreadSleeper();
         var printer = new Printer(gameStatus, currentMap, console, thread);
         var pacmanController = new PacmanController();
         var ghostController = new GhostController();
         var game = new Game(gameStatus, currentMap, mapQueue, pacmanController, ghostController);
         GameController.Run(game, console, thread, printer);
    }
}
namespace Pacman.Code;

public static class Program
{
    public static void Main(string[] args)
    {
         var currentGameState = new GameDownload().DownloadGameStateFromFile("../../../GameState/LevelOneMap.txt");
        var testGameState = new GameDownload().DownloadGameStateFromFile("../../../GameState/test.txt");
         //var currentGameState = new GameDownload().DownloadGameStateFromFile("../../../GameState/LevelOneMapOnlyOneFood.txt");
         var gameStateQueue = new Queue<GameState>() { };
         var nextGameState = new GameDownload().DownloadGameStateFromFile("../../../GameState/LevelTwoMap.txt");
         gameStateQueue.Enqueue(nextGameState);
         var console = new ConsoleWrapper();
         var searchAlgorithm = new AStarSearchAlgorithm();
         var pacmanController = new PacmanController();
         var ghostController = new GhostController(searchAlgorithm);
         var game = new NewGame(currentGameState, gameStateQueue, pacmanController, ghostController);
         GameController.Run(game, console);
        
        
        var algorithm = new AStarSearchAlgorithm();
        var list = algorithm.Execute(currentGameState);
        foreach (var coord in list)
        {
            Console.WriteLine($"{coord.X+1}, {coord.Y+1}");
        }

    }
}
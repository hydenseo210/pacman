namespace Pacman.Code;

public static class Program
{
    public static void Main(string[] args)
    {
         var currentGameState = new GameDownload().DownloadGameStateFromFile("../../../GameState/LevelOneMapTest.txt");
         var testGameState = new GameDownload().DownloadGameStateFromFile("../../../GameState/test.txt");
         //var currentGameState = new GameDownload().DownloadGameStateFromFile("../../../GameState/LevelOneMapOnlyOneFood.txt");
         var gameStateQueue = new Queue<GameState>() { };
         var nextGameState = new GameDownload().DownloadGameStateFromFile("../../../GameState/LevelTwoMap.txt");
         gameStateQueue.Enqueue(nextGameState);
         var console = new ConsoleWrapper();
         var searchAlgorithm = new AStarSearchAlgorithm();
         var pacmanController = new PacmanController();
         // var ghostController = new GhostController(searchAlgorithm);
         var ghostController = new GhostController(new Blinky(new AggressiveBehaviour()), new Pinky(new AggressiveBehaviour()));
         var game = new Game(currentGameState, gameStateQueue, pacmanController, ghostController,console);
         GameController.Run(game, console);

    }
}
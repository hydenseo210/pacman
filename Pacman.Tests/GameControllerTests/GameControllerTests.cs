// namespace Pacman.Tests;
//
// public class GameControllerTests
// {
//     [Fact]
//     public void When_Pacman_Eats_All_The_Pellets_GameState_Is_Changed_To_The_Next_GameState_In_Queue()
//     {
//         var actualGameState = GameDownload.DownloadMapFromFile("../../../TestMaps/gameControllerTestMap.txt");
//         var expectedGameState = GameDownload.DownloadMapFromFile("../../../TestMaps/gameControllerTestMap2.txt");
//         var gameStateQueue = new Queue<GameState>(); 
//         gameStateQueue.Enqueue(expectedGameState);
//         var console = new ConsoleWrapperStub(
//                 new List<ConsoleKey>()
//                 {
//                     ConsoleKey.RightArrow,
//                     ConsoleKey.RightArrow,
//                     ConsoleKey.RightArrow,
//                     ConsoleKey.Q,
//                     
//                 });
//         
//         var pacmanController = new PacmanController();
//         var ghostController =
//             new GhostController(new Blinky(new AggressiveBehaviour()), new Pinky(new AggressiveBehaviour()));
//         var game = new Game(actualGameState, gameStateQueue, pacmanController, ghostController, console, new TestThreadSleeper());
//         GameController.Run(game, console, new TestThreadSleeper());
//         
//         
//         Assert.Equal(game.GetGameState(), expectedGameState);
//     }
//     
//     [Fact]
//     public void When_Pacman_Eats_All_The_Pellets_And_It_Is_The_Last_Level_Game_Ends_And_GameState_IsWon_Set_To_True()
//     {
//         var actualGameState = GameDownload.DownloadMapFromFile("../../../TestMaps/gameControllerTestMap.txt");
//         var gameStateQueue = new Queue<GameState>();
//         var console = new ConsoleWrapperStub(
//             new List<ConsoleKey>()
//             {
//                 ConsoleKey.RightArrow,
//                 ConsoleKey.RightArrow,
//                 ConsoleKey.RightArrow,
//                 ConsoleKey.Q,
//                     
//             });
//         
//         var pacmanController = new PacmanController();
//         var ghostController =
//             new GhostController(new Blinky(new AggressiveBehaviour()), new Pinky(new AggressiveBehaviour()));
//         var game = new Game(actualGameState, gameStateQueue, pacmanController, ghostController, console, new TestThreadSleeper());
//         GameController.Run(game, console, new TestThreadSleeper());
//         
//         Assert.True(game.IsLastLevel() && game.IsWon());
//     }
//     
//     [Fact]
//     public void When_Pacman_Loses_All_Lives_Game_Is_Lost_And_GameState_Is_Lost_Is_Set_To_True()
//     {
//         var actualGameState = GameDownload.DownloadMapFromFile("../../../TestMaps/gameControllerTestMap3.txt");
//         var gameStateQueue = new Queue<GameState>();
//         var console = new ConsoleWrapperStub(
//             new List<ConsoleKey>()
//             {
//                 ConsoleKey.RightArrow,
//                 ConsoleKey.RightArrow,
//                 ConsoleKey.RightArrow,
//                 ConsoleKey.RightArrow,
//                 ConsoleKey.RightArrow,
//                 ConsoleKey.Q,
//                     
//             });
//         
//         var pacmanController = new PacmanController();
//         var ghostController =
//             new GhostController(new Blinky(new AggressiveBehaviour()), new Pinky(new AggressiveBehaviour()));
//         var game = new Game(actualGameState, gameStateQueue, pacmanController, ghostController, console, new TestThreadSleeper());
//         GameController.Run(game, console, new TestThreadSleeper());
//         
//         
//         Assert.True(game.IsGameOver());
//         //test
//     }
//
// }
//
// public class TestThreadSleeper : IThreadSleeper
// {
//     public void Sleep(int sleepLength) => Thread.Sleep(0);
// }
//
// public class ConsoleWrapperStub : IConsoleWrapper
// {
//     private IList<ConsoleKey> keyCollection;
//     private int keyIndex;
//
//     public ConsoleWrapperStub(IList<ConsoleKey> keyCollection)
//     {
//         this.keyCollection = keyCollection;
//     }
//
//     public string winMessage = string.Empty;
//     public string GameOverMessage = string.Empty;
//
//     public ConsoleKeyInfo ReadKey()
//     {
//         var result = keyCollection[keyIndex];
//         keyIndex++;
//         return new ConsoleKeyInfo((char)result, result, false, false, false);
//     }
//
//     public void Write(string data)
//     {
//         if (data == Messages.WonMessage) winMessage += data;
//         if (data == Messages.GameOverMessage) GameOverMessage += data;
//     }
//
//     public string? Read()
//     {
//         return Console.ReadLine();
//     }
//
//     public bool KeyAvailable => true;
// }
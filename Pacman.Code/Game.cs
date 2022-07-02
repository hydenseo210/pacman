// using Pacman.Code.Constants;
// using System.Threading;
//
// namespace Pacman.Code;
//
// public class Game
// {
//     public readonly string[][] Grid;
//     private readonly int _width;
//     private readonly int _height;
//     private readonly int _sleepTimer;
//     private readonly IConsoleWrapper _console;
//     private Coordinate _pacmanLocation;
//     private readonly IThreadSleeper _threadSleeper;
//     public Game(GameState gameState, IConsoleWrapper consoleWrapper, int sleepTimer)
//     {
//         _console = consoleWrapper;
//         _pacmanLocation = gameState.PacmanLocation;
//         Grid = gameState.Map;
//         _height = gameState.Height;
//         _width = gameState.Width;
//         _sleepTimer = sleepTimer;
//         _threadSleeper = new ThreadSleeper();
//     }
//     
//     public void Run()
//     {
//         UpdateDirection();
//     }
//
//     private void UpdateDirection()
//     {
//         ConsoleKey key;
//         while ((key = _console.ReadKey().Key) != ConsoleKey.Escape)
//         {
//             switch (key)
//             {
//                 case ConsoleKey.LeftArrow:
//                     MovePacmanHorizontal((int)Horizontal.Left, Emojis.EatingLeftMotion);
//                     Print();
//                     break; 
//                 case ConsoleKey.RightArrow:
//                     MovePacmanHorizontal((int)Horizontal.Right, Emojis.EatingRightMotion);
//                     Print();
//                     break;
//                 case ConsoleKey.UpArrow:
//                     MovePacmanVertical((int)Vertical.Up, Emojis.EatingUpMotion);
//                     Print();
//                     break;
//                 case ConsoleKey.DownArrow:
//                     MovePacmanVertical((int)Vertical.Down, Emojis.EatingDownMotion);
//                     Print();
//                     break;
//                 default:
//                     throw new ArgumentOutOfRangeException(); // make it the last arrow pressed
//             }
//             //continuously moving pacman
//         }
//     }
//     
//     private void MovePacmanHorizontal(int amount, List<string> listOfEmojis)
//     {
//         if (Emojis.WallList.Contains(Grid[_pacmanLocation.Y][_pacmanLocation.X + amount]))
//         {
//             return;
//         }
//         Grid[_pacmanLocation.Y][_pacmanLocation.X] = " ";
//         if (Grid[_pacmanLocation.Y][_pacmanLocation.X + amount] == Emojis.Food)
//         {
//             foreach (var emoji in listOfEmojis)
//             {
//             
//                 Grid[_pacmanLocation.Y][_pacmanLocation.X + amount] = emoji;
//                 Print();
//                 _threadSleeper.Sleep(_sleepTimer);
//                 Console.Clear();
//             }
//         }
//         else
//         {
//             Grid[_pacmanLocation.Y][_pacmanLocation.X + amount] = listOfEmojis.Last();
//             Print();
//             _threadSleeper.Sleep(_sleepTimer + 100);
//             Console.Clear();
//         }
//
//         _pacmanLocation.X += amount;
//     }
//
//     private void MovePacmanVertical(int amount, List<string> listOfEmojis)
//     {
//         if (Emojis.WallList.Contains(Grid[_pacmanLocation.Y + amount][_pacmanLocation.X]))
//         {
//             return;
//         }
//         Grid[_pacmanLocation.Y][_pacmanLocation.X] = " ";
//         if (Grid[_pacmanLocation.Y + amount][_pacmanLocation.X] == Emojis.Food)
//         {
//             foreach (var emoji in listOfEmojis)
//             {
//             
//                 Grid[_pacmanLocation.Y + amount][_pacmanLocation.X] = emoji;
//                 Print();
//                 _threadSleeper.Sleep(_sleepTimer);
//                 Console.Clear();
//             }
//         }
//         else
//         {
//             Grid[_pacmanLocation.Y + amount][_pacmanLocation.X] = listOfEmojis.Last();
//             Print();
//             _threadSleeper.Sleep(_sleepTimer + 100);
//             Console.Clear();
//         }
//         _pacmanLocation.Y += amount;
//     }
//     
//     private void Print()
//     {
//         foreach (var i in Grid)
//         {
//             var newLine = RemoveGhostWalls(i);
//             Console.WriteLine(string.Join("", newLine));
//         }
//     }
//
//     private string[] RemoveGhostWalls(string[] grid)
//     {
//         var newLine = new string[grid.Length];
//         for (var ch = 0; ch < grid.Length; ch++)
//         {
//             if (grid[ch] == Emojis.Padding)
//             {
//                 newLine[ch] = " ";
//             }
//             else
//             {
//                 newLine[ch] = grid[ch];
//             }
//         }
//
//         return newLine;
//     }
//
//     private static int Mod(int potentialCoordinate, int boundary)
//     {
//         if (potentialCoordinate > boundary - 1)
//         {
//             return 0;
//         }
//         if (potentialCoordinate < 0)
//         {
//             return boundary - 1;
//         }
//         
//         return potentialCoordinate;
//     }
// }

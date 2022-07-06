// using Pacman.Code;
//
// namespace Pacman.Tests;
//
// public class WallInteractionTest
// {
//     [Theory]
//     [InlineData(Emojis.WallDown)]
//     [InlineData(Emojis.WallHorizontal)]
//     [InlineData(Emojis.WallDownLeft)]
//     [InlineData(Emojis.WallDownMiddle)]
//     [InlineData(Emojis.WallDownRight)]
//     [InlineData(Emojis.WallUpLeft)]
//     [InlineData(Emojis.WallUpMiddle)]
//     [InlineData(Emojis.WallUpRight)]
//     [InlineData(Emojis.Padding)]
//     [InlineData(Emojis.GhostGate)]
//     
//     public void Pacman_Cant_Move_In_The_Direction_Right_Across_The_Screen_When_Wall_Is_Blocking_The_Way(string wall)
//     {
//         var startingGrid = new []
//         {
//             new [] {"<", "∘", wall, "∘", "∘"},
//             new [] {"∘", "∘", "∘",  "∘", "∘"},
//             new [] {"∘", "∘", "∘",  "∘", "∘"},
//             new [] {"∘", "∘", "∘",  "∘", "∘"},
//             new [] {"∘", "∘", "∘",  "∘", "∘"},
//
//         };
//         var height = startingGrid.Length;
//         var width = startingGrid.First().Length;
//         
//         var consoleStub = new ConsoleWrapperStub(
//             new List<ConsoleKey>()
//             {
//                 ConsoleKey.RightArrow,
//                 ConsoleKey.RightArrow,
//                 ConsoleKey.RightArrow,
//                 ConsoleKey.RightArrow,
//                 ConsoleKey.Escape,
//             });
//         // Arrange
//         var testGameState = new GameState(height, width, startingGrid, new Coordinate(0, 0));
//         var game = new Game(testGameState, consoleStub,0);
//
//         var expected = new []
//         {
//             new [] {" ", "<", wall, "∘", "∘"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//         };
//
//         // Act 
//         game.Run();
//         var result = game.Grid;
//         // Assert
//         Assert.Equal(expected, result);
//     }
//     
//     [Theory]
//     [InlineData(Emojis.WallDown)]
//     [InlineData(Emojis.WallHorizontal)]
//     [InlineData(Emojis.WallDownLeft)]
//     [InlineData(Emojis.WallDownMiddle)]
//     [InlineData(Emojis.WallDownRight)]
//     [InlineData(Emojis.WallUpLeft)]
//     [InlineData(Emojis.WallUpMiddle)]
//     [InlineData(Emojis.WallUpRight)]
//     [InlineData(Emojis.Padding)]
//     [InlineData(Emojis.GhostGate)]
//     public void Pacman_Cant_Move_In_The_Direction_Left_Across_The_Screen_When_Wall_Is_Blocking_The_Way(string wall)
//     {
//         var startingGrid = new[]
//         {
//             new [] {"∘", "∘", wall, "∘", ">"},
//             new [] {"∘", "∘", "∘",  "∘", "∘"},
//             new [] {"∘", "∘", "∘",  "∘", "∘"},
//             new [] {"∘", "∘", "∘",  "∘", "∘"},
//             new [] {"∘", "∘", "∘",  "∘", "∘"},
//
//         };
//         var height = startingGrid.Length;
//         var width = startingGrid.First().Length;
//         
//         var consoleStub = new ConsoleWrapperStub(
//             new List<ConsoleKey>()
//             {
//                 ConsoleKey.LeftArrow,
//                 ConsoleKey.LeftArrow,
//                 ConsoleKey.LeftArrow,
//                 ConsoleKey.LeftArrow,
//                 ConsoleKey.Escape,
//             });
//         // Arrange
//         var testGameState = new GameState(height, width, startingGrid, new Coordinate(4, 0));
//         var game = new Game(testGameState, consoleStub,0);
//
//         var expected = new []
//         {
//             new [] {"∘", "∘", wall, ">", " "},
//             new [] {"∘", "∘", "∘",  "∘", "∘"},
//             new [] {"∘", "∘", "∘",  "∘", "∘"},
//             new [] {"∘", "∘", "∘",  "∘", "∘"},
//             new [] {"∘", "∘", "∘",  "∘", "∘"},
//         };
//
//         // Act 
//         game.Run();
//         var result = game.Grid;
//         // Assert
//         Assert.Equal(expected, result);
//     }
//     
//     [Theory]
//     [InlineData(Emojis.WallDown)]
//     [InlineData(Emojis.WallHorizontal)]
//     [InlineData(Emojis.WallDownLeft)]
//     [InlineData(Emojis.WallDownMiddle)]
//     [InlineData(Emojis.WallDownRight)]
//     [InlineData(Emojis.WallUpLeft)]
//     [InlineData(Emojis.WallUpMiddle)]
//     [InlineData(Emojis.WallUpRight)]
//     [InlineData(Emojis.Padding)]
//     [InlineData(Emojis.GhostGate)]
//     public void Pacman_Cant_Move_In_The_Direction_Down_Across_The_Screen_When_Wall_Is_Blocking_The_Way(string wall)
//     {
//         var startingGrid = new[]
//         {
//             new [] {"∘", "∘", "∘", "∘", "⋀"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//             new [] {"∘", "∘", "∘", "∘", wall},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//
//         };
//         var height = startingGrid.Length;
//         var width = startingGrid.First().Length;
//         
//         var consoleStub = new ConsoleWrapperStub(
//             new List<ConsoleKey>()
//             {
//                 ConsoleKey.DownArrow,
//                 ConsoleKey.DownArrow,
//                 ConsoleKey.DownArrow,
//                 ConsoleKey.DownArrow,
//                 ConsoleKey.Escape,
//             });
//         // Arrange
//         var testGameState = new GameState(height, width, startingGrid, new Coordinate(4, 0));
//         var game = new Game(testGameState, consoleStub,0);
//
//         var expected = new []
//         {
//             new [] {"∘", "∘", "∘", "∘", " "},
//             new [] {"∘", "∘", "∘", "∘", "⋀"},
//             new [] {"∘", "∘", "∘", "∘", wall},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//         };
//
//         // Act 
//         game.Run();
//         var result = game.Grid;
//         // Assert
//         Assert.Equal(expected, result);
//     }
//     
//     [Theory]
//     [InlineData(Emojis.WallDown)]
//     [InlineData(Emojis.WallHorizontal)]
//     [InlineData(Emojis.WallDownLeft)]
//     [InlineData(Emojis.WallDownMiddle)]
//     [InlineData(Emojis.WallDownRight)]
//     [InlineData(Emojis.WallUpLeft)]
//     [InlineData(Emojis.WallUpMiddle)]
//     [InlineData(Emojis.WallUpRight)]
//     [InlineData(Emojis.Padding)]
//     [InlineData(Emojis.GhostGate)]
//     public void Pacman_Can_Move_In_The_Direction_Up_Across_The_Screen_When_UpArrow_Is_Pressed(string wall)
//     {
//         var startingGrid = new[]
//         {
//             new [] {"∘",  "∘", "∘", "∘", "∘"},
//             new [] {"∘",  "∘", "∘", "∘", "∘"},
//             new [] {wall, "∘", "∘", "∘", "∘"},
//             new [] {"∘",  "∘", "∘", "∘", "∘"},
//             new [] {"⋁",  "∘", "∘", "∘", "∘"},
//
//         };
//         var height = startingGrid.Length;
//         var width = startingGrid.First().Length;
//         
//         var consoleStub = new ConsoleWrapperStub(
//             new List<ConsoleKey>()
//             {
//                 ConsoleKey.UpArrow,
//                 ConsoleKey.UpArrow,
//                 ConsoleKey.UpArrow,
//                 ConsoleKey.UpArrow,
//                 ConsoleKey.Escape,
//             });
//         // Arrange
//         var testGameState = new GameState(height, width, startingGrid, new Coordinate(0, 4));
//         var game = new Game(testGameState, consoleStub,0);
//
//         var expected = new []
//         {
//             new [] {"∘",  "∘", "∘", "∘", "∘"},
//             new [] {"∘",  "∘", "∘", "∘", "∘"},
//             new [] {wall, "∘", "∘", "∘", "∘"},
//             new [] {"⋁",  "∘", "∘", "∘", "∘"},
//             new [] {" ",  "∘", "∘", "∘", "∘"},
//         };
//
//         // Act 
//         game.Run();
//         var result = game.Grid;
//         // Assert
//         Assert.Equal(expected, result);
//     }
// }
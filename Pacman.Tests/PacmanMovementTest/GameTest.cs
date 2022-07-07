using Moq;

namespace Pacman.Tests;

public class GameTests
{
    [Fact]
    public void Pacman_Can_Move_In_The_Direction_Right_Across_The_Screen_When_RightArrow_Is_Pressed()
    {
        var mapHelper = new TestMapHelper();
        //var stubGameState = StubGameState.GetGameState(Directions.Right);
        // Arrange
        var mappyBoy = mapHelper.SetUpInitialMap();
        mapHelper.SetPacmanPosition(new Coordinate(0,0), Directions.Right, mappyBoy);
        var actualMap = mappyBoy;
        var state = new GameState(5, 5, actualMap);
        var expectedGameState = ExpectedGameState.GetGameState(Directions.Right);
        var controller = new PacmanController();

        var expectedMap = expectedGameState.Map;
        
        // Act 
        controller.Move(state, Directions.Right);

        // Assert
        Assert.True(Compare(expectedMap, actualMap));
    }

    private bool Compare(Dictionary<Coordinate, Cell> x, Dictionary<Coordinate, Cell> y)
    {
        if (x.Count != y.Count)
            return false;
        if (x.Keys.Except(y.Keys).Any())
            return false;
        if (y.Keys.Except(x.Keys).Any())
            return false;
        foreach (var pair in x)
            if(x[pair.Key].GetType() != y[pair.Key].GetType())
                return false;
        return true;
    }
//     
        
//     [Fact]
//     public void Pacman_Can_Move_In_The_Direction_Left_Across_The_Screen_When_LeftArrow_Is_Pressed()
//     {
//         var startingGrid = new[]
//         {
//             new [] {"<", "∘", "∘", "∘", "<"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
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
//             new [] {">", " ", " ", " ", " "},
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
//     [Fact]
//     public void Pacman_Can_Move_In_The_Direction_Down_Across_The_Screen_When_DownArrow_Is_Pressed()
//     {
//         var startingGrid = new[]
//         {
//             new [] {"∘", "∘", "∘", "∘", "⋀"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
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
//             new [] {"∘", "∘", "∘", "∘", " "},
//             new [] {"∘", "∘", "∘", "∘", " "},
//             new [] {"∘", "∘", "∘", "∘", " "},
//             new [] {"∘", "∘", "∘", "∘", "⋀"},
//         };
//
//         // Act 
//         game.Run();
//         var result = game.Grid;
//         // Assert
//         Assert.Equal(expected, result);
//     }
//     
//     [Fact]
//     public void Pacman_Can_Move_In_The_Direction_Up_Across_The_Screen_When_UpArrow_Is_Pressed()
//     {
//         var startingGrid = new[]
//         {
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//             new [] {"∘", "∘", "∘", "∘", "∘"},
//             new [] {"⋁", "∘", "∘", "∘", "∘"},
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
//             new [] {"⋁", "∘", "∘", "∘", "∘"},
//             new [] {" ", "∘", "∘", "∘", "∘"},
//             new [] {" ", "∘", "∘", "∘", "∘"},
//             new [] {" ", "∘", "∘", "∘", "∘"},
//             new [] {" ", "∘", "∘", "∘", "∘"},
//         };
//
//         // Act 
//         game.Run();
//         var result = game.Grid;
//         // Assert
//         Assert.Equal(expected, result);
//     }
// }


private class ConsoleWrapperStub : IConsoleWrapper
    {
        private IList<ConsoleKey> keyCollection;
        private int keyIndex = 0;

        public ConsoleWrapperStub(IList<ConsoleKey> keyCollection)
        {
            this.keyCollection = keyCollection;
        }

        public string Output = string.Empty;

        public ConsoleKeyInfo ReadKey()
        {
            var result = keyCollection[this.keyIndex];
            keyIndex++;
            return new ConsoleKeyInfo((char)result, result, false, false, false);
        }

        public void Write(string data)
        {
            Output += data;
        }

        public string? Read()
        {
            return Console.ReadLine();
        }

        public bool KeyAvailable => true;
    }

}

namespace Pacman.Tests;

public class GameTests
{
    [Fact]
    public void Pacman_Can_Move_In_The_Direction_Right_Across_The_Screen_When_RightArrow_Is_Pressed()
    {
        var startingGrid = new string[][]
        {
            new string[] {"<", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},

        };
        var consoleStub = new ConsoleWrapperStub(
            new List<ConsoleKey>()
            {
                ConsoleKey.RightArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.Escape,
            });
        // Arrange
        var game = new Game(startingGrid, consoleStub, new Coordinate(0 , 0));

        var expected = new string[][]
        {
            new string[] {" ", " ", " ", " ", "<"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
        };

        // Act 
        game.Run();
        var result = game.Grid;
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Pacman_Can_Move_In_The_Direction_Left_Across_The_Screen_When_LeftArrow_Is_Pressed()
    {
        var startingGrid = new[]
        {
            new [] {"∘", "∘", "∘", "∘", ">"},
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"∘", "∘", "∘", "∘", "∘"},

        };
        var consoleStub = new ConsoleWrapperStub(
            new List<ConsoleKey>()
            {
                ConsoleKey.LeftArrow,
                ConsoleKey.LeftArrow,
                ConsoleKey.LeftArrow,
                ConsoleKey.LeftArrow,
                ConsoleKey.Escape,
            });
        // Arrange
        var game = new Game(startingGrid, consoleStub, new Coordinate(4, 0));

        var expected = new []
        {
            new [] {">", " ", " ", " ", " "},
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"∘", "∘", "∘", "∘", "∘"},
        };

        // Act 
        game.Run();
        var result = game.Grid;
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Pacman_Can_Move_In_The_Direction_Down_Across_The_Screen_When_DownArrow_Is_Pressed()
    {
        var startingGrid = new[]
        {
            new [] {"∘", "∘", "∘", "∘", "⋀"},
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"∘", "∘", "∘", "∘", "∘"},

        };
        var consoleStub = new ConsoleWrapperStub(
            new List<ConsoleKey>()
            {
                ConsoleKey.DownArrow,
                ConsoleKey.DownArrow,
                ConsoleKey.DownArrow,
                ConsoleKey.DownArrow,
                ConsoleKey.Escape,
            });
        // Arrange
        var game = new Game(startingGrid, consoleStub, new Coordinate(4, 0));

        var expected = new []
        {
            new [] {"∘", "∘", "∘", "∘", " "},
            new [] {"∘", "∘", "∘", "∘", " "},
            new [] {"∘", "∘", "∘", "∘", " "},
            new [] {"∘", "∘", "∘", "∘", " "},
            new [] {"∘", "∘", "∘", "∘", "⋀"},
        };

        // Act 
        game.Run();
        var result = game.Grid;
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Pacman_Can_Move_In_The_Direction_Up_Across_The_Screen_When_UpArrow_Is_Pressed()
    {
        var startingGrid = new[]
        {
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"∘", "∘", "∘", "∘", "∘"},
            new [] {"⋁", "∘", "∘", "∘", "∘"},

        };
        var consoleStub = new ConsoleWrapperStub(
            new List<ConsoleKey>()
            {
                ConsoleKey.UpArrow,
                ConsoleKey.UpArrow,
                ConsoleKey.UpArrow,
                ConsoleKey.UpArrow,
                ConsoleKey.Escape,
            });
        // Arrange
        var game = new Game(startingGrid, consoleStub, new Coordinate(0, 4));

        var expected = new []
        {
            new [] {"⋁", "∘", "∘", "∘", "∘"},
            new [] {" ", "∘", "∘", "∘", "∘"},
            new [] {" ", "∘", "∘", "∘", "∘"},
            new [] {" ", "∘", "∘", "∘", "∘"},
            new [] {" ", "∘", "∘", "∘", "∘"},
        };

        // Act 
        game.Run();
        var result = game.Grid;
        // Assert
        Assert.Equal(expected, result);
    }
}


public class ConsoleWrapperStub : IConsoleWrapper
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
        return new ConsoleKeyInfo( (char)result ,result ,false ,false ,false);
    }

    public void Write(string data)
    {
        Output += data;
    }
}
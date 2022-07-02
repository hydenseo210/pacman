namespace Pacman.Tests;

public class GhostTests
{
    [Fact]
    public void When_Move_Is_Called_Ghost_Can_Move_Across_Right()
    {
        var startingGrid = new string[][]
        {
            new string[] {"@", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            
        };
        // Arrange
        var ghost = new Ghost(startingGrid);

        var expected = new string[][]
        {
            new string[] {"∘", "∘", "∘", "∘", "@"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
            new string[] {"∘", "∘", "∘", "∘", "∘"},
        };

        // Act 
        ghost.Move();
        var result = ghost.Grid;
        // Assert
        Assert.Equal(expected, result);
    }
}
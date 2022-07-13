namespace Pacman.Tests;

public class PacmanControllerTest
{
    private GameStateGenerator _gameStateGenerator;
    
    [Fact]
    public void Pacman_Can_Move_In_The_Direction_Right_Across_The_Screen_When_Move_Is_Called_Given_Pacman_Is_Facing_Right()
    {
        // Arrange
        var actualGameState = _gameStateGenerator.InitiateGameState(5, 5, 24, new Coordinate(0, 0), Directions.Right);
        _gameStateGenerator.ResetMap();
        var expectedGameState = _gameStateGenerator.InitiateGameState(5, 5, 24, new Coordinate(0, 4), Directions.Right);
        for (var i = 0; i < 4; i++) _gameStateGenerator.SetCellToEmptyCell(new Coordinate(0, i));
        var controller = new PacmanController();
        // Act 
        for (var i = 0; i < 4; i++) controller.Move(actualGameState, Directions.Right);

        var actualMap = actualGameState.Map;
        var expectedMap = expectedGameState.Map;
        // Assert
        Assert.True(Compare(expectedMap, actualMap));
    }
    
    [Fact]
    public void Pacman_Can_Move_In_The_Direction_Left_Across_The_Screen_When_Move_Is_Called_Given_Pacman_Is_Facing_Left()
    {
        // Arrange
        var actualGameState = _gameStateGenerator.InitiateGameState(5, 5, 24, new Coordinate(0, 4), Directions.Left);
        _gameStateGenerator.ResetMap();
        var expectedGameState = _gameStateGenerator.InitiateGameState(5, 5, 24, new Coordinate(0, 0), Directions.Left);
        for (var i = 1; i < 5; i++) _gameStateGenerator.SetCellToEmptyCell(new Coordinate(0, i));
        var controller = new PacmanController();
        // Act 
        for (var i = 0; i < 4; i++) controller.Move(actualGameState, Directions.Left);

        var actualMap = actualGameState.Map;
        var expectedMap = expectedGameState.Map;
        // Assert
        Assert.True(Compare(expectedMap, actualMap));
    }
    
    [Fact]
    public void Pacman_Can_Move_In_The_Direction_Down_Across_The_Screen_When_Move_Is_Called_Given_Pacman_Is_Facing_Down()
    {
        // Arrange
        var actualGameState = _gameStateGenerator.InitiateGameState(5, 5, 24, new Coordinate(0, 0), Directions.Down);
        _gameStateGenerator.ResetMap();
        var expectedGameState = _gameStateGenerator.InitiateGameState(5, 5, 24, new Coordinate(4, 0), Directions.Down);
        for (var i = 0; i < 4; i++) _gameStateGenerator.SetCellToEmptyCell(new Coordinate(i, 0));
        var controller = new PacmanController();
        // Act 
        for (var i = 0; i < 4; i++) controller.Move(actualGameState, Directions.Down);

        var actualMap = actualGameState.Map;
        var expectedMap = expectedGameState.Map;
        // Assert
        Assert.True(Compare(expectedMap, actualMap));
    }
    
    [Fact]
    public void Pacman_Can_Move_In_The_Direction_Up_Across_The_Screen_When_Move_Is_Called_Given_Pacman_Is_Facing_Up()
    {
        // Arrange
        var actualGameState = _gameStateGenerator.InitiateGameState(5, 5, 24, new Coordinate(4, 0), Directions.Up);
        _gameStateGenerator.ResetMap();
        var expectedGameState = _gameStateGenerator.InitiateGameState(5, 5, 24, new Coordinate(0, 0), Directions.Up);
        for (var i = 1; i < 5; i++) _gameStateGenerator.SetCellToEmptyCell(new Coordinate(i, 0));
        var controller = new PacmanController();
        // Act 
        for (var i = 0; i < 4; i++) controller.Move(actualGameState, Directions.Up);

        var actualMap = actualGameState.Map;
        var expectedMap = expectedGameState.Map;
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
}

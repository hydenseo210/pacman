namespace Pacman.Tests;
public class GhostControllerTests
{
    [Theory]
    [InlineData("Blinky")]
    [InlineData("Pinky")]
    public void When_MoveGhost_Is_Called_Ghost_Can_Move_Past_Food_Without_Removing_Them(string ghostName)
    {
        //Arrange
        var gameStateGenerator = new GameStateGenerator();
        var actualGameState =gameStateGenerator.InitiateGameState(1, 10, 6, new Coordinate(0, 8), Directions.Right);
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,0));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,10));
        if (ghostName == "Blinky") gameStateGenerator.SetBlinkyLocation(new Coordinate(0, 1));
        else gameStateGenerator.SetPinkyLocation(new Coordinate(0 ,1));
        for (var i = 2; i < 8; i++) gameStateGenerator.SetCellToFood(new Coordinate(0,i));
        gameStateGenerator.ResetMap();
        var expectedGameState = gameStateGenerator.InitiateGameState(1, 10, 6, new Coordinate(0, 8), Directions.Right);
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,0));
        gameStateGenerator.SetCellToEmptyCell(new Coordinate(0,1));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,10));
        if(ghostName =="Blinky") gameStateGenerator.SetBlinkyLocation(new Coordinate(0 ,7));
        else gameStateGenerator.SetPinkyLocation(new Coordinate(0 ,7));
        for (var i = 2; i < 7; i++) gameStateGenerator.SetCellToFood(new Coordinate(0,i));
        var controller = new GhostController(new Blinky(new AggressiveBehaviour()), new Pinky(new AggressiveBehaviour()));
        // Act 
        if(ghostName =="Blinky") for (var i = 0; i < 7; i++) controller.MoveBlinky(actualGameState);
        else for (var i = 0; i < 7; i++) controller.MovePinky(actualGameState);

        var actualMap = actualGameState.Map;
        var expectedMap = expectedGameState.Map;
        // Assert
        Assert.True(Compare(expectedMap, actualMap));
        
    }
    [Theory]
    [InlineData("Blinky")]
    [InlineData("Pinky")]
    public void When_MoveGhost_Is_Called_Ghost_Can_GoTo_PacMan_Along_The_ShortestPath_When_In_Aggressive_Behaviour(string ghostName)
    {
        //Arrange
        var gameStateGenerator = new GameStateGenerator();
        var actualGameState =gameStateGenerator.InitiateGameState(2, 10, 6, new Coordinate(0, 8), Directions.Right);
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,0));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,10));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(1,0));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(1,10));
        if (ghostName == "Blinky") gameStateGenerator.SetBlinkyLocation(new Coordinate(0, 1));
        else gameStateGenerator.SetPinkyLocation(new Coordinate(0 ,1));
        for (var i = 2; i < 8; i++) gameStateGenerator.SetCellToFood(new Coordinate(0,i));
        for (var i = 1; i < 10; i++) gameStateGenerator.SetCellToFood(new Coordinate(1,i));
        gameStateGenerator.ResetMap();
        var expectedGameState = gameStateGenerator.InitiateGameState(1, 10, 6, new Coordinate(0, 8), Directions.Right);
        gameStateGenerator.SetCellToEmptyCell(new Coordinate(0,1));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,0));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,10));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(1,0));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(1,10));
        if(ghostName =="Blinky") gameStateGenerator.SetBlinkyLocation(new Coordinate(0 ,7));
        else gameStateGenerator.SetPinkyLocation(new Coordinate(0 ,7));
        for (var i = 2; i < 7; i++) gameStateGenerator.SetCellToFood(new Coordinate(0,i));
        for (var i = 1; i < 10; i++) gameStateGenerator.SetCellToFood(new Coordinate(1,i));
        var controller = new GhostController(new Blinky(new AggressiveBehaviour()), new Pinky(new AggressiveBehaviour()));
        // Act 
        if(ghostName =="Blinky") for (var i = 0; i < 7; i++) controller.MoveBlinky(actualGameState);
        else for (var i = 0; i < 7; i++) controller.MovePinky(actualGameState);

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
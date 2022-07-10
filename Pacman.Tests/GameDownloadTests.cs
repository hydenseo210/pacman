using Pacman.Code;

namespace Pacman.Tests;

public class GameDownloadTests
{
    [Fact]
    public void DownloadGameStateFromFile_Returns_Correct_GameState()
    {
        //Arrange
        var gameDownload = new GameDownload();
        var gameStateGenerator = new GameStateGenerator();
        gameStateGenerator.InitiateGameState(1, 16, 1, new Coordinate(0, 0), Directions.Right);
        gameStateGenerator.SetBlinkyLocation(new Coordinate(0, 2));
        gameStateGenerator.SetPinkyLocation(new Coordinate(0, 1));
        gameStateGenerator.SetCellToFood(new Coordinate(0, 3));
        gameStateGenerator.SetCellToWallUpLeft(new Coordinate(0, 4));
        gameStateGenerator.SetCellToWallUpRight(new Coordinate(0, 5));
        gameStateGenerator.SetCellToWallDownLeft(new Coordinate(0, 6));
        gameStateGenerator.SetCellToWallDownRight(new Coordinate(0, 7));
        gameStateGenerator.SetCellToHorizontalWall(new Coordinate(0, 8));
        gameStateGenerator.SetCellToWallUpMiddle(new Coordinate(0, 9));
        gameStateGenerator.SetCellToWallRightMiddle(new Coordinate(0, 10));
        gameStateGenerator.SetCellToWallLeftMiddle(new Coordinate(0, 11));
        gameStateGenerator.SetCellToWallDownThickMiddle(new Coordinate(0, 12));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0, 13));
        gameStateGenerator.SetCellToWallCross(new Coordinate(0, 14));
        gameStateGenerator.SetCellToWallGhostGate(new Coordinate(0, 15));
        
        var expectedGameState = gameStateGenerator.GetGameState();
        //Act
        var actualGameState = gameDownload.DownloadGameStateFromFile("../../../TestMaps/TestMap4.txt");
        //Assert
        Assert.Equal(expectedGameState.Height, actualGameState.Height);
        Assert.Equal(expectedGameState.Width, actualGameState.Width);
        Assert.Equal(expectedGameState.PacmanLocation, actualGameState.PacmanLocation);
        Assert.Equal(expectedGameState.BlinkyLocation, actualGameState.BlinkyLocation);
        Assert.Equal(expectedGameState.PinkyLocation, actualGameState.PinkyLocation);
        Assert.True(Compare(expectedGameState.Map, actualGameState.Map));
    }
    
    [Fact]
    public void GetMapFromFile_Throws_In()
    {
        var actualGameState = new GameDownload();

        var ActualEmptyFileException = Assert.Throws<InvalidDataException>(() => actualGameState.DownloadGameStateFromFile("../../../TestMaps/EmptyTextFile.txt"));
        Assert.Equal("File is Empty.", ActualEmptyFileException.Message);
        
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


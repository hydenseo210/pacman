namespace Pacman.Tests;

public class GameDownloadTests
{

    [Theory]
    [InlineData(GameDownloadTestMap.EmptyTestMapFilePath, Exceptions.EmptyFile)]
    [InlineData(GameDownloadTestMap.MultiplePacmanTestMapFilePath, Exceptions.PacmanCount)]
    [InlineData(GameDownloadTestMap.MultipleBlinkyTestMapFilePath, Exceptions.GhostCount)]
    [InlineData(GameDownloadTestMap.MultipleClydeTestMapFilePath, Exceptions.GhostCount)]
    [InlineData(GameDownloadTestMap.MultiplePinkyTestMapFilePath, Exceptions.GhostCount)]
    [InlineData(GameDownloadTestMap.MultipleInkyTestMapFilePath, Exceptions.GhostCount)]
    [InlineData(GameDownloadTestMap.ZeroPacmanTestMapFilePath, Exceptions.ZeroPacmanCount)]
    [InlineData(GameDownloadTestMap.ZeroGhostTestMapFilePath, Exceptions.AtLeastOneGhost)]
    public void GetMapFromFile_Throws_File_Is_Empty_Message_When_Given_Empty_File(string filePath, string expectedExpection)
    {
        var ActualEmptyFileException = Assert.Throws<InvalidDataException>(() => GameDownload.DownloadMapFromFile(filePath));
        Assert.Equal(expectedExpection, ActualEmptyFileException.Message);
    }

    [Theory]
    [MemberData(nameof(GridData))]
    public void DownloadMapFromFile_Returns_Correct_Map_Grid(string filePath, Dictionary<Coordinate,Cell> expectedMapGrid)
    {
        
        var actualMapGrid = GameDownload.DownloadMapFromFile(filePath).Grid;
        
        Assert.True(Compare.Dictionaries(expectedMapGrid, actualMapGrid));
    }
    
    [Theory]
    [MemberData(nameof(PacmanCoordinateData))]
    public void DownloadMapFromFile_Returns_Correct_Pacman_Coordinate_Within_The_Map(string filePath, Coordinate expectedPacmanCoordinate)
    {
        
        var actualPacmanCoordinate = GameDownload.DownloadMapFromFile(filePath).PacmanCoordinate;
        
        Assert.Equal(expectedPacmanCoordinate, actualPacmanCoordinate);
    }
    
    [Theory]
    [MemberData(nameof(PinkyCoordinateData))]
    public void DownloadMapFromFile_Returns_Correct_Pinky_Coordinate_Within_The_Map(string filePath, Coordinate expectedPinkyCoordinate)
    {
        
        var pinky = GameDownload.DownloadMapFromFile(filePath).GhostList.Find(x => x is Pinky);
        var actualPinkyCoordinate = pinky.StartingCoordinate;
        
        Assert.Equal(expectedPinkyCoordinate, actualPinkyCoordinate);
    }
    
    [Theory]
    [MemberData(nameof(BlinkyCoordinateData))]
    public void DownloadMapFromFile_Returns_Correct_Blinky_Coordinate_Within_The_Map(string filePath, Coordinate expectedBlinkyCoordinate)
    {
        
        var blinky = GameDownload.DownloadMapFromFile(filePath).GhostList.Find(x => x is Blinky);
        var actualBlinkyCoordinate = blinky.StartingCoordinate;
        
        Assert.Equal(expectedBlinkyCoordinate, actualBlinkyCoordinate);
    }
    public static IEnumerable<object[]> GridData =>
        new List<object[]>
        {
            new object[] { GameDownloadTestMap.TestMapOneFilePath, GameDownloadTestGrids.gridOne}
        };
    
    public static IEnumerable<object[]> PacmanCoordinateData =>
        new List<object[]>
        {
            new object[] { GameDownloadTestMap.TestMapOneFilePath, GameDownloadTestGrids.pacmanCoordinateForGridOne},
        };
    
    public static IEnumerable<object[]> PinkyCoordinateData =>
        new List<object[]>
        {
            new object[] { GameDownloadTestMap.TestMapOneFilePath, GameDownloadTestGrids.pinkyCoordinateForGridOne},
        };
    
    public static IEnumerable<object[]> BlinkyCoordinateData =>
        new List<object[]>
        {
            new object[] { GameDownloadTestMap.TestMapOneFilePath, GameDownloadTestGrids.blinkyCoordinateForGridOne}
        };
}


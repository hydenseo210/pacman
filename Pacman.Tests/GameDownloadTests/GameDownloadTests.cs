namespace Pacman.Tests;

public class GameDownloadTests
{

    [Theory]
    [InlineData(GameDownloadTestMap.EmptyTestMapFilePath, GameDownloadTestMap.EmptyExceptionMessage)]
    public void GetMapFromFile_Throws_In(string filePath, string expectedExpection)
    {
        
        var ActualEmptyFileException = Assert.Throws<InvalidDataException>(() => GameDownload.DownloadMapFromFile(filePath));
        Assert.Equal(expectedExpection, ActualEmptyFileException.Message);
        
    }
    [Theory]
    [InlineData(GameDownloadTestMap.TestMapOneFilePath, GameDownloadTestMap.TestMapOneHeight)]
    public void DownloadMapFromFile_Returns_Correct_Map_Height(string filePath, int expectedHeight)
    {
        var actualMapHeight = GameDownload.DownloadMapFromFile(filePath).Height;
        Assert.Equal(expectedHeight, actualMapHeight);
    }
    
    
    [Theory]
    [InlineData(GameDownloadTestMap.TestMapOneFilePath, GameDownloadTestMap.TestMapOneWidth)]
    public void DownloadMapFromFile_Returns_Correct_Map_Width(string filePath, int expectedWidth)
    {
        
        var actualMapWidth = GameDownload.DownloadMapFromFile(filePath).Width;
        
        Assert.Equal(expectedWidth, actualMapWidth);
    }
    
    [Theory]
    [InlineData(GameDownloadTestMap.TestMapOneFilePath, GameDownloadTestMap.TestMapOneTotalScore)]
    public void DownloadMapFromFile_Returns_Correct_Map_TotalScore(string filePath, int expectedTotalScore)
    {
        
        var actualMapTotalScore = GameDownload.DownloadMapFromFile(filePath).TotalScore;
        
        Assert.Equal(expectedTotalScore, actualMapTotalScore);
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
        
        var actualPinkyCoordinate = GameDownload.DownloadMapFromFile(filePath).PinkyCoordinate;
        
        Assert.Equal(expectedPinkyCoordinate, actualPinkyCoordinate);
    }
    
    [Theory]
    [MemberData(nameof(BlinkyCoordinateData))]
    public void DownloadMapFromFile_Returns_Correct_Blinky_Coordinate_Within_The_Map(string filePath, Coordinate expectedBlinkyCoordinate)
    {
        
        var actualBlinkyCoordinate = GameDownload.DownloadMapFromFile(filePath).BlinkyCoordinate;
        
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


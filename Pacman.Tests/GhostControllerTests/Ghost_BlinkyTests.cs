namespace Pacman.Tests;
public class Ghost_BlinkyTests
{
    
    [Theory]
    [MemberData(nameof(GhostData))]
    public void When_MoveBlinky_Is_Called_Blinky_Can_Go_To_PacMan_Along_The_ShortestPath_When_In_Aggressive_Behaviour(
        int height, int width, int totalScore, 
        Dictionary<Coordinate,Cell> grid, Coordinate pacmanCoordinate, Coordinate blinkyCoordinate, Dictionary<Coordinate,Cell> expectedGrid)
    {
        // Arrange
        var Blinky = new Blinky(new AggressiveBehaviour());
        var actualMap = new Map(height, width, totalScore, grid, 
            Stub.ListOfCoordinates, pacmanCoordinate, blinkyCoordinate , Stub.Coordinate);
        var controller = new GhostController();
        // Act 
        controller.Move(actualMap, Blinky);
    
        var actualGrid = actualMap.Grid;
        // Assert
        Assert.True(Compare.Dictionaries(expectedGrid, actualGrid));
    }
    
    public static IEnumerable<object[]> GhostData =>
        new List<object[]>
        {
            new object[]
            {
                GhostControllerBlinkyTestMap.TestMapOneHeight,
                GhostControllerBlinkyTestMap.TestMapOneWidth,
                GhostControllerBlinkyTestMap.TestMapOneTotalScore,
                GhostControllerBlinkyTestGrid1.actualGrid,
                GhostControllerBlinkyTestGrid1.ActualPacmanCoordinate,
                GhostControllerBlinkyTestGrid1.ActualBlinkyCoordinate,
                GhostControllerBlinkyTestGrid1.expectedGrid
            },
            new object[]
            {
                GhostControllerBlinkyTestMap.TestMapTwoHeight,
                GhostControllerBlinkyTestMap.TestMapTwoWidth,
                GhostControllerBlinkyTestMap.TestMapTwoTotalScore,
                GhostControllerBlinkyTestGrid2.actualGrid,
                GhostControllerBlinkyTestGrid2.ActualPacmanCoordinate,
                GhostControllerBlinkyTestGrid2.ActualBlinkyCoordinate,
                GhostControllerBlinkyTestGrid2.expectedGrid
            },
            new object[]
            {
                GhostControllerBlinkyTestMap.TestMapThreeHeight,
                GhostControllerBlinkyTestMap.TestMapThreeWidth,
                GhostControllerBlinkyTestMap.TestMapThreeTotalScore,
                GhostControllerBlinkyTestGrid3.actualGrid,
                GhostControllerBlinkyTestGrid3.ActualPacmanCoordinate,
                GhostControllerBlinkyTestGrid3.ActualBlinkyCoordinate,
                GhostControllerBlinkyTestGrid3.expectedGrid
            },
            new object[]
            {
                GhostControllerBlinkyTestMap.TestMapFourHeight,
                GhostControllerBlinkyTestMap.TestMapFourWidth,
                GhostControllerBlinkyTestMap.TestMapFourTotalScore,
                GhostControllerBlinkyTestGrid4.actualGrid,
                GhostControllerBlinkyTestGrid4.ActualPacmanCoordinate,
                GhostControllerBlinkyTestGrid4.ActualBlinkyCoordinate,
                GhostControllerBlinkyTestGrid4.expectedGrid
            }
        };
    
}
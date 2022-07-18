namespace Pacman.Tests;
public class Ghost_PinkyTests
{
    
    [Theory]
    [MemberData(nameof(GhostData))]
    public void When_MovePinky_Is_Called_Pinky_Can_Go_To_PacMan_Along_The_ShortestPath_When_In_Aggressive_Behaviour(
        int height, int width, int totalScore, 
        Dictionary<Coordinate,Cell> grid, Coordinate pacmanCoordinate, Coordinate pinkyCoordinate, Dictionary<Coordinate,Cell> expectedGrid)
    {
        // Arrange
        var Pinky = new Pinky(new AggressiveBehaviour());
        var actualMap = new Map(height, width, totalScore, grid, 
            Stub.ListOfCoordinates, pacmanCoordinate , Stub.Coordinate, pinkyCoordinate);
        var controller = new GhostController( Stub.AggressiveBlinky, Pinky);
        // Act 
        controller.MovePinky(actualMap);
    
        var actualGrid = actualMap.Grid;
        // Assert
        Assert.True(Compare.Dictionaries(expectedGrid, actualGrid));
    }
    
    public static IEnumerable<object[]> GhostData =>
        new List<object[]>
        {
            new object[]
            {
                GhostControllerPinkyTestMap.TestMapOneHeight,
                GhostControllerPinkyTestMap.TestMapOneWidth,
                GhostControllerPinkyTestMap.TestMapOneTotalScore,
                GhostControllerPinkyTestGrid1.actualGrid,
                GhostControllerPinkyTestGrid1.ActualPacmanCoordinate,
                GhostControllerPinkyTestGrid1.ActualPinkyCoordinate,
                GhostControllerPinkyTestGrid1.expectedGrid
            },
            new object[]
            {
                GhostControllerPinkyTestMap.TestMapTwoHeight,
                GhostControllerPinkyTestMap.TestMapTwoWidth,
                GhostControllerPinkyTestMap.TestMapTwoTotalScore,
                GhostControllerPinkyTestGrid2.actualGrid,
                GhostControllerPinkyTestGrid2.ActualPacmanCoordinate,
                GhostControllerPinkyTestGrid2.ActualPinkyCoordinate,
                GhostControllerPinkyTestGrid2.expectedGrid
            },
            new object[]
            {
                GhostControllerPinkyTestMap.TestMapThreeHeight,
                GhostControllerPinkyTestMap.TestMapThreeWidth,
                GhostControllerPinkyTestMap.TestMapThreeTotalScore,
                GhostControllerPinkyTestGrid3.actualGrid,
                GhostControllerPinkyTestGrid3.ActualPacmanCoordinate,
                GhostControllerPinkyTestGrid3.ActualPinkyCoordinate,
                GhostControllerPinkyTestGrid3.expectedGrid
            },
            new object[]
            {
                GhostControllerPinkyTestMap.TestMapFourHeight,
                GhostControllerPinkyTestMap.TestMapFourWidth,
                GhostControllerPinkyTestMap.TestMapFourTotalScore,
                GhostControllerPinkyTestGrid4.actualGrid,
                GhostControllerPinkyTestGrid4.ActualPacmanCoordinate,
                GhostControllerPinkyTestGrid4.ActualPinkyCoordinate,
                GhostControllerPinkyTestGrid4.expectedGrid
            }
        };
}
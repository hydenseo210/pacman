namespace Pacman.Tests;
public class Ghost_Tests
{
    
    [Theory]
    [MemberData(nameof(GhostData))]
    public void When_Move_Is_Called_Ghost_Can_Go_To_PacMan_Along_The_ShortestPath_When_In_Aggressive_Behaviour(
        IGhost ghost, int height, int width, int totalScore, 
        Dictionary<Coordinate,Cell> grid, Coordinate pacmanCoordinate, Coordinate ghostCoordinate, Dictionary<Coordinate,Cell> expectedGrid)
    {
        // Arrange
        ghost.CurrentCoordinate = ghostCoordinate;
        ghost.Trail = new EmptyCell();
        var ghostList = new List<IGhost> { ghost };
        var actualMap = new Map(height, width, totalScore, grid, 
            Stub.ListOfCoordinates, pacmanCoordinate, ghostList);
        var controller = new GhostController();
        // Act 
        controller.Move(actualMap, ghost);
    
        var actualGrid = actualMap.Grid;
        // Assert
        Assert.True(Compare.Dictionaries(expectedGrid, actualGrid));
    }
    
    public static IEnumerable<object[]> GhostData =>
        new List<object[]>
        {
            new object[]
            {
                Dummy.blinky,
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
                Dummy.blinky,
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
                Dummy.blinky,
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
                Dummy.blinky,
                GhostControllerBlinkyTestMap.TestMapFourHeight,
                GhostControllerBlinkyTestMap.TestMapFourWidth,
                GhostControllerBlinkyTestMap.TestMapFourTotalScore,
                GhostControllerBlinkyTestGrid4.actualGrid,
                GhostControllerBlinkyTestGrid4.ActualPacmanCoordinate,
                GhostControllerBlinkyTestGrid4.ActualBlinkyCoordinate,
                GhostControllerBlinkyTestGrid4.expectedGrid
            },
            new object[]
            {
                Dummy.pinky,
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
                Dummy.pinky,
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
                Dummy.pinky,
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
                Dummy.pinky,
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
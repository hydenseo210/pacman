using Moq;

namespace Pacman.Tests;

public class PacmanControllerWallTest
{

    [Theory]
    [MemberData(nameof(WallData))]
    public void Grid_Should_NOT_Update_And_Pacman_Should_Not_Move_When_Hitting_A_Wall_When_Move_Is_Called(
        Directions direction, int height, int width, int totalScore, 
        Dictionary<Coordinate,Cell> grid, Coordinate coordinate,  Dictionary<Coordinate,Cell> expectedGrid)
    {
        // Arrange
        var mockGameStatus = new Mock<IGameStatus>();
        var actualMap = new Map(height, width, totalScore, grid, 
            Stub.ListOfCoordinates, coordinate, Stub.Coordinate , Stub.Coordinate);
        var controller = new PacmanController();
        // Act 
        controller.Move(mockGameStatus.Object, actualMap, direction);
        
        var actualGrid = actualMap.Grid;
        // Assert
        Assert.True(Compare.Dictionaries(expectedGrid, actualGrid));
    }
    
    public static IEnumerable<object[]> WallData =>
        new List<object[]>
        {
            new object[] { Directions.Right, 
                PacmanControllerWallTestMap.TestMapOneHeight, 
                PacmanControllerWallTestMap.TestMapOneWidth, 
                PacmanControllerWallTestMap.TestMapOneTotalScore,
                PacmanControllerWallTestGrid1.actualGrid,
                PacmanControllerWallTestGrid1.ActualPacmanCoordinate,
                PacmanControllerWallTestGrid1.expectedGrid
            },
            new object[] { Directions.Left, 
                PacmanControllerWallTestMap.TestMapTwoHeight, 
                PacmanControllerWallTestMap.TestMapTwoWidth, 
                PacmanControllerWallTestMap.TestMapTwoTotalScore,
                PacmanControllerWallTestGrid2.actualGrid,
                PacmanControllerWallTestGrid2.ActualPacmanCoordinate,
                PacmanControllerWallTestGrid2.expectedGrid,
            },
            new object[] { Directions.Up, 
                PacmanControllerWallTestMap.TestMapThreeHeight, 
                PacmanControllerWallTestMap.TestMapThreeWidth, 
                PacmanControllerWallTestMap.TestMapThreeTotalScore,
                PacmanControllerWallTestGrid3.actualGrid,
                PacmanControllerWallTestGrid3.ActualPacmanCoordinate,
                PacmanControllerWallTestGrid3.expectedGrid,
            },
            new object[] { Directions.Down, 
                PacmanControllerWallTestMap.TestMapFourHeight, 
                PacmanControllerWallTestMap.TestMapFourWidth, 
                PacmanControllerWallTestMap.TestMapFourTotalScore,
                PacmanControllerWallTestGrid4.actualGrid,
                PacmanControllerWallTestGrid4.ActualPacmanCoordinate,
                PacmanControllerWallTestGrid4.expectedGrid,
            }
        };
}

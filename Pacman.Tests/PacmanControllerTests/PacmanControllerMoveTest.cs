using Moq;

namespace Pacman.Tests;

public class PacmanControllerMoveTest
{

    [Theory]
    [MemberData(nameof(MovementData))]
    public void Grid_Should_Update_To_Show_Pacman_New_Coordinate_When_Move_Is_Called(
        Directions direction, int height, int width, int totalScore, Dictionary<Coordinate,Cell> grid, Coordinate coordinate,  Dictionary<Coordinate,Cell> expectedGrid)
    {
        // Arrange
        var actualMap = new Map(height, width, totalScore, grid, 
            Stub.ListOfCoordinates, coordinate, Stub.Coordinate , Stub.Coordinate);
        var controller = new PacmanController();
        // Act 
        controller.Move(actualMap, direction);
        
        var actualGrid = actualMap.Grid;
        // Assert
        Assert.True(Compare.Dictionaries(expectedGrid, actualGrid));
    }
    
    public static IEnumerable<object[]> MovementData =>
        new List<object[]>
        {
            new object[] { Directions.Right, 
                PacmanControllerMoveTestMap.TestMapOneHeight, 
                PacmanControllerMoveTestMap.TestMapOneWidth, 
                PacmanControllerMoveTestMap.TestMapOneTotalScore,
                PacmanControllerMoveTestGrid1.actualGrid,
                PacmanControllerMoveTestGrid1.ActualPacmanCoordinate,
                PacmanControllerMoveTestGrid1.expectedGrid
            },
            new object[] { Directions.Left, 
                PacmanControllerMoveTestMap.TestMapTwoHeight, 
                PacmanControllerMoveTestMap.TestMapTwoWidth, 
                PacmanControllerMoveTestMap.TestMapTwoTotalScore,
                PacmanControllerMoveTestGrid2.actualGrid,
                PacmanControllerMoveTestGrid2.ActualPacmanCoordinate,
                PacmanControllerMoveTestGrid2.expectedGrid,
            },
            new object[] { Directions.Up, 
                PacmanControllerMoveTestMap.TestMapThreeHeight, 
                PacmanControllerMoveTestMap.TestMapThreeWidth, 
                PacmanControllerMoveTestMap.TestMapThreeTotalScore,
                PacmanControllerMoveTestGrid3.actualGrid,
                PacmanControllerMoveTestGrid3.ActualPacmanCoordinate,
                PacmanControllerMoveTestGrid3.expectedGrid,
            },
            new object[] { Directions.Down, 
                PacmanControllerMoveTestMap.TestMapFourHeight, 
                PacmanControllerMoveTestMap.TestMapFourWidth, 
                PacmanControllerMoveTestMap.TestMapFourTotalScore,
                PacmanControllerMoveTestGrid4.actualGrid,
                PacmanControllerMoveTestGrid4.ActualPacmanCoordinate,
                PacmanControllerMoveTestGrid4.expectedGrid,
            }
        };
}

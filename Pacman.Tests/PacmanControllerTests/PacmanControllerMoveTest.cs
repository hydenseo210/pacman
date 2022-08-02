using Moq;

namespace Pacman.Tests;

public class PacmanControllerMoveTest
{

    [Theory]
    [MemberData(nameof(MovementData))]
    public void Should_Update_Grid_To_Show_Pacman_New_Grid_With_Pacman_New_Coordinate_When_Move_Is_Called(
        Directions direction, int height, int width, int totalScore, Dictionary<Coordinate,Cell> grid, Coordinate coordinate,  Dictionary<Coordinate,Cell> expectedGrid)
    {
        // Arrange
        var mockGameStatus = new Mock<IGameStatus>();
        var actualMap = new Map(height, width, totalScore, grid, 
            Stub.ListOfCoordinates, coordinate, Stub.GhostList);
        var controller = new PacmanController();
        // Act 
        controller.Move(mockGameStatus.Object, actualMap, direction);
        
        var actualGrid = actualMap.Grid;
        // Assert
        Assert.True(Compare.Dictionaries(expectedGrid, actualGrid));
    }
    
    [Theory]
    [MemberData(nameof(CoordinateData))]
    public void Should_Update_PacmanCoordinate_To_Show_Pacman_New_Coordinate_When_Move_Is_Called(
        Directions direction, int height, int width, int totalScore, Dictionary<Coordinate,Cell> grid, Coordinate coordinate,  Coordinate expectedCoordinate)
    {
        // Arrange
        var mockGameStatus = new Mock<IGameStatus>();
        var actualMap = new Map(height, width, totalScore, grid, 
            Stub.ListOfCoordinates, coordinate, Stub.GhostList);
        var controller = new PacmanController();
        // Act 
        controller.Move(mockGameStatus.Object, actualMap, direction);
        
        var actualCoordinate = actualMap.PacmanCoordinate;
        // Assert
        Assert.Equal(expectedCoordinate, actualCoordinate);
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
    
    public static IEnumerable<object[]> CoordinateData =>
        new List<object[]>
        {
            new object[] { Directions.Right, 
                PacmanControllerCoordinateTestMap.TestMapOneHeight, 
                PacmanControllerCoordinateTestMap.TestMapOneWidth, 
                PacmanControllerCoordinateTestMap.TestMapOneTotalScore,
                PacmanControllerCoordinateTestGrid1.actualGrid,
                PacmanControllerCoordinateTestGrid1.ActualPacmanCoordinate,
                PacmanControllerCoordinateTestGrid1.ExpectedPacmanCoordinate
            },
            new object[] { Directions.Left, 
                PacmanControllerCoordinateTestMap.TestMapTwoHeight, 
                PacmanControllerCoordinateTestMap.TestMapTwoWidth, 
                PacmanControllerCoordinateTestMap.TestMapTwoTotalScore,
                PacmanControllerCoordinateTestGrid2.actualGrid,
                PacmanControllerCoordinateTestGrid2.ActualPacmanCoordinate,
                PacmanControllerCoordinateTestGrid2.ExpectedPacmanCoordinate
            },
            new object[] { Directions.Up, 
                PacmanControllerCoordinateTestMap.TestMapThreeHeight, 
                PacmanControllerCoordinateTestMap.TestMapThreeWidth, 
                PacmanControllerCoordinateTestMap.TestMapThreeTotalScore,
                PacmanControllerCoordinateTestGrid3.actualGrid,
                PacmanControllerCoordinateTestGrid3.ActualPacmanCoordinate,
                PacmanControllerCoordinateTestGrid3.ExpectedPacmanCoordinate
            },
            new object[] { Directions.Down, 
                PacmanControllerCoordinateTestMap.TestMapFourHeight, 
                PacmanControllerCoordinateTestMap.TestMapFourWidth, 
                PacmanControllerCoordinateTestMap.TestMapFourTotalScore,
                PacmanControllerCoordinateTestGrid4.actualGrid,
                PacmanControllerCoordinateTestGrid4.ActualPacmanCoordinate,
                PacmanControllerCoordinateTestGrid4.ExpectedPacmanCoordinate
            }
        };
}

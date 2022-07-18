using Moq;

namespace Pacman.Tests;

public class PacmanControllerScoreTest
{

    [Theory]
    [MemberData(nameof(ScoreData))]
    public void Should_Increment_GameStatus_Current_Score_By_One_Everytime_Move_Is_Called_And_Destination_Cell_Contains_Food(
        Directions direction, int height, int width, int totalScore, Dictionary<Coordinate,Cell> grid, Coordinate coordinate,  Dictionary<Coordinate,Cell> expectedGrid)
    {
        // Arrange
        var actualGameStatus = new GameStatus();
        var expectedCurrentScore = actualGameStatus.CurrentScore + 1;
        var actualMap = new Map(height, width, totalScore, grid, 
            Stub.ListOfCoordinates, coordinate, Stub.Coordinate , Stub.Coordinate);
        var controller = new PacmanController();
        // Act 
        controller.Move(actualGameStatus, actualMap, direction);
        
        var actualCurrentScore = actualGameStatus.CurrentScore;
        // Assert
        Assert.Equal(expectedCurrentScore, actualCurrentScore);
    }
    
    public static IEnumerable<object[]> ScoreData =>
        new List<object[]>
        {
            new object[] { Directions.Right, 
                PacmanControllerScoreTestMap.TestMapOneHeight, 
                PacmanControllerScoreTestMap.TestMapOneWidth, 
                PacmanControllerScoreTestMap.TestMapOneTotalScore,
                PacmanControllerScoreTestGrid1.actualGrid,
                PacmanControllerScoreTestGrid1.ActualPacmanCoordinate,
                PacmanControllerScoreTestGrid1.expectedGrid
            },
            new object[] { Directions.Left, 
                PacmanControllerScoreTestMap.TestMapTwoHeight, 
                PacmanControllerScoreTestMap.TestMapTwoWidth, 
                PacmanControllerScoreTestMap.TestMapTwoTotalScore,
                PacmanControllerScoreTestGrid2.actualGrid,
                PacmanControllerScoreTestGrid2.ActualPacmanCoordinate,
                PacmanControllerScoreTestGrid2.expectedGrid,
            },
            new object[] { Directions.Up, 
                PacmanControllerScoreTestMap.TestMapThreeHeight, 
                PacmanControllerScoreTestMap.TestMapThreeWidth, 
                PacmanControllerScoreTestMap.TestMapThreeTotalScore,
                PacmanControllerScoreTestGrid3.actualGrid,
                PacmanControllerScoreTestGrid3.ActualPacmanCoordinate,
                PacmanControllerScoreTestGrid3.expectedGrid,
            },
            new object[] { Directions.Down, 
                PacmanControllerScoreTestMap.TestMapFourHeight, 
                PacmanControllerScoreTestMap.TestMapFourWidth, 
                PacmanControllerScoreTestMap.TestMapFourTotalScore,
                PacmanControllerScoreTestGrid4.actualGrid,
                PacmanControllerScoreTestGrid4.ActualPacmanCoordinate,
                PacmanControllerScoreTestGrid4.expectedGrid,
            }
        };
}

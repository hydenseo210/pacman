using Moq;

namespace Pacman.Tests;

public class GameTests
{

    [Fact]
    public void Should_Decrement_GameStatus_LivesList_Count_By_One_When_Collision_Between_Pacman_And_Ghost_Happens()
    {
        //Arrange
        var actualGameStatus = new GameStatus();
        var expectedLivesLeft = actualGameStatus.LivesList.Count - 1;
        var mockMap = new Mock<IMap>();
        var ghostList = new List<IGhost> { Dummy.blinky, Dummy.pinky };
        mockMap.Setup(x => x.Height).Returns(GameTestCollisionTestMap.Height);
        mockMap.Setup(x => x.Width).Returns(GameTestCollisionTestMap.Width);
        mockMap.Setup(x => x.Grid).Returns(GameTestCollisionTestGrid.actualGrid);
        mockMap.Setup(x => x.PacmanCoordinate).Returns(GameTestCollisionTestGrid.ActualPacmanCoordinate);
        mockMap.SetupSequence(x => x.IsCollisionWithGhost).Returns(false).Returns(false).Returns(true);
        mockMap.Setup(x => x.GhostList).Returns(ghostList);

        var pacmanController = new PacmanController();
        var mockGhostController = new Mock<IGhostController>();

        //Act
        var game = new Game(actualGameStatus, mockMap.Object, Stub.QueueMap, pacmanController, mockGhostController.Object);
        game.Tick(Directions.Right);
        var actualLivesLeft = actualGameStatus.LivesList.Count;
        // Assert
        Assert.Equal(expectedLivesLeft, actualLivesLeft);
    }

    [Theory]
    [MemberData(nameof(ResetCoordinateData))]
    public void
        Should_Reset_Pacman_And_Ghost_Coordinate_To_Starting_Coordinate_When_Collision_Between_Pacman_And_Ghost_Is_Set_To_True(
            int height, int width, int totalScore, Dictionary<Coordinate,Cell> grid, 
            Coordinate pacmanCoordinate,  Coordinate blinkyCoordinate, Coordinate pinkyCoordinate, Dictionary<Coordinate,Cell> expectedGrid)
    {
        //Arrange
        var mockGameStatus = new Mock<IGameStatus>();
        mockGameStatus.Setup(x => x.LivesList).Returns(Stub.ListOfThreeLives);
        var blinky = new Blinky(new AggressiveBehaviour());
        var pinky = new Pinky(new AggressiveBehaviour());
        blinky.CurrentCoordinate = blinkyCoordinate;
        pinky.CurrentCoordinate = pinkyCoordinate;
        var ghostList = new List<IGhost> { blinky, pinky };
        var actualMap = new Map(height, width, totalScore, grid, Stub.ListOfCoordinates, pacmanCoordinate, ghostList);
        var pacmanController = new PacmanController();
        var ghostController = new GhostController();
        var game = new Game(mockGameStatus.Object, actualMap, Stub.QueueMap, pacmanController,
            ghostController);
        
        //Act
        game.Tick(Directions.Right);
        var actualGrid = actualMap.Grid;
        // Assert
        Assert.True(Compare.Dictionaries(expectedGrid, actualGrid));
    }
    
    public static IEnumerable<object[]> ResetCoordinateData =>
        new List<object[]>
        {
            new object[]
            {
                GameTestResetTestMap.Height,
                GameTestResetTestMap.Width,
                GameTestResetTestMap.TotalScore,
                GameTestResetTestGrid.actualGrid,
                GameTestResetTestGrid.ActualPacmanCoordinate,
                GameTestResetTestGrid.ActualBlinkyCoordinate,
                GameTestResetTestGrid.ActualPinkyCoordinate,
                GameTestResetTestGrid.expectedGrid

            }
        };

}
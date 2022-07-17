using Moq;
using Pacman.Tests;

namespace Pacman.Code;

public class GameTests
{

    [Fact]
    public void When_Collision_Between_Pacman_And_Ghost_Happens_Life_is_Lost()
    {
        //Arrange
        var actualGameStatus = new GameStatus();
        var expectedLivesLeft = actualGameStatus.LivesList.Count - 1;
        var mockMap = new Mock<IMap>();
        
        mockMap.Setup(x => x.Height).Returns(GameTestMap.Height);
        mockMap.Setup(x => x.Width).Returns(GameTestMap.Width);
        mockMap.Setup(x => x.Grid).Returns(GameTestGrid.actualGrid);
        
        var pacmanController = new PacmanController();
        var mockGhostController = new Mock<IGhostController>();

        var game = new Game(actualGameStatus, mockMap.Object, Stub.QueueMap, pacmanController, mockGhostController.Object);
        //Act
        var actualLivesLeft = actualGameStatus.LivesList.Count;
        // Assert
        Assert.Equal(expectedLivesLeft, actualLivesLeft);
        
    }
    
    // [Fact]
    // public void When_Pacman_EatsFood_CurrentScore_Goes_Up_By_One()
    // {
    //     
    //     //Arrange
    //     
    //     //Act
    //     game.MovePacman(Directions.Right);
    //     var actualCurrentScore = actualGameState.CurrentScore;
    //     var expectedCurrentScore = expectedGameState.CurrentScore + 1;
    //     // Assert
    //     Assert.Equal(expectedCurrentScore,actualCurrentScore);
    //     
    // }

}
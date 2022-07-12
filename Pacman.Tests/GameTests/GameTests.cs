using Pacman.Tests;
namespace Pacman.Code;

public class GameTests
{

    [Fact]
    public void When_Collision_Between_Pacman_And_Ghost_Happens_Life_is_Lost()
    {
        var gameStateGenerator = new GameStateGenerator();
        var actualGameState =gameStateGenerator.InitiateGameState(1, 6, 0, new Coordinate(0, 1), Directions.Right);
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,0));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,5));
        gameStateGenerator.SetBlinkyLocation(new Coordinate(0,3));
        gameStateGenerator.SetPinkyLocation(new Coordinate(0,4));
        var gameStateQueue = new Queue<GameState>() { };
        var console = new ConsoleWrapper();
        var pacmanController = new PacmanController();
        var ghostController = new GhostController(new Blinky(new AggressiveBehaviour()), new Pinky(new AggressiveBehaviour()));
        var game = new Game(actualGameState, gameStateQueue, pacmanController, ghostController,console);
        gameStateGenerator.ResetMap();
        
        var expectedGameState =gameStateGenerator.InitiateGameState(1, 6, 0, new Coordinate(0, 1), Directions.Right);
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,0));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,5));
        gameStateGenerator.SetBlinkyLocation(new Coordinate(0,3));
        gameStateGenerator.SetPinkyLocation(new Coordinate(0,4));
        
        expectedGameState.LivesList.RemoveAt(0);
        
        game.MovePacman(Directions.Right);
        game.MovePacman(Directions.Right);
        game.MovePacman(Directions.Right);

        var actualLivesLeft = actualGameState.LivesList.Count;
        var expectedLivesLeft = expectedGameState.LivesList.Count;
        // Assert
        Assert.Equal(expectedLivesLeft,actualLivesLeft);
        
    }
    
    [Fact]
    public void When_Pacman_EatsFood_CurrentScore_Goes_Up_By_One()
    {
        var gameStateGenerator = new GameStateGenerator();
        var actualGameState =gameStateGenerator.InitiateGameState(1, 6, 1, new Coordinate(0, 1), Directions.Right);
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,0));
        gameStateGenerator.SetCellToVerticalWall(new Coordinate(0,5));
        gameStateGenerator.SetBlinkyLocation(new Coordinate(0,3));
        gameStateGenerator.SetPinkyLocation(new Coordinate(0,4));
        var gameStateQueue = new Queue<GameState>() { };
        var console = new ConsoleWrapper();
        var pacmanController = new PacmanController();
        var ghostController = new GhostController(new Blinky(new AggressiveBehaviour()), new Pinky(new AggressiveBehaviour()));
        var game = new Game(actualGameState, gameStateQueue, pacmanController, ghostController,console);
        gameStateGenerator.ResetMap();
        
        var expectedGameState =gameStateGenerator.InitiateGameState(1, 6, 1, new Coordinate(0, 1), Directions.Right);
        gameStateGenerator.SetCellToHorizontalWall(new Coordinate(0,0));
        gameStateGenerator.SetCellToHorizontalWall(new Coordinate(0,5));
        gameStateGenerator.SetBlinkyLocation(new Coordinate(0,3));
        gameStateGenerator.SetPinkyLocation(new Coordinate(0,4));
        
        
        game.MovePacman(Directions.Right);

        var actualCurrentScore = actualGameState.CurrentScore;
        var expectedCurrentScore = expectedGameState.CurrentScore + 1;
        // Assert
        Assert.Equal(expectedCurrentScore,actualCurrentScore);
        
    }
    
    private bool Compare(Dictionary<Coordinate, Cell> x, Dictionary<Coordinate, Cell> y)
    {
        if (x.Count != y.Count)
            return false;
        if (x.Keys.Except(y.Keys).Any())
            return false;
        if (y.Keys.Except(x.Keys).Any())
            return false;
        foreach (var pair in x)
            if(x[pair.Key].GetType() != y[pair.Key].GetType())
                return false;
        return true;
    }
    
}
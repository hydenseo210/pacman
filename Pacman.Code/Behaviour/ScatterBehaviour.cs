namespace Pacman.Code;

public class ScatterBehaviour : IChaseBehaviour
{
    public List<Coordinate> Chase(GameState gameState, Coordinate ghostLocation)
    {
        var algorithm = new AStarSearchAlgorithm();
        return algorithm.Execute(gameState, ghostLocation, this);
    }
}
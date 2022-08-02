namespace Pacman.Code;

public class ScatterBehaviour : IChaseBehaviour
{
    public List<Coordinate> Chase(IMap map, Coordinate ghostCoordinate)
    {
        var algorithm = new AStarSearchAlgorithm();
        return algorithm.Execute(map, ghostCoordinate, this);
    }
}
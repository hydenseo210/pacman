namespace Pacman.Code;

public class GhostController
{
    private readonly AStarSearchAlgorithm _searchAlgorithm;
    private Cell? _trail;
    
    public GhostController(AStarSearchAlgorithm searchAlgorithm)
    {
        _searchAlgorithm = searchAlgorithm;
    }

    public List<Coordinate> Move(GameState gameState) => 
        _searchAlgorithm.Execute(gameState);

    public Cell GhostTrail(GameState gameState, Coordinate coordinate)
    {
        _trail = gameState.Map[coordinate];
        return _trail;
    }
    
}
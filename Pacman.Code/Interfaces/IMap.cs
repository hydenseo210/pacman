namespace Pacman.Code;

public interface IMap
{
    public int Height { get; set; }
    public int Width { get; set; }
    public int TotalScore { get; set; }
    public Dictionary<Coordinate, Cell> Grid { get; set; }
    public List<Coordinate> GhostGateCoordinates { get; set; }
    public Coordinate PacmanCoordinate { get; set; }
    public List<IGhost> GhostList { get; set; }
    public bool IsCollisionWithGhost { get; set; }
}
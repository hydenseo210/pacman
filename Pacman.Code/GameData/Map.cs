namespace Pacman.Code;

public class Map : IMap
{
    public int Height { get; set; }
    public int Width { get; set; }
    public int TotalScore { get; set; }
    public Dictionary<Coordinate, Cell> Grid { get; set; }
    public List<Coordinate> GhostGateCoordinates { get; set; }
    public Coordinate PacmanCoordinate { get; set; }
    public List<IGhost> GhostList { get; set; }
    public bool IsCollisionWithGhost { get; set; }
    public Map(int height,
        int width,
        int totalScore,
        Dictionary<Coordinate, Cell> grid,
        List<Coordinate> ghostGateCoordinates,
        Coordinate pacmanLocation,
        List<IGhost> ghostList, bool isCollisionWithGhost = false)
    {
        Height = height;
        Width = width;
        TotalScore = totalScore;
        Grid = grid;
        GhostGateCoordinates = ghostGateCoordinates;
        PacmanCoordinate = pacmanLocation;
        GhostList = ghostList;
        IsCollisionWithGhost = isCollisionWithGhost;
    }

    public void AddToMap(Coordinate location, Cell cell) => Grid.Add(location, cell);
    public void AddToGhostGate(Coordinate location) => GhostGateCoordinates.Add(location);

}
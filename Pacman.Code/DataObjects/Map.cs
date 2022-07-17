namespace Pacman.Code;

public class Map : IMap
{
    public int Height { get; set; }
    public int Width { get; set; }
    public int TotalScore { get; set; }
    public Dictionary<Coordinate, Cell> Grid { get; set; }
    public List<Coordinate> GhostGateCoordinates { get; set; }
    public Coordinate PacmanCoordinate { get; set; }
    public Coordinate BlinkyCoordinate { get; set; }
    public Coordinate PinkyCoordinate { get; set; }
    public bool IsCollisionWithGhost { get; set; }
    public Map(int height,
        int width,
        int totalScore,
        Dictionary<Coordinate, Cell> grid,
        List<Coordinate> ghostGateCoordinates,
        Coordinate pacmanLocation,
        Coordinate blinkyLocation,
        Coordinate pinkyLocation, 
        bool isCollisionWithGhost = false)
    {
        Height = height;
        Width = width;
        TotalScore = totalScore;
        Grid = grid;
        GhostGateCoordinates = ghostGateCoordinates;
        PacmanCoordinate = pacmanLocation;
        BlinkyCoordinate = blinkyLocation;
        PinkyCoordinate = pinkyLocation;
        IsCollisionWithGhost = isCollisionWithGhost;
    }

    public void AddToMap(Coordinate location, Cell cell) => Grid.Add(location, cell);
    public void AddToGhostGate(Coordinate location) => GhostGateCoordinates.Add(location);

}
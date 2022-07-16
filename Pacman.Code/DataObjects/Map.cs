namespace Pacman.Code;

public class Map : IMap
{
    public int Height { get; set; }
    public int Width { get; set; }
    public int TotalScore { get; set; }
    public Dictionary<Coordinate, Cell> Grid { get; set; }
    public List<Coordinate> GhostGateCoordinates { get; set; }
    public Coordinate PacmanCoordinate { get; set; }
    public Coordinate BlinkyLocation { get; set; }
    public Coordinate PinkyLocation { get; set; }
    public Map(int height, 
        int width, 
        int totalScore,
        Dictionary<Coordinate, Cell> grid, 
        List<Coordinate> ghostGateCoordinates, 
        Coordinate pacmanLocation, 
        Coordinate blinkyLocation, 
        Coordinate pinkyLocation)
    {
        Height = height;
        Width = width;
        TotalScore = totalScore;
        Grid = grid;
        GhostGateCoordinates = ghostGateCoordinates;
        PacmanCoordinate = pacmanLocation;
        BlinkyLocation = blinkyLocation;
        PinkyLocation = pinkyLocation;
    }

    public void AddToMap(Coordinate location, Cell cell) => Grid.Add(location, cell);
    public void AddToGhostGate(Coordinate location) => GhostGateCoordinates.Add(location);

}
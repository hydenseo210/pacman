namespace Pacman.Code;

public record GameState(
    int Height,
    int Width,
    Dictionary<Coordinate, Cell> Map,
    List<Coordinate> GhostGateLocation,
    int TotalScore)
{
    public int CurrentScore { get; set; } = 0;
    public bool IsCollisionWithGhost { get; set; } = false;
    
    public bool GodMode { get; set; } = false;
    
    public List<string> LivesList { get; set; } = new(){ Emojis.Life };
    public Coordinate PacmanLocation { get; set; } = default!;
    public Coordinate BlinkyLocation { get; set; } = default!;
    public Coordinate PinkyLocation { get; set; } = default!;
}
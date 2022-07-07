namespace Pacman.Code;

public record GameState(
    int Height,
    int Width,
    Dictionary<Coordinate, Cell> Map,
    List<Coordinate> GhostGateLocation,
    int TotalScore)
{

    public Coordinate PacmanLocation { get; set; } = default!;
    public Coordinate BlinkyLocation { get; set; } = default!;
    public Coordinate PinkyLocation { get; set; } = default!;
}
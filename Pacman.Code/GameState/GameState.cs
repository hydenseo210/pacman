namespace Pacman.Code;

public record GameState(
    int Height,
    int Width,
    IDictionary<Coordinate, Cell> Map,
    List<Coordinate> GhostGateLocation,
    int TotalScore)
{

    public Coordinate PacmanLocation { get; set; } = default!;
    public Coordinate GhostLocation { get; set; } = default!;
}
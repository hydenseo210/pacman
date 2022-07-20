namespace Pacman.Tests;

public static class Dummy
{
    private static readonly IChaseBehaviour aggressiveBehaviour = new AggressiveBehaviour();
    public static readonly Blinky blinky = new Blinky(aggressiveBehaviour);
    public static readonly Pinky pinky = new Pinky(aggressiveBehaviour);
    public static readonly Inky Inky = new Inky(aggressiveBehaviour);
    public static readonly Clyde clyde = new Clyde(aggressiveBehaviour);
}
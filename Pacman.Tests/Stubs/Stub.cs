namespace Pacman.Tests;

public static class Stub
{
    public static readonly Coordinate Coordinate = new (0, 0);
    public static readonly Queue<IMap> QueueMap = new ();
    public static readonly List<string> ListOfThreeLives = new() { Emojis.Life, Emojis.Life, Emojis.Life };
    public static readonly List<Coordinate> ListOfCoordinates = new ();
    public static readonly IGhost AggressivePinky = new Pinky(new AggressiveBehaviour());
    public static readonly IGhost AggressiveBlinky = new Blinky(new AggressiveBehaviour());
    
}
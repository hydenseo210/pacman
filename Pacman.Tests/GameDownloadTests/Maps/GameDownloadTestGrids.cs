namespace Pacman.Tests;

public static class GameDownloadTestGrids
{
    public static readonly Dictionary<Coordinate, Cell> gridOne = new ()
    {
        [new Coordinate(0,0)] = new ThePacman(),
        [new Coordinate(0,1)] = new Pinky(new AggressiveBehaviour()),
        [new Coordinate(0,2)] = new Blinky(new AggressiveBehaviour()),
        [new Coordinate(0,3)] = new Food(),
        [new Coordinate(0,4)] = new WallUpLeft(),
        [new Coordinate(0,5)] = new WallUpRight(),
        [new Coordinate(0,6)] = new WallDownLeft(),
        [new Coordinate(0,7)] = new WallDownRight(),
        [new Coordinate(0,8)] = new WallHorizontal(),
        [new Coordinate(0,9)] = new WallUpMiddle(),
        [new Coordinate(0,10)] = new WallRightMiddle(),
        [new Coordinate(0,11)] = new WallLeftMiddle(),
        [new Coordinate(0,12)] = new WallDownMiddleThick(),
        [new Coordinate(0,13)] = new WallVertical(),
        [new Coordinate(0,14)] = new WallCross(),
        [new Coordinate(0,15)] = new GhostGate()

    };

    public static readonly List<Coordinate> ghostGateListForGridOne = new()
    {
        new Coordinate(0, 15)
    };

    public static readonly Coordinate pacmanCoordinateForGridOne = new (0, 0);
    public static readonly Coordinate pinkyCoordinateForGridOne = new (0, 1);
    public static readonly Coordinate blinkyCoordinateForGridOne = new (0, 2);
}
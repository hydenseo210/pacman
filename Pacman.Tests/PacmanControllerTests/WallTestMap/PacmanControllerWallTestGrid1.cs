namespace Pacman.Tests;

public static class PacmanControllerWallTestGrid1
{
    public static readonly Dictionary<Coordinate, Cell> actualGrid = new ()
    {
        [new Coordinate(0,0)] = new WallVertical(),
        [new Coordinate(0,1)] = new ThePacman(),
        [new Coordinate(0,2)] = new WallVertical(),
        [new Coordinate(0,3)] = new Food(),
        [new Coordinate(0,4)] = new Food(),
        [new Coordinate(0,5)] = new Food(),
        [new Coordinate(0,6)] = new WallVertical()
        
        // ║<║∘∘∘║
    };
    public static readonly Dictionary<Coordinate, Cell> expectedGrid = new ()
    {
        [new Coordinate(0,0)] = new WallVertical(),
        [new Coordinate(0,1)] = new ThePacman(),
        [new Coordinate(0,2)] = new WallVertical(),
        [new Coordinate(0,3)] = new Food(),
        [new Coordinate(0,4)] = new Food(),
        [new Coordinate(0,5)] = new Food(),
        [new Coordinate(0,6)] = new WallVertical()
        
        // ║<║∘∘∘║
    };
    
    public static readonly Coordinate ActualPacmanCoordinate = new (0, 1);
    public static readonly Coordinate ExpectedPacmanCoordinateForGridOne = new (0, 2);

}
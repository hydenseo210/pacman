namespace Pacman.Tests;

public class GhostControllerBlinkyTestGrid1
{
    public static readonly Dictionary<Coordinate, Cell> actualGrid = new ()
    {
        
        [new Coordinate(0,0)] = new WallVertical(),
        [new Coordinate(0,1)] = new Food(),
        [new Coordinate(0,2)] = new Food(),
        [new Coordinate(0,3)] = new Food(),
        [new Coordinate(0,4)] = new Food(),
        [new Coordinate(0,5)] = new Food(),
        [new Coordinate(0,6)] = new Food(),
        [new Coordinate(0,7)] = new Food(),
        [new Coordinate(0,8)] = new Food(),
        [new Coordinate(0,9)] = new Food(),
        [new Coordinate(0,10)] = new WallVertical(),
        
        [new Coordinate(1,0)] = new WallVertical(),
        [new Coordinate(1,1)] = new Food(),
        [new Coordinate(1,3)] = new Food(),
        [new Coordinate(1,4)] = new Food(),
        [new Coordinate(1,5)] = new Food(),
        [new Coordinate(1,6)] = new Food(),
        [new Coordinate(1,7)] = new Food(),
        [new Coordinate(1,8)] = new Food(),
        [new Coordinate(1,9)] = new Food(),
        [new Coordinate(1,10)] = new Food(),
        [new Coordinate(1,11)] = new WallVertical(),
        
        [new Coordinate(2,0)] = new WallVertical(),
        [new Coordinate(2,1)] = new ThePacman(),
        [new Coordinate(2,2)] = new Food(),
        [new Coordinate(2,3)] = new Food(),
        [new Coordinate(2,4)] = new Food(),
        [new Coordinate(2,5)] = new Blinky(new AggressiveBehaviour()),
        [new Coordinate(2,6)] = new Food(),
        [new Coordinate(2,7)] = new Food(),
        [new Coordinate(2,8)] = new Food(),
        [new Coordinate(2,9)] = new Food(),
        [new Coordinate(2,10)] = new WallVertical(),
        
        [new Coordinate(3,0)] = new WallVertical(),
        [new Coordinate(3,1)] = new Food(),
        [new Coordinate(3,2)] = new Food(),
        [new Coordinate(3,3)] = new Food(),
        [new Coordinate(3,4)] = new Food(),
        [new Coordinate(3,5)] = new Food(),
        [new Coordinate(3,6)] = new Food(),
        [new Coordinate(3,7)] = new Food(),
        [new Coordinate(3,8)] = new Food(),
        [new Coordinate(3,9)] = new Food(),
        [new Coordinate(3,10)] = new WallVertical(),
        
        [new Coordinate(4,0)] = new WallVertical(),
        [new Coordinate(4,1)] = new Food(),
        [new Coordinate(4,2)] = new Food(),
        [new Coordinate(4,3)] = new Food(),
        [new Coordinate(4,4)] = new Food(),
        [new Coordinate(4,5)] = new Food(),
        [new Coordinate(4,6)] = new Food(),
        [new Coordinate(4,7)] = new Food(),
        [new Coordinate(4,8)] = new Food(),
        [new Coordinate(4,9)] = new Food(),
        [new Coordinate(4,10)] = new WallVertical()
        
        
        // ║∘∘∘∘∘∘∘∘║
        // ║∘∘∘∘∘∘∘∘║
        // ║<∘∘∘ß∘∘∘║
        // ║∘∘∘∘∘∘∘∘║
        // ║∘∘∘∘∘∘∘∘║
    };
    public static readonly Dictionary<Coordinate, Cell> expectedGrid = new ()
    {
        
        [new Coordinate(0,0)] = new WallVertical(),
        [new Coordinate(0,1)] = new Food(),
        [new Coordinate(0,2)] = new Food(),
        [new Coordinate(0,3)] = new Food(),
        [new Coordinate(0,4)] = new Food(),
        [new Coordinate(0,5)] = new Food(),
        [new Coordinate(0,6)] = new Food(),
        [new Coordinate(0,7)] = new Food(),
        [new Coordinate(0,8)] = new Food(),
        [new Coordinate(0,9)] = new Food(),
        [new Coordinate(0,10)] = new WallVertical(),
        
        [new Coordinate(1,0)] = new WallVertical(),
        [new Coordinate(1,1)] = new Food(),
        [new Coordinate(1,3)] = new Food(),
        [new Coordinate(1,4)] = new Food(),
        [new Coordinate(1,5)] = new Food(),
        [new Coordinate(1,6)] = new Food(),
        [new Coordinate(1,7)] = new Food(),
        [new Coordinate(1,8)] = new Food(),
        [new Coordinate(1,9)] = new Food(),
        [new Coordinate(1,10)] = new Food(),
        [new Coordinate(1,11)] = new WallVertical(),
        
        [new Coordinate(2,0)] = new WallVertical(),
        [new Coordinate(2,1)] = new ThePacman(),
        [new Coordinate(2,2)] = new Food(),
        [new Coordinate(2,3)] = new Food(),
        [new Coordinate(2,4)] = new Blinky(new AggressiveBehaviour()),
        [new Coordinate(2,5)] = new Food(),
        [new Coordinate(2,6)] = new Food(),
        [new Coordinate(2,7)] = new Food(),
        [new Coordinate(2,8)] = new Food(),
        [new Coordinate(2,9)] = new Food(),
        [new Coordinate(2,10)] = new WallVertical(),
        
        [new Coordinate(3,0)] = new WallVertical(),
        [new Coordinate(3,1)] = new Food(),
        [new Coordinate(3,2)] = new Food(),
        [new Coordinate(3,3)] = new Food(),
        [new Coordinate(3,4)] = new Food(),
        [new Coordinate(3,5)] = new Food(),
        [new Coordinate(3,6)] = new Food(),
        [new Coordinate(3,7)] = new Food(),
        [new Coordinate(3,8)] = new Food(),
        [new Coordinate(3,9)] = new Food(),
        [new Coordinate(3,10)] = new WallVertical(),
        
        [new Coordinate(4,0)] = new WallVertical(),
        [new Coordinate(4,1)] = new Food(),
        [new Coordinate(4,2)] = new Food(),
        [new Coordinate(4,3)] = new Food(),
        [new Coordinate(4,4)] = new Food(),
        [new Coordinate(4,5)] = new Food(),
        [new Coordinate(4,6)] = new Food(),
        [new Coordinate(4,7)] = new Food(),
        [new Coordinate(4,8)] = new Food(),
        [new Coordinate(4,9)] = new Food(),
        [new Coordinate(4,10)] = new WallVertical()
        
        
        // ║∘∘∘∘∘∘∘∘║
        // ║∘∘∘∘∘∘∘∘║
        // ║<∘∘ß∘∘∘∘║
        // ║∘∘∘∘∘∘∘∘║
        // ║∘∘∘∘∘∘∘∘║
    };
    
    public static readonly Coordinate ActualPacmanCoordinate = new (2, 1);
    public static readonly Coordinate ActualBlinkyCoordinate = new (2, 5);
    public static readonly Coordinate ExpectedPacmanCoordinate = new (2, 1);
    public static readonly Coordinate ExpectedBlinkyCoordinate = new (2, 4);
    
    
}
namespace Pacman.Tests;

public static class PacmanControllerMoveTestGrid4
{
    public static readonly Dictionary<Coordinate, Cell> actualGrid = new ()
    {
        [new Coordinate(0,0)] = new WallHorizontal(),
        [new Coordinate(1,0)] = new ThePacman(Directions.Down),
        [new Coordinate(2,0)] = new Food(),
        [new Coordinate(3,0)] = new Food(),
        [new Coordinate(4,0)] = new Food(),
        [new Coordinate(5,0)] = new Food(),
        [new Coordinate(6,0)] = new WallHorizontal()
        
        // ═            ═
        // ⋀             
        // ∘            ⋀
        // ∘   ===>     ∘
        // ∘            ∘
        // ∘            ∘
        // ═            ═
    };
    public static readonly Dictionary<Coordinate, Cell> expectedGrid = new ()
    {
        [new Coordinate(0,0)] = new WallHorizontal(),
        [new Coordinate(1,0)] = new EmptyCell(),
        [new Coordinate(2,0)] = new ThePacman(Directions.Down),
        [new Coordinate(3,0)] = new Food(),
        [new Coordinate(4,0)] = new Food(),
        [new Coordinate(5,0)] = new Food(),
        [new Coordinate(6,0)] = new WallHorizontal()
        
    };
    
    public static readonly Coordinate ActualPacmanCoordinate = new (1, 0);
    public static readonly Coordinate ExpectedPacmanCoordinate = new (2, 0);
   
}
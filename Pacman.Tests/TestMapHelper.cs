namespace Pacman.Tests;

public class TestMapHelper
{
  
  public Dictionary<Coordinate, Cell> SetUpInitialMap()
  {
      return new Dictionary<Coordinate, Cell>()
        {
            [new Coordinate(0, 0)] = new Food(),
            [new Coordinate(0, 1)] = new Food(),
            [new Coordinate(0, 2)] = new Food(),
            [new Coordinate(0, 3)] = new Food(),
            [new Coordinate(0, 4)] = new Food(),

            [new Coordinate(1, 0)] = new Food(),
            [new Coordinate(1, 1)] = new Food(),
            [new Coordinate(1, 2)] = new Food(),
            [new Coordinate(1, 3)] = new Food(),
            [new Coordinate(1, 4)] = new Food(),

            [new Coordinate(2, 0)] = new Food(),
            [new Coordinate(2, 1)] = new Food(),
            [new Coordinate(2, 2)] = new Food(),
            [new Coordinate(2, 3)] = new Food(),
            [new Coordinate(2, 4)] = new Food(),

            [new Coordinate(3, 0)] = new Food(),
            [new Coordinate(3, 1)] = new Food(),
            [new Coordinate(3, 2)] = new Food(),
            [new Coordinate(3, 3)] = new Food(),
            [new Coordinate(3, 4)] = new Food(),

            [new Coordinate(4, 0)] = new Food(),
            [new Coordinate(4, 1)] = new Food(),
            [new Coordinate(4, 2)] = new Food(),
            [new Coordinate(4, 3)] = new Food(),
            [new Coordinate(4, 4)] = new Food()
        };
  }


  public void SetPacmanPosition(Coordinate position, Directions direction, Dictionary<Coordinate, Cell> map)
  {
    if(map != null)
    {
      map[position] = new ThePacman(direction);
      
    }
    Console.WriteLine("map null");
  }

  


}
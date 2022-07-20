Each Ghost contain a dependancy injection of IChaseBehaviour which determines the ghosts movement behaviour
according to pacman's location. Using the Strategy pattern, the ghosts can 
apply different strategies according to changes within the game.

In this game strategy is changed based on which pellet pacman eats.
```csharp
public interface IChaseBehaviour
{
    List<Coordinate> Chase(IMap map, Coordinate ghostCoordinate);
}
```
Ghosts can contain different types of behaviour depending on their chase behaviour
```csharp
public class Blinky: Cell, IGhost
    {
        private IChaseBehaviour _chaseBehaviour;
        
        public Blinky(IChaseBehaviour chaseBehaviour)
        {
            _chaseBehaviour = chaseBehaviour;
        }
    }
```
Aggressive chase behaviour allows ghosts to follow pacman along the shortest path using A* Algorithm
```csharp
public class AggressiveBehaviour : IChaseBehaviour
{
    public List<Coordinate> Chase(IMap map, Coordinate ghostCoordinate)
    {
        var algorithm = new AStarSearchAlgorithm();
        return algorithm.Execute(map, ghostCoordinate, this);
    }
}
```
Frightened chase behaviour means that the ghost will run away from Pacman and stay on the map with the highest cost distance
```csharp
public class FrightenedBehaviour : IChaseBehaviour
{
    public List<Coordinate> Chase(IMap map, Coordinate ghostCoordinate)
    {
        var algorithm = new AStarSearchAlgorithm();
        return algorithm.Execute(map, ghostCoordinate, this);
    }
}
```

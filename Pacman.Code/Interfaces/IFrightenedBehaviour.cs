namespace Pacman.Code;

public interface IFrightenedBehaviour
{
    Coordinate Fright(IMap map, Coordinate pacmanCoordinate);
}
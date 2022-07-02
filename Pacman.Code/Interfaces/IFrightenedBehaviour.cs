namespace Pacman.Code;

public interface IFrightenedBehaviour
{
    Coordinate Fright(Coordinate ghostLocation, Coordinate pacmanLocation);
}
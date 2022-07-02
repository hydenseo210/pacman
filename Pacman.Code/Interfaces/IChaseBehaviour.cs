namespace Pacman.Code;

public interface IChaseBehaviour
{
    Coordinate Chase(Coordinate ghostLocation, Coordinate pacmanLocation);
}
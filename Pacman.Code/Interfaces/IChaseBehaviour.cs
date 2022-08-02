namespace Pacman.Code;

public interface IChaseBehaviour
{
    List<Coordinate> Chase(IMap map, Coordinate ghostCoordinate);
}
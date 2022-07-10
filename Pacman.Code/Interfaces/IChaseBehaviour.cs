namespace Pacman.Code;

public interface IChaseBehaviour
{
    List<Coordinate> Chase(GameState gameState, Coordinate pacmanLocation);
}
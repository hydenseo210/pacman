namespace Pacman.Code;

public interface IGhost
{ 
    public void CreateMoveList(GameState gameState);
    public void ChangeBehaviour(IChaseBehaviour chaseBehaviour);
    public Coordinate Move();
}
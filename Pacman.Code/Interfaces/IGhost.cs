namespace Pacman.Code;

public interface IGhost
{ 
    public void CreateMoveList(IMap map);
    public void ChangeBehaviour(IChaseBehaviour chaseBehaviour);
    public Coordinate Move();
    public void RemoveLast();
}
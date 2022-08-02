namespace Pacman.Code;

public interface IGhostController
{
    public void Move(IMap map, IGhost ghost);
    public void Reset(IMap map, IGhost ghost);
    public void ChangeGhostBehaviour(IGhost ghost);
    public void SetGhostToFrozen(IGhost ghost);
}
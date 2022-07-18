namespace Pacman.Code;

public class GhostController : IGhostController
{
    
    public void Move(IMap map, IGhost ghost)
    {
        ghost.CreateMoveList(map);
        ghost.RemoveLast();
        var departure = ghost.CurrentCoordinate;
        var destination = ghost.Move();

        if (departure == destination) return;

        if(map.Grid[destination] is ThePacman)
        {
            map.IsCollisionWithGhost = true;
            ghost.Trail = new EmptyCell();
            return;
        }
        
        var previousTrail = ghost.Trail;
        ghost.Trail = map.Grid[destination];
        map.Grid[destination] = map.Grid[departure];
        map.Grid[departure] = previousTrail;
        ghost.CurrentCoordinate = destination;
    }

    public void Reset(IMap map, IGhost ghost) => ghost.CreateMoveList(map); 
    public void ChangeGhostBehaviour(IGhost ghost) => ghost.ChangeBehaviour();
    public void SetGhostToFrozen(IGhost ghost) => ghost.SetToFrozen();
    
}
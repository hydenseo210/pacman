namespace Pacman.Code;

public interface IGhost
{ 
    public Cell Trail { get; set; }
    public Coordinate CurrentCoordinate { get; set; }
    public Coordinate StartingCoordinate { get; set; }
    public void CreateMoveList(IMap map);
    public void ChangeBehaviour();
    public Coordinate Move();
    public void RemoveLast();
    public void SetToFrozen();
}
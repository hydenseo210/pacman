namespace Pacman.Code;

public interface IGameState
{
    public IGameState Reset();
    public IGameState SetHeight(int number);
    public IGameState SetWidth(int number);
    public IGameState SetMap(IDictionary<Coordinate, Cell> map);
    public IGameState SetGhostGateLocation(List<Coordinate> ghostGateCoordinates);
    public IGameState SetTotalScore(int totalScore);
    public IGameState SetPacmanLocation(Coordinate coordinate);
    public IGameState SetBlinkyLocation(Coordinate coordinate);
    public IGameState SetPinkyLocation(Coordinate coordinate);
}
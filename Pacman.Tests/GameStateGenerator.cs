namespace Pacman.Tests;

public class GameStateGenerator
{
    private Dictionary<Coordinate, Cell> _map = new Dictionary<Coordinate, Cell>();
    private GameState _gameState;
    public GameState InitiateGameState(int height, int width, int TotalScore, Coordinate pacmanLocation, Directions directions )
    {
        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                _map.Add(new Coordinate(i, j), new Food());
            }    
        }
        _map[pacmanLocation] = new ThePacman(directions);
        _gameState = new GameState(height, width, _map, new List<Coordinate>() { }, TotalScore)
        {
            PacmanLocation = pacmanLocation
        };
        return _gameState;
    }
    public void SetCellToEmptyCell(Coordinate coordinate)
    {
        _map[coordinate] = new EmptyCell();
    }

    public void SetBlinkyLocation(Coordinate coordinate)
    {
        _gameState.BlinkyLocation = coordinate;
        _map[coordinate] = new Blinky(new AggressiveBehaviour());
    }

    public void SetPinkyLocation(Coordinate coordinate)
    {
        _gameState.PinkyLocation = coordinate;
        _map[coordinate] = new Pinky(new AggressiveBehaviour());
    }

    public void ResetMap() => _map = new Dictionary<Coordinate, Cell>();
    public GameState GetGameState() => _gameState;

    public void SetCellToFood(Coordinate coordinate) => _map[coordinate] = new Food();
    public void SetCellToHorizontalWall(Coordinate coordinate) => _map[coordinate] = new WallHorizontal();
    public void SetCellToVerticalWall(Coordinate coordinate) => _map[coordinate] = new WallVertical();
    public void SetCellToWallUpRight(Coordinate coordinate) => _map[coordinate] = new WallUpRight();
    public void SetCellToWallUpLeft(Coordinate coordinate) => _map[coordinate] = new WallUpLeft();
    public void SetCellToWallDownLeft(Coordinate coordinate) => _map[coordinate] = new WallDownLeft();
    public void SetCellToWallDownRight(Coordinate coordinate) => _map[coordinate] = new WallDownRight();
    public void SetCellToWallUpMiddle(Coordinate coordinate) => _map[coordinate] = new WallUpMiddle();
    public void SetCellToWallLeftMiddle(Coordinate coordinate) => _map[coordinate] = new WallLeftMiddle();
    public void SetCellToWallRightMiddle(Coordinate coordinate) => _map[coordinate] = new WallRightMiddle();
    public void SetCellToWallDownThickMiddle(Coordinate coordinate) => _map[coordinate] = new WallDownMiddleThick();
    public void SetCellToWallCross(Coordinate coordinate) => _map[coordinate] = new WallCross();
    public void SetCellToWallGhostGate(Coordinate coordinate) => _map[coordinate] = new GhostGate();
    
}
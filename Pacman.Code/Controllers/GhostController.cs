namespace Pacman.Code;

public class GhostController
{
    public Cell BlinkyTrail { get; set; } = new EmptyCell();
    public Cell PinkyTrail { get; set; } = new EmptyCell();
    private Blinky _blinky;
    private Pinky _pinky;

    public GhostController(Blinky blinky, Pinky pinky)
    {
        _blinky = blinky;
        _pinky = pinky;
    }

    public Coordinate MoveBlinky(GameState gameState)
    {
        _blinky.CreateMoveList(gameState);
        _blinky.RemoveLast();
        var nextMove = _blinky.Move();
        BlinkyTrail = gameState.Map[nextMove];
        return nextMove;
    }
    
    public Coordinate MovePinky(GameState gameState)
    {
        _pinky.CreateMoveList(gameState);
        _pinky.RemoveLast();
        var nextMove = _pinky.Move();
        PinkyTrail = gameState.Map[nextMove];
        return nextMove;
    }

}
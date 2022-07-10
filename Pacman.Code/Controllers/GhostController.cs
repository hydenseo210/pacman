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

    public void MoveBlinky(GameState gameState)
    {
        _blinky.CreateMoveList(gameState);
        _blinky.RemoveLast();
        var departure = gameState.BlinkyLocation;
        var destination = _blinky.Move();
        
        
        if(gameState.Map[destination] is ThePacman)
        {
            gameState.IsCollisionWithGhost = true;
            BlinkyTrail = new EmptyCell();
            PinkyTrail = new EmptyCell();
            return;
        }

        var previousTrail = BlinkyTrail;
        BlinkyTrail = gameState.Map[destination];
        gameState.Map[destination] = gameState.Map[departure];
        gameState.Map[departure] = previousTrail;
        gameState.BlinkyLocation = destination;
    }
    
    public void MovePinky(GameState gameState)
    {
        _pinky.CreateMoveList(gameState);
        _pinky.RemoveLast();
        var departure = gameState.PinkyLocation;
        var destination = _pinky.Move();

        if(gameState.Map[destination] is ThePacman)
        {
            gameState.IsCollisionWithGhost = true;
            BlinkyTrail = new EmptyCell();
            PinkyTrail = new EmptyCell();
            return;
        }
        var previousTrail = PinkyTrail;
        PinkyTrail = gameState.Map[destination];
        gameState.Map[destination] = gameState.Map[departure];
        gameState.Map[departure] = previousTrail;
        gameState.PinkyLocation = destination;
    }

    public void Reset(GameState gameState)
    {
        _blinky.CreateMoveList(gameState);
        _pinky.CreateMoveList(gameState);
    }

    public void ChangeGhostsToFrightened()
    {
        _blinky.ChangeBehaviour(new FrightenedBehaviour());
        _pinky.ChangeBehaviour(new FrightenedBehaviour());
    }
}
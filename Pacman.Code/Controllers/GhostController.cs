namespace Pacman.Code;

public class GhostController : IGhostController
{
    public Cell BlinkyTrail { get; set; } = new EmptyCell();
    public Cell PinkyTrail { get; set; } = new EmptyCell();
    private IGhost _blinky;
    private IGhost _pinky;

    public GhostController(IGhost blinky, IGhost pinky)
    {
        _blinky = blinky;
        _pinky = pinky;
    }

    public void MoveBlinky(IMap map)
    {
        _blinky.CreateMoveList(map);
        _blinky.RemoveLast();
        var departure = map.BlinkyCoordinate;
        var destination = _blinky.Move();
        
        
        if(map.Grid[destination] is ThePacman)
        {
            map.IsCollisionWithGhost = true;
            BlinkyTrail = new EmptyCell();
            PinkyTrail = new EmptyCell();
            return;
        }

        var previousTrail = BlinkyTrail;
        BlinkyTrail = map.Grid[destination];
        map.Grid[destination] = map.Grid[departure];
        map.Grid[departure] = previousTrail;
        map.BlinkyCoordinate = destination;
    }
    
    public void MovePinky(IMap map)
    {
        _pinky.CreateMoveList(map);
        _pinky.RemoveLast();
        var departure = map.PinkyCoordinate;
        var destination = _pinky.Move();

        if(map.Grid[destination] is ThePacman)
        {
            map.IsCollisionWithGhost = true;
            BlinkyTrail = new EmptyCell();
            PinkyTrail = new EmptyCell();
            return;
        }
        var previousTrail = PinkyTrail;
        PinkyTrail = map.Grid[destination];
        map.Grid[destination] = map.Grid[departure];
        map.Grid[departure] = previousTrail;
        map.PinkyCoordinate = destination;
    }

    public void Reset(IMap map)
    {
        _blinky.CreateMoveList(map);
        _pinky.CreateMoveList(map);
    }

    public void ChangeGhostsToFrightened()
    {
        _blinky.ChangeBehaviour(new FrightenedBehaviour());
        _pinky.ChangeBehaviour(new FrightenedBehaviour());
    }
}
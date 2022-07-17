namespace Pacman.Code;

public interface IGhostController
{
    public Cell BlinkyTrail { get; set; }
    public Cell PinkyTrail { get; set; }
    public void MoveBlinky(IMap map);
    public void MovePinky(IMap map);
    public void Reset(IMap map);
    public void ChangeGhostsToFrightened();
    
}
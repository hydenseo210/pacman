namespace Pacman.Code
{
    public abstract class State: IPrintable
    {
        public abstract Directions Direction { get;}
        public abstract Coordinate MoveForward(Coordinate location);
        public abstract string Print();
    }
}
namespace Pacman.Code
{
    public abstract class State: IPrintable
    {
        public abstract Directions Direction { get;}
        public abstract bool Eating { get; set; }
        public abstract Coordinate MoveForward(Coordinate location);
        public abstract string Print();
    }
}
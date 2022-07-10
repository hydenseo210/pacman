namespace Pacman.Code
{
    public class FacingRight : State
    {
        public override Directions Direction { get; } = Directions.Right;
        public override bool Eating { get; set; } = false;

        public override Coordinate MoveForward(Coordinate location) => 
            new (location.X, location.Y + 1);

        public override string Print() => !Eating ? "<" : "-";
    }
}
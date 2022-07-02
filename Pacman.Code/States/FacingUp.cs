namespace Pacman.Code
{
    public class FacingUp : State
    {
        public override Directions Direction { get; } = Directions.Up;

        public override Coordinate MoveForward(Coordinate location) =>
            new(location.X - 1, location.Y);

        public override string Print() => "⋁";
    }
}
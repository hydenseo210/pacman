namespace Pacman.Code
{
    public class FacingDown : State
    {
        public override Directions Direction { get; } = Directions.Down;

        public override Coordinate MoveForward(Coordinate location) =>
            new(location.X + 1, location.Y);

        public override string Print() => "⋀";
    }
}
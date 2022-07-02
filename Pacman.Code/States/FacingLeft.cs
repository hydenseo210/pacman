namespace Pacman.Code
{
    public class FacingLeft : State
    {
        public override Directions Direction { get; } = Directions.Left;

        public override Coordinate MoveForward(Coordinate location) =>
            new(location.X, location.Y - 1);

        public override string Print() => ">";
    }
}
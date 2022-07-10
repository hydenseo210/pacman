using System.Drawing;
using Pastel;

namespace Pacman.Code
{
    public class ThePacman : Cell, IMovable
    {
        public State State = new FacingRight();

        public ThePacman(Directions currentDirection = Directions.Right)
        {
            ChangeDirection(currentDirection);
        }

        public Coordinate MoveForward(Coordinate location) =>
            State.MoveForward(location);

        public void ChangeDirection(Directions direction)
        {
            State = direction switch
            {
                Directions.Left => new FacingLeft(),
                Directions.Right => new FacingRight(),
                Directions.Up => new FacingUp(),
                Directions.Down => new FacingDown(),
                _ => State
            };
        }

        public override bool IsValidPath() => true;

        public override string Print() => State.Print().Pastel(Color.FromArgb(255, 255, 0));
    }
}
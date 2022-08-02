namespace Pacman.Code
{
    public interface IMovable
    {
        Coordinate MoveForward(Coordinate location);
        void ChangeDirection(Directions direction);
    }
}


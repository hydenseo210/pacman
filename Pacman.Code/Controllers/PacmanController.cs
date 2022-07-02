namespace Pacman.Code
{
    public class PacmanController
    {
        public Coordinate Move(
            IDictionary<Coordinate, Cell> map,
            Directions direction,
            Coordinate departure)
        {
            
            if (map[departure] is not ThePacman pacman)
                throw new InvalidOperationException("No Pacman found");
            
            var currentDirection = pacman.State.Direction;
            
            if (pacman.State.Direction == direction)
            {
                var destination = pacman.MoveForward(departure);
                return destination;
            }
            pacman.ChangeDirection(direction);
            var tempCoordinate = pacman.MoveForward(departure);
            if(map[tempCoordinate] is Wall) pacman.ChangeDirection(currentDirection);
            
            return departure;
        }

        public Coordinate LocatePacman(IDictionary<Coordinate, Cell> map) =>
            map.Single(c => c.Value is ThePacman).Key;
    }
}
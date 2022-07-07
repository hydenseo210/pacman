namespace Pacman.Code
{
    public class PacmanController
    {
        public void Move(
            GameState gameState,
            Directions direction)
        {
            var departure = gameState.PacmanLocation;
            if (gameState.Map[departure] is not ThePacman pacman)
                throw new InvalidOperationException("No Pacman found");
            
            var currentDirection = pacman.State.Direction;
            
            if (currentDirection == direction)
            {
                var destination = pacman.MoveForward(departure);
                if (gameState.Map[destination] is Wall) return;
                UpdateLocation(gameState, destination, departure);
                return;
            }
            
            pacman.ChangeDirection(direction);
            var tempCoordinate = pacman.MoveForward(departure);
            if(gameState.Map[tempCoordinate] is Wall)
            { 
                pacman.ChangeDirection(currentDirection);
                return;
            }
            UpdateLocation(gameState, tempCoordinate, departure);
        }

        private void UpdateLocation(GameState gameState, Coordinate destination, Coordinate departure)
        {
            gameState.Map[destination] = gameState.Map[departure];
            gameState.Map[departure] = new EmptyCell();
            gameState.PacmanLocation = destination;
        }
    }
}
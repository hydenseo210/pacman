using System.Reflection.PortableExecutable;

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
                var destination = Abs(pacman.MoveForward(departure),gameState);
                if (gameState.Map[destination] is Wall) return;
                if (gameState.Map[destination] is SpecialFood) gameState.GodMode = true;
                if (gameState.Map[destination] is Food) gameState.CurrentScore ++;
                if(gameState.Map[destination] is IGhost)
                { 
                    pacman.ChangeDirection(currentDirection);
                    gameState.IsCollisionWithGhost = true;
                    return;
                }
                UpdateLocation(gameState, destination, departure);
                return;
            }
            
            pacman.ChangeDirection(direction);
            var tempCoordinate = Abs(pacman.MoveForward(departure),gameState);
            if(gameState.Map[tempCoordinate] is IGhost)
            { 
                pacman.ChangeDirection(currentDirection);
                gameState.IsCollisionWithGhost = true;
                return;
            }
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
        
        private static Coordinate Abs(Coordinate potentialCoordinate, GameState gameState)
        {
            if (potentialCoordinate.X > gameState.Height - 1) potentialCoordinate.X = 0;
            if (potentialCoordinate.X < 0) potentialCoordinate.X =gameState.Height - 1;
            if (potentialCoordinate.Y > gameState.Width - 1) potentialCoordinate.Y = 0;
            if (potentialCoordinate.Y < 0) potentialCoordinate.Y =gameState.Width - 1;
            return potentialCoordinate;
        }
    }
}
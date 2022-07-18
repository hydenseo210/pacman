using System.Reflection.PortableExecutable;

namespace Pacman.Code
{
    public class PacmanController
    {
        public void Move(
            IGameStatus gameStatus,
            IMap map,
            Directions direction)
        {
            var departure = map.PacmanCoordinate;
            if (map.Grid[departure] is not ThePacman pacman)
                throw new InvalidOperationException("No Pacman found");
            pacman.State.Eating = false;   
            var currentDirection = pacman.State.Direction;
            
            if (currentDirection == direction)
            {
                var destination = Abs(pacman.MoveForward(departure),map);
                if (map.Grid[destination] is Wall) return;
                if (map.Grid[destination] is SpecialFood) gameStatus.GodMode = true;
                if (map.Grid[destination] is EmptyCell) pacman.State.Eating = false;
                if (map.Grid[destination] is Food)
                {
                    gameStatus.CurrentScore++;
                    pacman.State.Eating = true;
                }
                if(map.Grid[destination] is IGhost)
                { 
                    pacman.ChangeDirection(currentDirection);
                     map.IsCollisionWithGhost = true;
                    return;
                }
                UpdateLocation(map, destination, departure);
                return;
            }
            
            pacman.ChangeDirection(direction);
            var tempCoordinate = Abs(pacman.MoveForward(departure),map);
            if(map.Grid[tempCoordinate] is IGhost)
            { 
                pacman.ChangeDirection(currentDirection);
                 map.IsCollisionWithGhost = true;
                return;
            }
            if(map.Grid[tempCoordinate] is Wall)
            { 
                pacman.ChangeDirection(currentDirection);
                return;
            }
            UpdateLocation(map, tempCoordinate, departure);
        }

        private void UpdateLocation(IMap map, Coordinate destination, Coordinate departure)
        {
            map.Grid[destination] = map.Grid[departure];
            map.Grid[departure] = new EmptyCell();
            map.PacmanCoordinate = destination;
        }
        
        private static Coordinate Abs(Coordinate potentialCoordinate, IMap map)
        {
            if (potentialCoordinate.X > map.Height - 1) potentialCoordinate.X = 0;
            if (potentialCoordinate.X < 0) potentialCoordinate.X =map.Height - 1;
            if (potentialCoordinate.Y > map.Width - 1) potentialCoordinate.Y = 0;
            if (potentialCoordinate.Y < 0) potentialCoordinate.Y =map.Width - 1;
            return potentialCoordinate;
        }
    }
}
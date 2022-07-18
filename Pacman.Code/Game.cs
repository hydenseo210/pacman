namespace Pacman.Code
{
    public class Game
    {
        private IMap _map;
        private readonly Queue<IMap> _nextMap;
        private readonly PacmanController _pacmanController;
        private readonly IGhostController _ghostController;
        private readonly IGameStatus _gameStatus;
        private readonly Coordinate _pacmanStartingLocation;

        public Game(IGameStatus gameStatus, IMap map, Queue<IMap> nextMap, 
            PacmanController pacmanController, IGhostController ghostController
            )
        {
            _gameStatus = gameStatus;
            _map = map;
            _nextMap = nextMap;
            _pacmanController = pacmanController;
            _ghostController = ghostController;
            _pacmanStartingLocation = _map.PacmanCoordinate;

        }
        public bool IsWon() => _gameStatus.CurrentScore == _map.TotalScore;
        public bool IsLastLevel() => _nextMap.Count == 0;
        public bool IsGameOver() => _gameStatus.LivesList.Count == 0;
        public void OpenGhostCage()
        {
            foreach (var ghostGate in _map.GhostGateCoordinates)
            {
                _map.Grid[ghostGate] = new EmptyCell();
            }
        }

        private void ApplyFoodSpecialEffects()
        {
            if (_gameStatus.GodMode)
            {
                foreach (var ghost in _map.GhostList)
                {
                    _ghostController.ChangeGhostBehaviour(ghost);
                }
                _gameStatus.GodMode = false;
            }

            if (_gameStatus.FreezeMode)
            {
                foreach (var ghost in _map.GhostList)
                {
                    _ghostController.SetGhostToFrozen(ghost);
                }
            }
        }
        private void MovePacman(Directions direction)
        {
            _pacmanController.Move(_gameStatus,_map, direction);
            if (_map.IsCollisionWithGhost)
            {
                _gameStatus.LivesList = _gameStatus.LivesList.GetRange(0, _gameStatus.LivesList.Count - 1);
                ResetPosition();
                _map.IsCollisionWithGhost = false;
            }
            
        }
        private void MoveGhost(IGhost ghost)
        {
            _ghostController.Move(_map, ghost);
            if (!_map.IsCollisionWithGhost) return;
            _gameStatus.LivesList = _gameStatus.LivesList.GetRange(0, _gameStatus.LivesList.Count - 1);
            ResetPosition();
            _map.IsCollisionWithGhost = false;
        }

        public void Tick(Directions direction)
        {
            ApplyFoodSpecialEffects();
            MovePacman(direction);
            foreach (var ghost in _map.GhostList)
            {
                MoveGhost(ghost);
            }
        }

        private void ResetPosition()
        {
            _map.Grid[_map.PacmanCoordinate] = new EmptyCell();
            _map.PacmanCoordinate = _pacmanStartingLocation;
            _map.Grid[_pacmanStartingLocation] = new ThePacman();

            foreach (var ghost in _map.GhostList)
            {
                _map.Grid[ghost.CurrentCoordinate] = ghost.Trail;
                ghost.Trail = new EmptyCell();
                ghost.CurrentCoordinate = ghost.StartingCoordinate;
                _map.Grid[ghost.StartingCoordinate] = (Cell)ghost;
                _ghostController.ChangeGhostBehaviour(ghost);
                _ghostController.Reset(_map, ghost);
            }
        }
        public void UpdateGameState() {
            _map = _nextMap.Dequeue();
        }
    }
}
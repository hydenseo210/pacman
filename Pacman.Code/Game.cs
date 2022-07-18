using System.Text;
using Figgle;

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
        private readonly Coordinate _blinkyStartingCoordinate;
        private readonly Coordinate _pinkyStartingCoordinate;

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
            _blinkyStartingCoordinate = _map.BlinkyCoordinate;
            _pinkyStartingCoordinate = _map.PinkyCoordinate;

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
        
        public void MovePacman(Directions direction)
        {
            _pacmanController.Move(_gameStatus,_map, direction);
            if (_map.IsCollisionWithGhost)
            {
                _gameStatus.LivesList = _gameStatus.LivesList.GetRange(0, _gameStatus.LivesList.Count - 1);
                ResetPosition();
                _map.IsCollisionWithGhost = false;
            }
            if (_gameStatus.GodMode)
            {
                _ghostController.ChangeGhostsToFrightened();
                _gameStatus.GodMode = false;
            }
            
        }
        public void MoveBlinky()
        {
            _ghostController.MoveBlinky(_map);
            if (_map.IsCollisionWithGhost)
            {
                _gameStatus.LivesList = _gameStatus.LivesList.GetRange(0, _gameStatus.LivesList.Count - 1);
                ResetPosition();
                _map.IsCollisionWithGhost = false;
            }
        }
        public void MovePinky()
        {
            _ghostController.MovePinky(_map);
            if (_map.IsCollisionWithGhost)
            {
                _gameStatus.LivesList = _gameStatus.LivesList.GetRange(0, _gameStatus.LivesList.Count - 1);
                ResetPosition();
                _map.IsCollisionWithGhost = false;
            }
        }

        private void ResetPosition()
        {
            _map.Grid[_map.PacmanCoordinate] = new EmptyCell();
            _map.PacmanCoordinate = _pacmanStartingLocation;
            _map.Grid[_pacmanStartingLocation] = new ThePacman();

            _map.Grid[_map.BlinkyCoordinate] = _ghostController.BlinkyTrail;
            _map.BlinkyCoordinate = _blinkyStartingCoordinate;
            _map.Grid[_blinkyStartingCoordinate] = new Blinky(new AggressiveBehaviour());

            _map.Grid[_map.PinkyCoordinate] = _ghostController.PinkyTrail;
            _map.PinkyCoordinate = _pinkyStartingCoordinate;
            _map.Grid[_pinkyStartingCoordinate] = new Pinky(new AggressiveBehaviour());

            _ghostController.Reset(_map);
            
        }
        public void UpdateGameState() {
            _map = _nextMap.Dequeue();
        }
    }
}
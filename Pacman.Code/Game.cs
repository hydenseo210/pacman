using System.Text;
using Figgle;

namespace Pacman.Code
{
    public class Game
    {
        private IMap _map;
        private readonly Queue<IMap> _nextMap;
        private readonly PacmanController _pacmanController;
        private readonly GhostController _ghostController;
        private readonly IGameStatus _gameStatus;
        private readonly Printer _printer;
        private readonly Coordinate _pacmanStartingLocation;
        private readonly Coordinate _blinkyStartingCoordinate;
        private readonly Coordinate _pinkyStartingCoordinate;

        public Game(IGameStatus _gameStatus, IMap map, Queue<IMap> nextMap, 
            PacmanController pacmanController, GhostController ghostController, Printer printer
            )
        {
            this._gameStatus = _gameStatus;
            _printer = printer;
            _map = map;
            _nextMap = nextMap;
            _pacmanController = pacmanController;
            _ghostController = ghostController;
            _pacmanStartingLocation = _map.PacmanCoordinate;
            _blinkyStartingCoordinate = _map.BlinkyCoordinate;
            _pinkyStartingCoordinate = _map.PinkyCoordinate;

        }
        public bool IsWon() => _map.CurrentScore == _map.TotalScore;
        public IMap GetMap() => _map;
        public bool IsLastLevel() => _nextMap.Count == 0;
        public bool IsGameOver() => _map.LivesList.Count == 0;
        private void OpenGhostCage()
        {
            foreach (var ghostGate in _map.GhostGateCoordinates)
            {
                _map.Grid[ghostGate] = new EmptyCell();
            }
        }
        
        public void MovePacman(Directions direction)
        {
            _pacmanController.Move(_map, direction);
            _printer.PrintGameConsole();
            if (_map.IsCollisionWithGhost)
            {
                _map.LivesList = _map.LivesList.GetRange(0, _map.LivesList.Count - 1);
                ResetPosition();
                _map.IsCollisionWithGhost = false;
            }
            if (_map.GodMode)
            {
                _ghostController.ChangeGhostsToFrightened();
                _map.GodMode = false;
            }
            
        }
        public void MoveBlinky()
        {
            _ghostController.MoveBlinky(_map);
            _printer.PrintGameConsole();
            if (_map.IsCollisionWithGhost)
            {
                _map.LivesList = _map.LivesList.GetRange(0, _map.LivesList.Count - 1);
                ResetPosition();
                _map.IsCollisionWithGhost = false;
            }
        }
        public void MovePinky()
        {
            _ghostController.MovePinky(_map);
            _printer.PrintGameConsole();
            if (_map.IsCollisionWithGhost)
            {
                _map.LivesList = _map.LivesList.GetRange(0, _map.LivesList.Count - 1);
                ResetPosition();
                _map.IsCollisionWithGhost = false;
            }
        }

        private void ResetPosition() // write life lost message - sleep 2000
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

        private void UpdateGameState() {
            _map = _nextMap.Dequeue();
        }

        public void NextLevel()
        {
            _printer.LevelOneCompleteMessage();
            UpdateGameState();
            _printer.PrintGameConsole();
        }
        

    }
    
    
}
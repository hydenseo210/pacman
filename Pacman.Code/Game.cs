using Figgle;

namespace Pacman.Code
{
    public class Game
    {
        private  GameState _gameState;
        private readonly Queue<GameState> _nextState;
        private  IDictionary<Coordinate,Cell> _map;
        private readonly PacmanController _pacmanController;
        private readonly GhostController _ghostController;
        private readonly GameStatus _status = new();
        private readonly IConsoleWrapper _console;
        private readonly int _ghostCount;
        private readonly Coordinate _pacmanStartingLocation;
        private readonly Coordinate _BlinkyStartingLocation;
        private readonly Coordinate _PinkyStartingLocation;

        public Game(GameState gameState, Queue<GameState> nextStates, PacmanController pacmanController, GhostController ghostController, IConsoleWrapper console)
        {
            _console = console;
            _gameState = gameState;
            _nextState = nextStates;
            _map = gameState.Map;
            _pacmanController = pacmanController;
            _ghostController = ghostController;
            _pacmanStartingLocation = gameState.PacmanLocation;
            _BlinkyStartingLocation = gameState.BlinkyLocation;
            _PinkyStartingLocation = gameState.PinkyLocation;

        }
        
        private bool CheckCollision(Coordinate ghostNextMove, Coordinate pacmanLocation) =>
            ghostNextMove == pacmanLocation;

        private void OpenGhostCage()
        {
            foreach (var ghostGate in _gameState.GhostGateLocation)
            {
                _gameState.Map[ghostGate] = new EmptyCell();
            }
        }

        public void StartMessage()
        {
            foreach (var message in Messages.StartMessage)
            {
                Print();
                _console.Write(message);
                Thread.Sleep(2000);
            }

            OpenGhostCage();
            Print();
        }

        private void DashBoard() => _console.Write(Messages.DashBoardMessage(_status.Scores, _gameState.TotalScore));
        public void MovePacman(Directions direction)
        {
            if (_status.isWon)
            {
                LevelOneCompleteMessage();
                UpdateGameState();
                _status.isWon = false;
                return;
            }
            if (CheckCollision(_gameState.PacmanLocation, _gameState.BlinkyLocation)
                || CheckCollision(_gameState.PacmanLocation, _gameState.PinkyLocation))
            {
                ResetPosition();
            }
            var departurePacman = _gameState.PacmanLocation;
            var destinationPacman = _pacmanController.Move(_map, direction, departurePacman);
            
            Print();
            if (UpdateGameStatus(destinationPacman))
            {
                return;
            }

            _map[destinationPacman] = _map[departurePacman];
            _map[departurePacman] = new EmptyCell();
            _gameState.PacmanLocation = destinationPacman;
            
            Print();
        }
        public void MoveBlinky()
        {
            var departureBlinky = _gameState.BlinkyLocation;
            var destinationBlinky = _ghostController.MoveBlinky(_gameState);
            _map[destinationBlinky] = _map[departureBlinky];
            _map[departureBlinky] = _ghostController.BlinkyTrail;
            _gameState.BlinkyLocation = destinationBlinky;

        }
        public void MovePinky()
        {
            var departurePinky = _gameState.PinkyLocation;
            var destinationPinky = _ghostController.MovePinky(_gameState);
            _map[destinationPinky] = _map[departurePinky];
            _map[departurePinky] = _ghostController.PinkyTrail;
            _gameState.PinkyLocation = destinationPinky;

        }

        private void ResetPosition()
        {
            _gameState.Map[_gameState.PacmanLocation] = new EmptyCell();
            _gameState.PacmanLocation = _pacmanStartingLocation;
            _gameState.Map[_pacmanStartingLocation] = new ThePacman();

            _gameState.Map[_BlinkyStartingLocation] = _ghostController.BlinkyTrail;
            _gameState.BlinkyLocation = _BlinkyStartingLocation;
            _gameState.Map[_BlinkyStartingLocation] = new Blinky(new ChaseAggressive());
            _ghostController.BlinkyTrail = new EmptyCell();
            
            _gameState.Map[_PinkyStartingLocation] = _ghostController.PinkyTrail;
            _gameState.PinkyLocation = _PinkyStartingLocation;
            _gameState.Map[_BlinkyStartingLocation] = new Pinky(new ChaseAggressive());
            _ghostController.PinkyTrail = new EmptyCell();
            
            _console.Write(Messages.LifeLostMessage);
            Thread.Sleep(2000);
        }

        private void UpdateGameState() {
            _gameState = _nextState.Dequeue();
            _map = _gameState.Map;
        }
        private bool UpdateGameStatus(Coordinate destination)
        {
            switch (_map[destination])
            {
                case Wall:
                    return true;
                case Food:
                    _status.Scores += Food.Score;
                    if (IsWon())
                    {
                        _status.isWon = true;
                        return true;
                    }

                    break;
                case ThePacman:
                    return true;
            }

            return false;
        }

        private bool IsWon() => _status.Scores == _gameState.TotalScore && !_status.isLost;

        private void LevelOneCompleteMessage()
        {
            _console.Write(Messages.LevelOneMessage);
            Thread.Sleep(2000);
        }
        private void Print()
         {
             for (var x = 0; x < _gameState.Height; x++)
             {
                 var row = "";
                 for (var y = 0; y < _gameState.Width; y++)
                 {
                     var coordinate = new Coordinate(x, y);
                     var cell = _map[coordinate].Print();
                     row += cell;
                 }
                 _console.Write(row);
                 _console.Write("\n");
             }
             _console.Write("\n");
             DashBoard();
             _console.Write("\n");
         }
    }
    
    
}
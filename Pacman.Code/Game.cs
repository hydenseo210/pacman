using System.Text;
using Figgle;

namespace Pacman.Code
{
    public class Game
    {
        private  GameState _gameState;
        private readonly Queue<GameState> _nextState;
        private  Dictionary<Coordinate,Cell> _map;
        private readonly PacmanController _pacmanController;
        private readonly GhostController _ghostController;
        private readonly GameStatus _status = new();
        private readonly IConsoleWrapper _console;
        private readonly Coordinate _pacmanStartingLocation;
        private readonly Coordinate _blinkyStartingLocation;
        private readonly Coordinate _pinkyStartingLocation;

        public Game(GameState gameState, Queue<GameState> nextStates, PacmanController pacmanController, GhostController ghostController, IConsoleWrapper console)
        {
            _console = console;
            _gameState = gameState;
            _nextState = nextStates;
            _map = gameState.Map;
            _pacmanController = pacmanController;
            _ghostController = ghostController;
            _pacmanStartingLocation = gameState.PacmanLocation;
            _blinkyStartingLocation = gameState.BlinkyLocation;
            _pinkyStartingLocation = gameState.PinkyLocation;

        }

        public bool IsLastLevel() => _nextState.Count == 0;
        public bool IsGameOver() => _gameState.LivesList.Count == 0;
        public void GameOverMessage() => _console.Write(Messages.GameOverMessage);
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
            
            Print();
        }

        private void DashBoard() => _console.Write(Messages.DashBoardMessage(_gameState.CurrentScore, _gameState.TotalScore, _gameState.LivesList));
        private void PacmanMessage() => _console.Write(Messages.Pacman);
        public void MovePacman(Directions direction)
        {
            _pacmanController.Move(_gameState, direction);
            Print();
            if (_gameState.IsCollisionWithGhost)
            {
                _gameState.LivesList = _gameState.LivesList.GetRange(0, _gameState.LivesList.Count - 1);
                ResetPosition();
                _gameState.IsCollisionWithGhost = false;
            }
            if (_gameState.GodMode)
            {
                _ghostController.ChangeGhostsToFrightened();
                _gameState.GodMode = false;
            }
            
        }

        public void MoveBlinky()
        {
            _ghostController.MoveBlinky(_gameState);
            Print();
            if (_gameState.IsCollisionWithGhost)
            {
                _gameState.LivesList = _gameState.LivesList.GetRange(0, _gameState.LivesList.Count - 1);
                ResetPosition();
                _gameState.IsCollisionWithGhost = false;
            }
        }

        public void MovePinky()
        {
            _ghostController.MovePinky(_gameState);
            Print();
            if (_gameState.IsCollisionWithGhost)
            {
                _gameState.LivesList = _gameState.LivesList.GetRange(0, _gameState.LivesList.Count - 1);
                ResetPosition();
                _gameState.IsCollisionWithGhost = false;
            }
        }

        private void ResetPosition()
        {
            _gameState.Map[_gameState.PacmanLocation] = new EmptyCell();
            _gameState.PacmanLocation = _pacmanStartingLocation;
            _gameState.Map[_pacmanStartingLocation] = new ThePacman();

            _gameState.Map[_gameState.BlinkyLocation] = _ghostController.BlinkyTrail;
            _gameState.BlinkyLocation = _blinkyStartingLocation;
            _gameState.Map[_blinkyStartingLocation] = new Blinky(new AggressiveBehaviour());

            _gameState.Map[_gameState.PinkyLocation] = _ghostController.PinkyTrail;
            _gameState.PinkyLocation = _pinkyStartingLocation;
            _gameState.Map[_pinkyStartingLocation] = new Pinky(new AggressiveBehaviour());

            _ghostController.Reset(_gameState);

            _console.Write(Messages.LifeLostMessage);
            Thread.Sleep(2000);
        }

        private void UpdateGameState() {
            _gameState = _nextState.Dequeue();
            _map = _gameState.Map;
        }

        public void NextLevel()
        {
            LevelOneCompleteMessage();
            UpdateGameState();
            Print();
        }

        public bool IsWon() => _gameState.CurrentScore == _gameState.TotalScore;

        private void LevelOneCompleteMessage()
        {
            _console.Write(Messages.LevelOneMessage);
            Thread.Sleep(2000);
        }
        private void Print()
        {
            PacmanMessage();
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
             DashBoard();
             _console.Write("\n");
         }

        public void WonMessage()
        {
            _console.Write(Messages.WonMessage);
        }
    }
    
    
}
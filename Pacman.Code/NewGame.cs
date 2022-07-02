using Figgle;

namespace Pacman.Code
{
    public class NewGame
    {
        private  GameState _gameState;
        private readonly Queue<GameState> _nextState;
        private  IDictionary<Coordinate,Cell> _map;
        private readonly PacmanController _pacmanController;
        private readonly GhostController _ghostController;
        private readonly GameStatus _status = new();
        private List<Coordinate> ghostMoveList;

        public NewGame(GameState gameState, Queue<GameState> nextStates, PacmanController pacmanController, GhostController ghostController)
        {
            _gameState = gameState;
            _nextState = nextStates;
            _map = gameState.Map;
            _pacmanController = pacmanController;
            _ghostController = ghostController;
            GetGhostMoveList();
        }

        private void GetGhostMoveList() => ghostMoveList = _ghostController.Move(_gameState);
        
        public void OpenGhostCage()
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
                Console.WriteLine(message);
                Thread.Sleep(2000);
            }

            OpenGhostCage();
            Print();
        }
        public void DashBoard()
        {
            Console.WriteLine("LEVEL 1");
            Console.WriteLine("Total Lives Left: 💙💙💙💙💙");
            Console.WriteLine($"Score: {_status.Scores} out of {_gameState.TotalScore}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press Q to Quit");
            Console.WriteLine("Press S to Save");
            Console.WriteLine("Press P to Pause");
        }
        public void MovePacman(Directions direction)
        {
            if (ghostMoveList.Count == 0)
            {
                GetGhostMoveList();
            }
            if (_status.isWon)
            {
                LevelOneCompleteMessage();
                UpdateGameState();
                _status.isWon = false;
                return;
            }
            
            var departurePacman = _gameState.PacmanLocation;
            var destinationPacman = _pacmanController.Move(_map, direction, departurePacman);
            
            var departureGhost = _gameState.GhostLocation;
            var destinationGhost = ghostMoveList.Last();
            var ghostTrail = _ghostController.GhostTrail(_gameState, destinationGhost);

            Print();
            if (UpdateGameStatus(destinationPacman))
            {
                return;
            }

            _map[destinationPacman] = _map[departurePacman];
            _map[departurePacman] = new EmptyCell();
            _gameState.PacmanLocation = destinationPacman;
            
            
            _map[destinationGhost] = _map[departureGhost];
            _map[departureGhost] = ghostTrail;
            ghostMoveList.RemoveAt(ghostMoveList.Count -1);
            _gameState.GhostLocation = destinationGhost;
            
            Print();
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
            Console.WriteLine(
                FiggleFonts.Standard.Render("Level One Complete!")
            );
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
                 Console.WriteLine(row);
             }

             DashBoard();
         }
    }
    
    
}
namespace Pacman.Code
{
    public static class GameController
    {
        public static void Run(Game game, IConsoleWrapper console, IThreadSleeper threadSleeper, IPrinter printer)
        {
            printer.StartMessage();
            game.OpenGhostCage();
            var key = new ConsoleKeyInfo().Key;
            var direction = Directions.Right;
            do
            {
                if (IsGameFinished(game, printer)) break;
                if (console.KeyAvailable)
                {
                    try
                    {
                        key = console.ReadKey().Key;
                        direction = GetDirectionByKey(key);
                    }
                    catch (Exception e)
                    {
                        console.Write(e.Message);
                        continue;
                    }
                }
                
                printer.PrintGameConsole();
                game.Tick(direction);
                printer.PrintGameConsole();
                threadSleeper.Sleep(200);
                Console.Clear();
            } while (key != ConsoleKey.Q);
        }
        
        private static bool IsGameFinished(Game game, IPrinter printer)
        {
            if (game.IsWon() && game.IsLastLevel())
            {
                printer.WonMessage();
                return true;
            }
            if (game.IsGameOver())
            {
                printer.GameOverMessage();
                return true;
            }
            if (game.IsWon())
            {
                
                printer.LevelOneCompleteMessage();
                var nextMap = game.UpdateGameState();
                printer.UpdateGame(nextMap, new GameStatus());
                printer.PrintGameConsole();
                printer.StartMessage();
                game.OpenGhostCage();
                return false;
            }

            return false;
        }
        

        private static Directions GetDirectionByKey(ConsoleKey key) =>
            key switch
            {
                ConsoleKey.UpArrow => Directions.Up,
                ConsoleKey.DownArrow => Directions.Down,
                ConsoleKey.LeftArrow => Directions.Left,
                ConsoleKey.RightArrow => Directions.Right,
                _ => throw new ArgumentOutOfRangeException("Invalid Input")
            };
    }
}
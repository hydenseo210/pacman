namespace Pacman.Code
{
    public static class GameController
    {
        public static void Run(Game game, IConsoleWrapper console)
        {
            game.StartMessage();
            var key = new ConsoleKeyInfo().Key;
            var direction = Directions.Right;
            do
            {
                if (console.KeyAvailable)
                {
                    key = console.ReadKey().Key;
                    direction = GetDirectionByKey(key);
                    game.MovePacman(direction);
                    game.MoveBlinky();
                    game.MovePinky();
                }
                else
                {
                    game.MovePacman(direction);
                    game.MoveBlinky();
                    game.MovePinky();
                }
                Thread.Sleep(200);
            } while (key != ConsoleKey.Q);
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
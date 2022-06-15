namespace Pacman.Code;

public class Game
{
    public readonly string[][] Grid;
    private readonly IConsoleWrapper _console;
    private readonly Coordinate _pacmanLocation;
    public Game(string[][] grid, IConsoleWrapper consoleWrapper, Coordinate pacmanLocation)
    {
        _console = consoleWrapper;
        _pacmanLocation = pacmanLocation;
        Grid = grid;
    }


    public void Run()
    {
        UpdateDirection();
    }

    private void UpdateDirection()
    {
        ConsoleKey key;
        while ((key = _console.ReadKey().Key) != ConsoleKey.Escape)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    MovePacman(Grid, new Move("x", -1));
                    break; 
                case ConsoleKey.RightArrow:
                    MovePacmanRight(Grid, _pacmanLocation.X + 1);
                    break;
                case ConsoleKey.UpArrow:
                    MovePacmanUp(Grid, _pacmanLocation.Y - 1);
                    break;
                case ConsoleKey.DownArrow:
                    MovePacmanDown(Grid, _pacmanLocation.Y + 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(); // make it the last arrow pressed
            }
            //continuously moving pacman
        }
    }

    private void MovePacmanRight(string[][] currentGrid, int index)
    {
        var listOfEmoji = new List<string> { "⩹", "<", "⦣", "<"};
        currentGrid[_pacmanLocation.Y][index - 1] = " ";
        foreach (var emoji in listOfEmoji)
        {
            
            currentGrid[_pacmanLocation.Y][index] = emoji;
            Print();
            Thread.Sleep(200); // dependency inject the sleep value to make it flexible and adjust speed
            Console.Clear();
        } // pass in as function

        _pacmanLocation.X++;
    }
    
    private void MovePacman(string[][] currentGrid, Move move)
    {
        if (move.Component == "x")
        {
            currentGrid[_pacmanLocation.Y][_pacmanLocation.X] = " ";
            currentGrid[_pacmanLocation.Y][_pacmanLocation.X + move.Amount] = ">";
        }
        // var listOfEmoji = new List<string> { "⩺", ">", "⦢", ">"};
        //
        // foreach (var emoji in listOfEmoji)
        // {
        //     Console.Clear();
        //     currentGrid[_pacmanStartingLocation.Y][index] = emoji;
        //     Print();
        //     Thread.Sleep(200);
        // }
        _pacmanLocation.X--;
    }
    
    private void MovePacmanDown(string[][] currentGrid, int index)
    {
        var listOfEmoji = new List<string> { "⟑", "⋀", "⩘", "⋀"};
        currentGrid[index - 1][_pacmanLocation.X] = " ";
        foreach (var emoji in listOfEmoji)
        {
            Console.Clear();
            currentGrid[index][_pacmanLocation.X] = emoji;
            Print();
            Thread.Sleep(200);
        }
        _pacmanLocation.Y++;
    }
    
    private void MovePacmanUp(string[][] currentGrid, int index)
    {
        var listOfEmoji = new List<string> { "⩒", "⋁", "⩗", "⋁"};
        currentGrid[index + 1][_pacmanLocation.X] = " ";
        foreach (var emoji in listOfEmoji)
        {
            Console.Clear();
            currentGrid[index][_pacmanLocation.X] = emoji;
            Print();
            Thread.Sleep(200);
        }
        _pacmanLocation.Y--;
    }
    
    private void Print()
    {
        foreach(var i in Grid)
            Console.WriteLine(string.Join("", i));
    }
}

using Pacman.Code;

var console = new ConsoleWrapper();
var startingGrid = new[]
{
     new[] {"<", "∘", "∘", "∘", "∘"},
     new[] {"∘", "∘", "∘", "∘", "∘"},
     new[] {"∘", "∘", "∘", "∘", "∘"},
     new[] {"∘", "∘", "∘", "∘", "∘"},
     new[] {"∘", "∘", "∘", "∘", "∘"}
};
var game = new Game(startingGrid, console, new Coordinate(0, 0));

game.Run();
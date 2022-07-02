namespace Pacman.Code;

public class AStarSearchAlgorithm
{
    private static int Width { get; set; }
    private static int Height { get; set; }

    public List<Coordinate> Execute(GameState gameState)
    {
        Width = gameState.Width;
        Height = gameState.Height;
        var start = new Tile
        {
            Y = gameState.GhostLocation.Y,
            X = gameState.GhostLocation.X
        };

        var finish = new Tile
        {
            Y = gameState.PacmanLocation.Y,
            X = gameState.PacmanLocation.X
        };
        var shortestPath = new List<Coordinate>() { };
        start.SetDistance(finish.X, finish.Y);
        var activeTiles = new List<Tile>();
        activeTiles.Add(start);

        var visitedTiles = new List<Tile>();

        while (activeTiles.Any())
        {
            var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();
            if (checkTile.X == finish.X && checkTile.Y == finish.Y)
            {
                var tile = checkTile;
                while (tile.Parent != null)
                {
                    shortestPath.Add(new Coordinate(tile.X, tile.Y));
                    tile = tile.Parent;
                    if (tile == null)
                    {
                        return shortestPath;
                    }
                }
            }

            visitedTiles.Add(checkTile);
            activeTiles.Remove(checkTile);
            var walkableTiles = GetWalkableTiles(gameState.Map, checkTile, finish);
            foreach (var walkableTile in walkableTiles)
            {
                //if we have already visited this tile then we don't need to do so again
                if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y)) continue;
                //if it's already in the active list, but if its cheaper replace it 
                if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                {
                    var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                    if (existingTile.CostDistance > checkTile.CostDistance)
                    {
                        activeTiles.Remove(existingTile);
                        activeTiles.Add(walkableTile);
                    }

                }
                else
                {
                    activeTiles.Add(walkableTile);
                }
            }
        }
        return shortestPath;
    }
    
    private static List<Tile> GetWalkableTiles(IDictionary<Coordinate, Cell> map, Tile currentTile, Tile targetTile)
    {
        var possibleTiles = new List<Tile>()
        {
            new Tile 
            { 
                X = Abs(currentTile.X, Height), 
                Y = Abs(currentTile.Y - 1, Width),
                Parent = currentTile, 
                Cost = currentTile.Cost + 1 
            },
            new Tile
            {
                X = Abs(currentTile.X, Height),
                Y = Abs(currentTile.Y + 1, Width),
                Parent = currentTile, 
                Cost = currentTile.Cost + 1
            },
            new Tile
            {
                X = Abs(currentTile.X - 1, Height), 
                Y = Abs(currentTile.Y, Width),
                Parent = currentTile, 
                Cost = currentTile.Cost + 1
            },
            new Tile
            {
                X = Abs(currentTile.X + 1, Height), 
                Y = Abs(currentTile.Y, Width),
                Parent = currentTile, 
                Cost = currentTile.Cost + 1
            },
        };
        possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));
        var filterTiles = possibleTiles
            .Where(tile => map[new Coordinate(tile.X, tile.Y)].IsValidPath())
            .ToList();
        return filterTiles;
    }
    
    private static int Abs(int potentialCoordinate, int boundary)
    {
        if (potentialCoordinate > boundary - 1)
        {
            return 0;
        }
        if (potentialCoordinate < 0)
        {
            return boundary - 1;
        }
        
        return potentialCoordinate;
    }
}
public class Tile
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Cost { get; set; }
    public int Distance { get; set; }
    public int CostDistance => Cost + Distance;
    
    public Tile? Parent { get; set; }
    
    public void SetDistance(int targetX, int targetY)
    {
        this.Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
    }
}
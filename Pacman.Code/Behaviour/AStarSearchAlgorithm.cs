namespace Pacman.Code;

public class AStarSearchAlgorithm
{
    private static int Width { get; set; }
    private static int Height { get; set; }

    public List<Coordinate> Execute(IMap map, Coordinate ghostLocation, IChaseBehaviour behaviour)
    {
        Width = map.Width;
        Height = map.Height;
        
        var start = new Tile
        {
            Y = ghostLocation.Y,
            X = ghostLocation.X
        };

        var finish = new Tile
        {
            Y = map.PacmanCoordinate.Y,
            X = map.PacmanCoordinate.X
        };
        var shortestPath = new List<Coordinate>();
        start.SetDistance(finish.X, finish.Y);
        var activeTiles = new List<Tile> { start };
        var visitedTiles = new List<Tile>();

        while (activeTiles.Any())
        {
            Tile checkTile = null;
            if (behaviour is AggressiveBehaviour) checkTile = activeTiles.OrderBy(x => x.CostDistance).First();
            if (behaviour is FrightenedBehaviour) checkTile = activeTiles.OrderBy(x => x.CostDistance).Last();
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
            var walkableTiles = GetWalkableTiles(map.Grid, checkTile, finish);
            foreach (var walkableTile in walkableTiles)
            {
                if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y)) continue;
                if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                {
                    var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                    if (behaviour is AggressiveBehaviour)
                    {
                        if (existingTile.CostDistance > checkTile.CostDistance) // this part
                        {
                            activeTiles.Remove(existingTile);
                            activeTiles.Add(walkableTile);
                        }
                    }

                    if (behaviour is FrightenedBehaviour)
                    {
                        if (existingTile.CostDistance < checkTile.CostDistance) // this part
                        {
                            activeTiles.Remove(existingTile);
                            activeTiles.Add(walkableTile);
                        }
                    }
                }
                else
                {
                    activeTiles.Add(walkableTile);
                }
            }
        }
        shortestPath.Add(ghostLocation);
        return shortestPath;
    }
    
    private static List<Tile> GetWalkableTiles(IDictionary<Coordinate, Cell> grid, Tile currentTile, Tile targetTile)
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
            .Where(tile => grid[new Coordinate(tile.X, tile.Y)].IsValidPath())
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
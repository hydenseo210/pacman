namespace Pacman.Code;

public static class GameDownload
{
    public static Map DownloadMapFromFile(string filePath)
    {
        var defaultCoordinate = new Coordinate(0, 0);
        var fileData = File.ReadAllLines(filePath);
        
        if (fileData.Length == 0) throw new InvalidDataException("File is Empty.");
        
        var map = new Map(fileData.Length, fileData.First().Length, 0,
            new Dictionary<Coordinate, Cell>(), new List<Coordinate>(),
            defaultCoordinate, new List<IGhost>());
        // {
        //     Height = fileData.Length,
        //     Width = fileData.First().Length
        //
        // };

        for (var x = 0; x < map.Height; x++)
        {
            for (var y = 0; y < map.Width; y++)
            {
                
                var coordinate = new Coordinate(x, y);
                var currentString = fileData[x][y].ToString();
                switch (currentString)
                {
                    case var value when value == Constants.PacmanRight:
                        map.AddToMap(coordinate, new ThePacman());
                        map.PacmanCoordinate = coordinate;
                        break;
                    case var value when value == Constants.Blinky:
                        var Blinky = new Blinky(new AggressiveBehaviour());
                        map.AddToMap(coordinate, Blinky);
                        Blinky.CurrentCoordinate = coordinate;
                        Blinky.StartingCoordinate = coordinate;
                        map.GhostList.Add(Blinky);
                        break;
                    case var value when value == Constants.Pinky:
                        var Pinky = new Pinky(new AggressiveBehaviour());
                        map.AddToMap(coordinate, Pinky);
                        Pinky.CurrentCoordinate = coordinate;
                        Pinky.StartingCoordinate = coordinate;
                        map.GhostList.Add(Pinky);
                        break;
                    case var value when value == Constants.Clyde:
                        var Clyde = new Clyde(new FrightenedBehaviour());
                        map.AddToMap(coordinate, Clyde);
                        Clyde.CurrentCoordinate = coordinate;
                        Clyde.StartingCoordinate = coordinate;
                        map.GhostList.Add(Clyde);
                        break;
                    case var value when value == Constants.Inky:
                        var Inky = new Inky(new FrightenedBehaviour());
                        map.AddToMap(coordinate, Inky);
                        Inky.CurrentCoordinate = coordinate;
                        Inky.StartingCoordinate = coordinate;
                        map.GhostList.Add(Inky);
                        break;
                    case Constants.EmptyString:
                        map.AddToMap(coordinate, new EmptyCell());
                        break;
                    case Constants.Food:
                        map.AddToMap(coordinate, new Food());
                        map.TotalScore++;
                        break;
                    case Constants.SpecialFood:
                        map.AddToMap(coordinate, new SpecialFood());
                        break;
                    case Constants.PoisonFood:
                        map.AddToMap(coordinate, new FreezeFood());
                        break;
                    case Constants.WallUpLeft:
                        map.AddToMap(coordinate, new WallUpLeft());
                        break;
                    case Constants.WallUpRight:
                        map.AddToMap(coordinate, new WallUpRight());
                        break;
                    case Constants.WallDownLeft:
                        map.AddToMap(coordinate, new WallDownLeft());
                        break;
                    case Constants.WallDownRight:
                        map.AddToMap(coordinate, new WallDownRight());
                        break;
                    case Constants.WallHorizontal:
                        map.AddToMap(coordinate, new WallHorizontal());
                        break;
                    case Constants.WallRightMiddle:
                        map.AddToMap(coordinate, new WallRightMiddle());
                        break;
                    case Constants.WallLeftMiddle:
                        map.AddToMap(coordinate, new WallLeftMiddle());
                        break;
                    case Constants.WallUpMiddle:
                        map.AddToMap(coordinate, new WallUpMiddle());
                        break;
                    case Constants.WallDownMiddle:
                        map.AddToMap(coordinate, new WallDownMiddle());
                        break;
                    case Constants.WallDownMiddleThick:
                        map.AddToMap(coordinate, new WallDownMiddleThick());
                        break;
                    case Constants.WallVertical:
                        map.AddToMap(coordinate, new WallVertical());
                        break;
                    case Constants.WallSmallMiddle:
                        map.AddToMap(coordinate, new WallSmallMiddle());
                        break;
                    case Constants.WallCross:
                        map.AddToMap(coordinate, new WallCross());
                        break;
                    case Constants.GhostGate:
                        map.AddToGhostGate(coordinate);
                        map.AddToMap(coordinate, new GhostGate());
                        break;
                    case Constants.Padding:
                        map.AddToMap(coordinate, new Padding());
                        break;
                    
                }
            }
        }

        return map;
    }
}
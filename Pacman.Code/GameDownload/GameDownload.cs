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
            defaultCoordinate, defaultCoordinate, defaultCoordinate);
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
                    case var value when value == Emojis.PacmanRight:
                        map.AddToMap(coordinate, new ThePacman());
                        map.PacmanCoordinate = coordinate;
                        break;
                    case var value when value == Emojis.Blinky:
                        map.AddToMap(coordinate, new Blinky(new AggressiveBehaviour()));
                        map.BlinkyCoordinate = coordinate;
                        break;
                    case var value when value == Emojis.Pinky:
                        map.AddToMap(coordinate, new Pinky(new AggressiveBehaviour()));
                        map.PinkyCoordinate = coordinate;
                        break;
                    case Emojis.EmptyString:
                        map.AddToMap(coordinate, new EmptyCell());
                        break;
                    case Emojis.Food:
                        map.AddToMap(coordinate, new Food());
                        map.TotalScore++;
                        break;
                    case Emojis.SpecialFood:
                        map.AddToMap(coordinate, new SpecialFood());
                        break;
                    case Emojis.WallUpLeft:
                        map.AddToMap(coordinate, new WallUpLeft());
                        break;
                    case Emojis.WallUpRight:
                        map.AddToMap(coordinate, new WallUpRight());
                        break;
                    case Emojis.WallDownLeft:
                        map.AddToMap(coordinate, new WallDownLeft());
                        break;
                    case Emojis.WallDownRight:
                        map.AddToMap(coordinate, new WallDownRight());
                        break;
                    case Emojis.WallHorizontal:
                        map.AddToMap(coordinate, new WallHorizontal());
                        break;
                    case Emojis.WallRightMiddle:
                        map.AddToMap(coordinate, new WallRightMiddle());
                        break;
                    case Emojis.WallLeftMiddle:
                        map.AddToMap(coordinate, new WallLeftMiddle());
                        break;
                    case Emojis.WallUpMiddle:
                        map.AddToMap(coordinate, new WallUpMiddle());
                        break;
                    case Emojis.WallDownMiddle:
                        map.AddToMap(coordinate, new WallDownMiddle());
                        break;
                    case Emojis.WallDownMiddleThick:
                        map.AddToMap(coordinate, new WallDownMiddleThick());
                        break;
                    case Emojis.WallVertical:
                        map.AddToMap(coordinate, new WallVertical());
                        break;
                    case Emojis.WallSmallMiddle:
                        map.AddToMap(coordinate, new WallSmallMiddle());
                        break;
                    case Emojis.WallCross:
                        map.AddToMap(coordinate, new WallCross());
                        break;
                    case Emojis.GhostGate:
                        map.AddToGhostGate(coordinate);
                        map.AddToMap(coordinate, new GhostGate());
                        break;
                    case Emojis.Padding:
                        map.AddToMap(coordinate, new Padding());
                        break;
                    
                }
            }
        }

        return map;
    }
}
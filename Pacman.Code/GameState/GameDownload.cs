namespace Pacman.Code;

public class GameDownload
{
    public GameState DownloadGameStateFromFile(string filePath)
    {
        var fileData = File.ReadAllLines(filePath);
        if (fileData.Length == 0) throw new InvalidDataException("File is Empty.");
        var height = fileData.Length;
        var width = fileData.First().Length;
        var pacmanLocation = new Coordinate(0, 0);
        var blinkyLocation = new Coordinate(0, 0);
        var pinkyLocation = new Coordinate(0, 0);
        var totalScore = 0;
        var ghostGateLocation = new List<Coordinate>() { };
        Dictionary<Coordinate, Cell> mapData = new Dictionary<Coordinate, Cell>() { };
        
        for (var x = 0; x < height; x++)
        {
            for (var y = 0; y < width; y++)
            {
                
                var coordinate = new Coordinate(x, y);
                var currentString = fileData[x][y].ToString();
                switch (currentString)
                {
                    case var value when value == Emojis.PacmanRight:
                        mapData.Add(coordinate, new ThePacman());
                        pacmanLocation = coordinate;
                        break;
                    case var value when value == Emojis.Blinky:
                        mapData.Add(coordinate, new Blinky(new AggressiveBehaviour()));
                        blinkyLocation = coordinate;
                        break;
                    case var value when value == Emojis.Pinky:
                        mapData.Add(coordinate, new Pinky(new AggressiveBehaviour()));
                        pinkyLocation = coordinate;
                        break;
                    case Emojis.EmptyString:
                        mapData.Add(coordinate, new EmptyCell());
                        break;
                    case Emojis.Food:
                        mapData.Add(coordinate, new Food());
                        totalScore++;
                        break;
                    case Emojis.SpecialFood:
                        mapData.Add(coordinate, new SpecialFood());
                        break;
                    case Emojis.WallUpLeft:
                        mapData.Add(coordinate, new WallUpLeft());
                        break;
                    case Emojis.WallUpRight:
                        mapData.Add(coordinate, new WallUpRight());
                        break;
                    case Emojis.WallDownLeft:
                        mapData.Add(coordinate, new WallDownLeft());
                        break;
                    case Emojis.WallDownRight:
                        mapData.Add(coordinate, new WallDownRight());
                        break;
                    case Emojis.WallHorizontal:
                        mapData.Add(coordinate, new WallHorizontal());
                        break;
                    case Emojis.WallRightMiddle:
                        mapData.Add(coordinate, new WallRightMiddle());
                        break;
                    case Emojis.WallLeftMiddle:
                        mapData.Add(coordinate, new WallLeftMiddle());
                        break;
                    case Emojis.WallUpMiddle:
                        mapData.Add(coordinate, new WallUpMiddle());
                        break;
                    case Emojis.WallDownMiddle:
                        mapData.Add(coordinate, new WallDownMiddle());
                        break;
                    case Emojis.WallDownMiddleThick:
                        mapData.Add(coordinate, new WallDownMiddleThick());
                        break;
                    case Emojis.WallVertical:
                        mapData.Add(coordinate, new WallVertical());
                        break;
                    case Emojis.WallSmallMiddle:
                        mapData.Add(coordinate, new WallSmallMiddle());
                        break;
                    case Emojis.WallCross:
                        mapData.Add(coordinate, new WallCross());
                        break;
                    case Emojis.GhostGate:
                        ghostGateLocation.Add(coordinate);
                        mapData.Add(coordinate, new GhostGate());
                        break;
                    case Emojis.Padding:
                        mapData.Add(coordinate, new Padding());
                        break;
                    
                }
            }
        }
        
        return new GameState(height, width, mapData , ghostGateLocation, totalScore) 
            { PacmanLocation = pacmanLocation, 
                BlinkyLocation = blinkyLocation,
                PinkyLocation = pinkyLocation
            };
    }
}
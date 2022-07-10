using Figgle;
namespace Pacman.Code;

public class Messages
{
    public static readonly string Pacman = FiggleFonts.Standard.Render("Pacman");
    public static readonly string Ready = FiggleFonts.Standard.Render("Ready");
    public static readonly string Set = FiggleFonts.Standard.Render("Set");
    public static readonly string Go = FiggleFonts.Standard.Render("Go");
    public static readonly string LevelOneMessage = FiggleFonts.Standard.Render("Level One Complete!");
    public static readonly Func<int, int, List<string>, string> DashBoardMessage = (score, totalScore, livesList) 
        => @$"LEVEL 1
Total Lives Left: {string.Join( "", livesList)}
Score: {score} out of {totalScore}";
    public static readonly List<string> StartMessage = new List<string>(){ Ready, Set, Go };
    public static string LifeLostMessage = FiggleFonts.Standard.Render("Life Lost");
    public static readonly string GameOverMessage = FiggleFonts.Standard.Render("GAME OVER!");
    public static readonly string WonMessage = FiggleFonts.Standard.Render("YOU WIN!");
}
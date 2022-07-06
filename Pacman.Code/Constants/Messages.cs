using Figgle;
namespace Pacman.Code;

public class Messages
{
    public static readonly string Ready = FiggleFonts.Standard.Render("Ready");
    public static readonly string Set = FiggleFonts.Standard.Render("Set");
    public static readonly string Go = FiggleFonts.Standard.Render("Go");
    public static readonly string LevelOneMessage = FiggleFonts.Standard.Render("Level One Complete!");
    public static readonly Func<int,int,string> DashBoardMessage = (score, totalScore) => 
        @$"LEVEL 1
        Total Lives Left: 💙💙💙💙💙
        Score: {score} out of {totalScore}



        Press Q to Quit
        Press S to Save 
        Press P to Pause";
    public static readonly List<string> StartMessage = new List<string>(){ Ready, Set, Go };
    public static string LifeLostMessage = FiggleFonts.Standard.Render("Life Lost");
}
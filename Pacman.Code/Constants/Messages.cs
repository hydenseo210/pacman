using Figgle;
namespace Pacman.Code;

public class Messages
{
    public static readonly string Ready = FiggleFonts.Standard.Render("Ready");
    public static readonly string Set = FiggleFonts.Standard.Render("Set");
    public static readonly string Go = FiggleFonts.Standard.Render("Go");
    public static readonly List<string> StartMessage = new List<string>(){ Ready, Set, Go };
}
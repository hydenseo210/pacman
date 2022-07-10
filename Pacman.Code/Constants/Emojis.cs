using System.Drawing;
using Pastel;

namespace Pacman.Code;

public class Emojis
{
    
    public const string EmptyString = " ";
    public const string Life = "💙";
    public static readonly string PacmanRight = "<";
    public const string PacmanLeft = ">";
    public const string PacmanUp = "⋁";
    public const string PacmanDown = "⋀";
    public const string Food = "∘";
    public const string SpecialFood = "+";
    public static readonly string Pinky = "þ";
    public static readonly string Blinky = "ß";
    public static readonly List<string> EatingRightMotion = new List<string> { "⩹", "<", "⦣", "<"};
    public static readonly List<string> EatingLeftMotion = new List<string> { "⩺", ">", "⦢", ">"};
    public static readonly List<string> EatingUpMotion = new List<string> { "⩒", "⋁", "⩗", "⋁"};
    public static readonly List<string> EatingDownMotion = new List<string> { "⟑", "⋀", "⩘", "⋀"};

    public const string WallUpLeft = "╔";
    public const string WallUpRight = "╗";
    public const string WallDownLeft = "╚";
    public const string WallDownRight = "╝";
    public const string WallHorizontal = "═";
    public const string WallUpMiddle = "╦";
    public const string WallRightMiddle = "╠";
    public const string WallLeftMiddle = "╣";
    public const string WallDownMiddle = "╨";
    public const string WallDownMiddleThick = "╩";
    public const string WallVertical = "║";
    public const string WallCross = "╬";
    public const string WallSmallMiddle = "╥";
    public const string GhostGate = "-";
    public const string Padding = "█";

    public static readonly List<string> WallList = new List<string>
    {
        WallCross, WallRightMiddle, WallVertical, WallHorizontal, WallDownLeft, WallDownLeft, WallDownMiddle,
        WallSmallMiddle, WallDownRight, WallUpLeft, WallUpMiddle, WallUpRight, Padding, GhostGate
    };
}
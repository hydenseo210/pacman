using Figgle;
namespace Pacman.Code;

public static class Exceptions
{
    public const string EmptyFile = "File is Empty.";
    public const string PacmanCount = "File can't contain more than one pacman";
    public const string GhostCount = "File can't contain more than one type of the same ghost";
    public const string ZeroPacmanCount = "No pacman present in file";
    public const string AtLeastOneGhost = "No pacman present in file";
}
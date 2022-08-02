namespace Pacman.Code
{
    public class EmptyCell: Cell
    {
        public override bool IsValidPath() => true;
        public override string Print() => Constants.EmptyString;
    }
}
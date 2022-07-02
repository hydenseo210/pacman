namespace Pacman.Code
{
    public abstract class Cell: IPrintable
    {
        public abstract bool IsValidPath();
        public abstract string Print();
    }
}


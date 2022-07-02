namespace Pacman.Code
{
    public class SpecialFood: Cell
    {
        public const int Score = 1;
        public override bool IsValidPath() => true;
        public override string Print() => Emojis.SpecialFood;
    }
}
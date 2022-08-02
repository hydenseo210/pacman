using System.Drawing;
using Pastel;

namespace Pacman.Code
{
    public class SpecialFood: Cell
    {
        public override bool IsValidPath() => true;
        public override string Print() => Constants.SpecialFood.Pastel(Color.FromArgb(0, 255, 0));
    }
}
using System.Drawing;
using Pastel;

namespace Pacman.Code
{
    public class Food: Cell
    {
        public override bool IsValidPath() => true;
        public override string Print() => Emojis.Food;
        //.Pastel(Color.FromArgb(255, 229, 204))
    }
}
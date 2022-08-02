using System.Drawing;
using Pastel;

namespace Pacman.Code
{
    public class FreezeFood: Cell
    {
        public override bool IsValidPath() => true;
        public override string Print() => Constants.PoisonFood.Pastel(Color.FromArgb(120, 255, 200));
    }
}
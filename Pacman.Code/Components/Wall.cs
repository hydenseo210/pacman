using System.Drawing;
using Pastel;

namespace Pacman.Code
{
    public abstract class Wall: Cell
    {
    }
    public class WallUpRight: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallUpRight;
    }
    
    public class WallUpLeft: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallUpLeft;
    }
    
    public class WallDownLeft: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallDownLeft;
    }
    
    public class WallDownRight: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallDownRight;
    }
    
    public class WallHorizontal: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallHorizontal;
    }
    public class WallUpMiddle: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallUpMiddle;
    }
    //Pastel(Color.FromArgb(0, 102, 204))
    public class WallRightMiddle: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallRightMiddle;
    }
    public class WallLeftMiddle: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallLeftMiddle;
    }
    
    public class WallDownMiddleThick: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallDownMiddleThick;
    }
    
    public class WallDownMiddle: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallDownMiddle;
    }
    
    public class WallVertical: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallVertical;
    }
    
    public class WallSmallMiddle: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallSmallMiddle;
    }
    public class WallCross: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.WallCross;
    }
    
    public class GhostGate: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.GhostGate;
    }
    
    public class Padding: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Emojis.EmptyString;
    }
}
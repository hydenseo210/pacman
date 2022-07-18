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
        public override string Print() => Constants.WallUpRight;
    }
    
    public class WallUpLeft: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.WallUpLeft;
    }
    
    public class WallDownLeft: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.WallDownLeft;
    }
    
    public class WallDownRight: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.WallDownRight;
    }
    
    public class WallHorizontal: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.WallHorizontal;
    }
    public class WallUpMiddle: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.WallUpMiddle;
    }
    //Pastel(Color.FromArgb(0, 102, 204))
    public class WallRightMiddle: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.WallRightMiddle;
    }
    public class WallLeftMiddle: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.WallLeftMiddle;
    }
    
    public class WallDownMiddleThick: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.WallDownMiddleThick;
    }
    
    public class WallDownMiddle: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.WallDownMiddle;
    }
    
    public class WallVertical: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.WallVertical;
    }
    
    public class WallSmallMiddle: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.WallSmallMiddle;
    }
    public class WallCross: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.WallCross;
    }
    
    public class GhostGate: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.GhostGate;
    }
    
    public class Padding: Wall
    {
        public override bool IsValidPath() => false;
        public override string Print() => Constants.EmptyString;
    }
}
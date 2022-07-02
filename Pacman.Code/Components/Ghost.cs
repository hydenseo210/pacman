namespace Pacman.Code

{
    public class Ghost: Cell
    {
        private readonly IChaseBehaviour _chaseBehaviour;

        public Ghost(IChaseBehaviour chaseBehaviour)
        {
            _chaseBehaviour = chaseBehaviour;
        }
        public override bool IsValidPath() => false;
        public override string Print() => "@";
        
        public Coordinate Move(Coordinate location, Coordinate pacmanLocation) =>
            _chaseBehaviour.Chase(location, pacmanLocation);
    }
}


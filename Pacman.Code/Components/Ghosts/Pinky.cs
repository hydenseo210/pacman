namespace Pacman.Code

{
    public class Pinky: Cell, IGhost
    {
        private IChaseBehaviour _chaseBehaviour;
        private List<Coordinate> _moveList;

        public Pinky(IChaseBehaviour chaseBehaviour)
        {
            _chaseBehaviour = chaseBehaviour;
        }
        public override bool IsValidPath() => false;
        public override string Print() => "@";
        
        public void CreateMoveList(GameState gameState) =>
            _moveList = _chaseBehaviour.Chase(gameState, gameState.PinkyLocation);

        public void ChangeBehaviour(IChaseBehaviour chaseBehaviour)
        {
            _chaseBehaviour = chaseBehaviour;
        }
        public void RemoveLast() => _moveList.RemoveAt(_moveList.Count - 1);
        public Coordinate Move()
        {
            var move= _moveList.Last();
            RemoveLast();
            return move;
        }
    }
}
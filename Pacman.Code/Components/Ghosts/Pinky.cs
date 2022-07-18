using System.Drawing;
using Pastel;

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
        public override string Print() => _chaseBehaviour is AggressiveBehaviour ? 
            Constants.Pinky.Pastel(Color.FromArgb(235, 95, 230)) : Constants.Pinky.Pastel(Color.FromArgb(148,0,211));
        public void CreateMoveList(IMap map) =>
            _moveList = _chaseBehaviour.Chase(map, map.PinkyCoordinate);

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
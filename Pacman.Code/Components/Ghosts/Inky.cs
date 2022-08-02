using System.Drawing;
using Pastel;

namespace Pacman.Code

{
    public class Inky: Cell, IGhost
    {
        private IChaseBehaviour _chaseBehaviour;
        private List<Coordinate> _moveList;
        public Cell Trail { get; set;  } = new EmptyCell();
        private bool Frozen { get; set; } = false;
        public Coordinate CurrentCoordinate { get; set; }
        public Coordinate StartingCoordinate { get; set; }
        public Inky(IChaseBehaviour chaseBehaviour)
        {
            _chaseBehaviour = chaseBehaviour;
        }
        public override bool IsValidPath() => false;
        public override string Print()
        {
            return Constants.Inky.Pastel(_chaseBehaviour is AggressiveBehaviour ? 
                Color.FromArgb(255, 0, 0) : Color.FromArgb(148, 0, 211));
        }
        public void CreateMoveList(IMap map) =>
            _moveList = _chaseBehaviour.Chase(map, CurrentCoordinate);

        public void ChangeBehaviour()
        {
            switch (_chaseBehaviour)
            {
                case AggressiveBehaviour:
                    _chaseBehaviour = new FrightenedBehaviour();
                    return;
                case FrightenedBehaviour:
                    _chaseBehaviour = new AggressiveBehaviour();
                    return;
            }
        }
        public void RemoveLast() => _moveList.RemoveAt(_moveList.Count - 1);
        public void SetToFrozen() => Frozen = !Frozen;

        public Coordinate Move()
        {
            if (Frozen) return CurrentCoordinate;
            if (_moveList.Count == 0) return CurrentCoordinate;
            var move= _moveList.Last();
            RemoveLast();
            return move;
        }
    }
}
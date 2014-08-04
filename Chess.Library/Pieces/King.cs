using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{
    
    public class King : Piece
    {

        public King(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public King(int y, int x, PieceColor color)
            : base(y, x, color) { }

        public override string ToString()
        {
            return base.ToString("King");
        }

        public override bool CanMove(int y, int x)
        {
            throw new NotImplementedException();
        }

        public override bool CanMove(BoardPoint to)
        {
            throw new NotImplementedException();
        }

        public override bool[][] GetAvailableMoves()
        {
            throw new NotImplementedException();
        }

    }

}

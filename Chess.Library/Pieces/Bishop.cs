using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{

    public class Bishop : Piece
    {

        public Bishop(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public Bishop(int x, int y, PieceColor color)
            : base(x, y, color) { }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{

    public class Rook : Piece
    {

        public Rook(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public Rook(int x, int y, PieceColor color)
            : base(x, y, color) { }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{
    
    public class Queen : Piece
    {

        public Queen(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public Queen(int y, int x, PieceColor color)
            : base(y, x, color) { }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{
   
    public class Knight : Piece
    {

        public Knight(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public Knight(int y, int x, PieceColor color)
            : base(y, x, color) { }

        public override string ToString()
        {
            return base.ToString("Knight");
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

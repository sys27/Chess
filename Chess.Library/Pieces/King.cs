using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{
    
    public class King : Piece
    {

        private bool check;

        public King(PieceColor color)
            : base(color) { }

        public King(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public King(int y, int x, PieceColor color)
            : base(y, x, color) { }

        public override string ToString()
        {
            return base.ToString("King");
        }

        public override bool[][] GetAvailableMoves(Board board)
        {
            throw new NotImplementedException();
        }

        public bool Check
        {
            get
            {
                return check;
            }
            set
            {
                check = value;
            }
        }

    }

}

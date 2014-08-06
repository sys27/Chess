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
        private bool isMoved;

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

        public override bool[][] GetAvailableMoves(Game game)
        {
            var result = new bool[8][];
            for (int i = 0; i < 8; i++)
                result[i] = new bool[8];

            // todo: Castling

            if (!check)
            {

            }
            else
            {

            }

            return result;
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

        public bool IsMoved
        {
            get
            {
                return isMoved;
            }
            set
            {
                isMoved = value;
            }
        }

    }

}

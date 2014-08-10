using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{

    public class King : Piece
    {

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

        public override MoveType CanMove(Game game, int y, int x)
        {
            // todo: reimplement
            return GetAvailableMoves(game)[y][x];
        }

        public override MoveType[][] GetAvailableMoves(Game game)
        {
            var result = new MoveType[8][];
            for (int i = 0; i < 8; i++)
                result[i] = new MoveType[8];

            // todo: Castling

            var y = coordinates.Y;
            var x = coordinates.X;

            if (!game.GetCheck(color))
            {
                if (y - 1 >= 0)
                {
                    if (x - 1 >= 0)
                    {
                        // up-left
                    }
                    if (x + 1 < 8)
                    {
                        // up-right
                    }

                    // up
                }

                if (x - 1 >= 0)
                {
                    // left
                }
                if (x + 1 < 8)
                {
                    // right
                }

                if (y + 1 < 8)
                {
                    if (x - 1 >= 0)
                    {
                        // down-left
                    }
                    if (x + 1 < 8)
                    {
                        // down-right
                    }

                    // down
                }
            }
            else
            {

            }

            return result;
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

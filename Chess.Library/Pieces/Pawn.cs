using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{

    public class Pawn : Piece
    {

        private bool isMoved;

        public Pawn(PieceColor color)
            : base(color) { }

        public Pawn(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public Pawn(int y, int x, PieceColor color)
            : base(y, x, color) { }

        public override string ToString()
        {
            return base.ToString("Pawn");
        }

        public override bool[][] GetAvailableMoves(Board board)
        {
            var result = new bool[8][];
            for (int i = 0; i < 8; i++)
                result[i] = new bool[8];

            // todo: En passant

            var y = coordinates.Y;
            var x = coordinates.X;

            if (color == PieceColor.White)
            {
                if (board.GetCheck(color))
                {

                }
                else
                {
                    if (!isMoved && y - 2 >= 0 && board[y - 2, x] == null)
                        result[y - 2][x] = true;

                    if (y - 1 >= 0 && board[y - 1, x] == null)
                        result[y - 1][x] = true;

                    if (y - 1 >= 0 && x - 1 >= 0)
                    {
                        var piece = board[y - 1, x - 1];
                        if (piece != null && piece.Color != color && !(piece is King))
                            result[y - 1][x - 1] = true;
                    }
                    if (y - 1 >= 0 && x + 1 >= 0)
                    {
                        var piece = board[y - 1, x + 1];
                        if (piece != null && piece.Color != color && !(piece is King))
                            result[y - 1][x + 1] = true;
                    }
                }
            }
            else
            {
                if (board.GetCheck(color))
                {

                }
                else
                {
                    if (!isMoved && y + 2 >= 0 && board[y + 2, x] == null)
                        result[y + 2][x] = true;

                    if (y + 1 >= 0 && board[y + 1, x] == null)
                        result[y + 1][x] = true;

                    if (y + 1 >= 0 && x - 1 >= 0)
                    {
                        var piece = board[y + 1, x - 1];
                        if (piece != null && piece.Color != color && !(piece is King))
                            result[y + 1][x - 1] = true;
                    }
                    if (y + 1 >= 0 && x + 1 >= 0)
                    {
                        var piece = board[y + 1, x + 1];
                        if (piece != null && piece.Color != color && !(piece is King))
                            result[y + 1][x + 1] = true;
                    }
                }
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

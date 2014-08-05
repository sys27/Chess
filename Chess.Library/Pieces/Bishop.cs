using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{

    public class Bishop : Piece
    {

        public Bishop(PieceColor color)
            : base(color) { }

        public Bishop(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public Bishop(int y, int x, PieceColor color)
            : base(y, x, color) { }

        public override string ToString()
        {
            return base.ToString("Bishop");
        }

        public override bool[][] GetAvailableMoves(Board board)
        {
            var result = new bool[8][];
            for (int i = 0; i < 8; i++)
                result[i] = new bool[8];

            if (board.GetCheck(color))
            {

            }
            else
            {
                // up-left
                for (int x = coordinates.X - 1, y = coordinates.Y - 1; x >= 0 && y >= 0; x--, y--)
                {
                    var piece = board[y, x];
                    if (piece != null)
                    {
                        if (piece.Color != color && !(piece is King))
                            result[y][x] = true;

                        break;
                    }

                    result[y][x] = true;
                }

                // up-right
                for (int x = coordinates.X + 1, y = coordinates.Y - 1; x < 8 && y >= 0; x++, y--)
                {
                    var piece = board[y, x];
                    if (piece != null)
                    {
                        if (piece.Color != color && !(piece is King))
                            result[y][x] = true;

                        break;
                    }

                    result[y][x] = true;
                }

                // down-left
                for (int x = coordinates.X - 1, y = coordinates.Y + 1; x >= 0 && y < 8; x--, y++)
                {
                    var piece = board[y, x];
                    if (piece != null)
                    {
                        if (piece.Color != color && !(piece is King))
                            result[y][x] = true;

                        break;
                    }

                    result[y][x] = true;
                }

                // down-right
                for (int x = coordinates.X + 1, y = coordinates.Y + 1; x < 8 && y < 8; x++, y++)
                {
                    var piece = board[y, x];
                    if (piece != null)
                    {
                        if (piece.Color != color && !(piece is King))
                            result[y][x] = true;

                        break;
                    }

                    result[y][x] = true;
                }
            }

            return result;
        }

    }

}

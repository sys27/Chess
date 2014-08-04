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

        public Rook(int y, int x, PieceColor color)
            : base(y, x, color) { }

        public override string ToString()
        {
            return base.ToString("Rook");
        }

        public override bool[][] GetAvailableMoves(Board board)
        {
            var result = new bool[8][];
            for (int i = 0; i < result.Length; i++)
                result[i] = new bool[8];

            // left
            for (int i = coordinates.X; i >= 0; i--)
            {
                var piece = board[coordinates.Y, i];
                if (piece != null)
                {
                    if (piece.Color != color && !(piece is King))
                        result[coordinates.Y][i] = true;

                    break;
                }

                result[coordinates.Y][i] = true;
            }

            // right
            for (int i = coordinates.X; i < 8; i++)
            {
                var piece = board[coordinates.Y, i];
                if (piece != null)
                {
                    if (piece.Color != color && !(piece is King))
                        result[coordinates.Y][i] = true;

                    break;
                }

                result[coordinates.Y][i] = true;
            }

            // up
            for (int i = coordinates.Y; i > 0; i--)
            {
                var piece = board[i, coordinates.X];
                if (piece != null)
                {
                    if (piece.Color != color && !(piece is King))
                        result[i][coordinates.X] = true;

                    break;
                }

                result[i][coordinates.X] = true;
            }

            // down
            for (int i = coordinates.Y; i < 8; i++)
            {
                var piece = board[i, coordinates.X];
                if (board[i, coordinates.X] != null)
                {
                    if (piece.Color != color && !(piece is King))
                        result[i][coordinates.X] = true;

                    break;
                }

                result[i][coordinates.X] = true;
            }

            return result;
        }

    }

}

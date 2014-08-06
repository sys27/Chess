using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{
    
    public class Queen : Piece
    {

        public Queen(PieceColor color)
            : base(color) { }

        public Queen(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public Queen(int y, int x, PieceColor color)
            : base(y, x, color) { }

        public override string ToString()
        {
            return base.ToString("Queen");
        }

        public override bool[][] GetAvailableMoves(Board board)
        {
            var result = new bool[8][];
            for (int i = 0; i < 8; i++)
                result[i] = new bool[8];

            if (!board.GetCheck(color))
            {
                // left
                for (int i = coordinates.X - 1; i >= 0; i--)
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
                for (int i = coordinates.X + 1; i < 8; i++)
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
                for (int i = coordinates.Y - 1; i > 0; i--)
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
                for (int i = coordinates.Y + 1; i < 8; i++)
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
            else
            {
                
            }

            return result;
        }

    }

}

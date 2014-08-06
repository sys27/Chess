using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{

    public class Knight : Piece
    {

        public Knight(PieceColor color)
            : base(color) { }

        public Knight(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public Knight(int y, int x, PieceColor color)
            : base(y, x, color) { }

        public override string ToString()
        {
            return base.ToString("Knight");
        }

        public override bool CanMove(Game game, int y, int x)
        {
            // todo: reimplement
            return GetAvailableMoves(game)[y][x];
        }

        public override bool[][] GetAvailableMoves(Game game)
        {
            var result = new bool[8][];
            for (int i = 0; i < 8; i++)
                result[i] = new bool[8];

            if (!game.GetCheck(color))
            {
                var y = coordinates.Y;
                var x = coordinates.X;

                if (y + 2 < 8)
                {
                    if (x + 1 < 8)
                    {
                        var piece = game.GameBoard[y + 2, x + 1];

                        if (piece == null || (piece != null && piece.Color != color && !(piece is King)))
                            result[y + 2][x + 1] = true;
                    }
                    if (x - 1 >= 0)
                    {
                        var piece = game.GameBoard[y + 2, x - 1];

                        if (piece == null || (piece != null && piece.Color != color && !(piece is King)))
                            result[y + 2][x - 1] = true;
                    }
                }

                if (y + 1 < 8)
                {
                    if (x + 2 < 8)
                    {
                        var piece = game.GameBoard[y + 1, x + 2];

                        if (piece == null || (piece != null && piece.Color != color && !(piece is King)))
                            result[y + 1][x + 2] = true;
                    }
                    if (x - 2 >= 0)
                    {
                        var piece = game.GameBoard[y + 1, x - 2];

                        if (piece == null || (piece != null && piece.Color != color && !(piece is King)))
                            result[y + 1][x - 2] = true;
                    }
                }

                if (y - 1 >= 0)
                {
                    if (x + 2 < 8)
                    {
                        var piece = game.GameBoard[y - 1, x + 2];

                        if (piece == null || (piece != null && piece.Color != color && !(piece is King)))
                            result[y - 1][x + 2] = true;
                    }
                    if (x - 2 >= 0)
                    {
                        var piece = game.GameBoard[y - 1, x - 2];

                        if (piece == null || (piece != null && piece.Color != color && !(piece is King)))
                            result[y - 1][x - 2] = true;
                    }
                }

                if (y - 2 >= 0)
                {
                    if (x + 1 < 8)
                    {
                        var piece = game.GameBoard[y - 2, x + 1];

                        if (piece == null || (piece != null && piece.Color != color && !(piece is King)))
                            result[y - 2][x + 1] = true;
                    }
                    if (x - 1 >= 0)
                    {
                        var piece = game.GameBoard[y - 2, x - 1];

                        if (piece == null || (piece != null && piece.Color != color && !(piece is King)))
                            result[y - 2][x - 1] = true;
                    }
                }
            }
            else
            {
                
            }

            return result;
        }

    }

}

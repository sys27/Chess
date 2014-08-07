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

            if (!game.GetCheck(color))
            {
                // up-left
                for (int x = coordinates.X - 1, y = coordinates.Y - 1; x >= 0 && y >= 0; x--, y--)
                {
                    var piece = game.GameBoard[y, x];
                    if (piece != null)
                    {
                        if (!(piece is King))
                        {
                            if(piece.Color != color)
                                result[y][x] = MoveType.Kill;
                            else
                                result[y][x] = MoveType.Protect;
                        }

                        break;
                    }

                    result[y][x] = MoveType.Move;
                }

                // up-right
                for (int x = coordinates.X + 1, y = coordinates.Y - 1; x < 8 && y >= 0; x++, y--)
                {
                    var piece = game.GameBoard[y, x];
                    if (piece != null)
                    {
                        if (!(piece is King))
                        {
                            if (piece.Color != color)
                                result[y][x] = MoveType.Kill;
                            else
                                result[y][x] = MoveType.Protect;
                        }

                        break;
                    }

                    result[y][x] = MoveType.Move;
                }

                // down-left
                for (int x = coordinates.X - 1, y = coordinates.Y + 1; x >= 0 && y < 8; x--, y++)
                {
                    var piece = game.GameBoard[y, x];
                    if (piece != null)
                    {
                        if (!(piece is King))
                        {
                            if (piece.Color != color)
                                result[y][x] = MoveType.Kill;
                            else
                                result[y][x] = MoveType.Protect;
                        }

                        break;
                    }

                    result[y][x] = MoveType.Move;
                }

                // down-right
                for (int x = coordinates.X + 1, y = coordinates.Y + 1; x < 8 && y < 8; x++, y++)
                {
                    var piece = game.GameBoard[y, x];
                    if (piece != null)
                    {
                        if (!(piece is King))
                        {
                            if (piece.Color != color)
                                result[y][x] = MoveType.Kill;
                            else
                                result[y][x] = MoveType.Protect;
                        }

                        break;
                    }

                    result[y][x] = MoveType.Move;
                }
            }
            else
            {

            }

            return result;
        }

    }

}

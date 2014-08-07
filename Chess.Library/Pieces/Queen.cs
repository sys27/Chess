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
                // left
                for (int i = coordinates.X - 1; i >= 0; i--)
                {
                    var piece = game.GameBoard[coordinates.Y, i];
                    if (piece != null)
                    {
                        if (piece.Color != color)
                        {
                            if (piece is King)
                                result[coordinates.Y][i] = MoveType.Check;
                            else
                                result[coordinates.Y][i] = MoveType.Kill;
                        }
                        else
                            result[coordinates.Y][i] = MoveType.Protect;

                        break;
                    }

                    result[coordinates.Y][i] = MoveType.Move;
                }

                // right
                for (int i = coordinates.X + 1; i < 8; i++)
                {
                    var piece = game.GameBoard[coordinates.Y, i];
                    if (piece != null)
                    {
                        if (piece.Color != color)
                        {
                            if (piece is King)
                                result[coordinates.Y][i] = MoveType.Check;
                            else
                                result[coordinates.Y][i] = MoveType.Kill;
                        }
                        else
                            result[coordinates.Y][i] = MoveType.Protect;

                        break;
                    }

                    result[coordinates.Y][i] = MoveType.Move;
                }

                // up
                for (int i = coordinates.Y - 1; i > 0; i--)
                {
                    var piece = game.GameBoard[i, coordinates.X];
                    if (piece != null)
                    {
                        if (piece.Color != color)
                        {
                            if (piece is King)
                                result[i][coordinates.X] = MoveType.Check;
                            else
                                result[i][coordinates.X] = MoveType.Kill;
                        }
                        else
                            result[i][coordinates.X] = MoveType.Protect;

                        break;
                    }

                    result[i][coordinates.X] = MoveType.Move;
                }

                // down
                for (int i = coordinates.Y + 1; i < 8; i++)
                {
                    var piece = game.GameBoard[i, coordinates.X];
                    if (piece != null)
                    {
                        if (piece.Color != color)
                        {
                            if (piece is King)
                                result[i][coordinates.X] = MoveType.Check;
                            else
                                result[i][coordinates.X] = MoveType.Kill;
                        }
                        else
                            result[i][coordinates.X] = MoveType.Protect;

                        break;
                    }

                    result[i][coordinates.X] = MoveType.Move;
                }

                // up-left
                for (int x = coordinates.X - 1, y = coordinates.Y - 1; x >= 0 && y >= 0; x--, y--)
                {
                    var piece = game.GameBoard[y, x];
                    if (piece != null)
                    {
                        if (piece.Color != color)
                        {
                            if (piece is King)
                                result[y][x] = MoveType.Check;
                            else
                                result[y][x] = MoveType.Kill;
                        }
                        else
                            result[y][x] = MoveType.Protect;

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
                        if (piece.Color != color)
                        {
                            if (piece is King)
                                result[y][x] = MoveType.Check;
                            else
                                result[y][x] = MoveType.Kill;
                        }
                        else
                            result[y][x] = MoveType.Protect;

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
                        if (piece.Color != color)
                        {
                            if (piece is King)
                                result[y][x] = MoveType.Check;
                            else
                                result[y][x] = MoveType.Kill;
                        }
                        else
                            result[y][x] = MoveType.Protect;

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
                        if (piece.Color != color)
                        {
                            if (piece is King)
                                result[y][x] = MoveType.Check;
                            else
                                result[y][x] = MoveType.Kill;
                        }
                        else
                            result[y][x] = MoveType.Protect;

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

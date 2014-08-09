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

            // todo: En passant

            var y = coordinates.Y;
            var x = coordinates.X;

            if (color == PieceColor.White)
            {
                if (!game.WhiteCheck)
                {
                    if (!isMoved && y - 2 >= 0 && game.GameBoard[y - 2, x] == null)
                        result[y - 2][x] = MoveType.Move;

                    if (y - 1 >= 0 && game.GameBoard[y - 1, x] == null)
                        result[y - 1][x] = MoveType.Move;

                    if (y - 1 >= 0 && x - 1 >= 0)
                    {
                        var piece = game.GameBoard[y - 1, x - 1];
                        if (piece != null)
                        {
                            if (piece.Color != color)
                            {
                                if (piece is King)
                                    result[y - 1][x - 1] = MoveType.Check;
                                else
                                    result[y - 1][x - 1] = MoveType.Kill;
                            }
                            else
                            {
                                result[y - 1][x - 1] = MoveType.Protect;
                            }
                        }
                    }
                    if (y - 1 >= 0 && x + 1 >= 0)
                    {
                        var piece = game.GameBoard[y - 1, x + 1];
                        if (piece != null)
                        {
                            if (piece.Color != color)
                            {
                                if (piece is King)
                                    result[y - 1][x + 1] = MoveType.Check;
                                else
                                    result[y - 1][x + 1] = MoveType.Kill;
                            }
                            else
                            {
                                result[y - 1][x + 1] = MoveType.Protect;
                            }
                        }
                    }
                }
                else
                {

                }
            }
            else
            {
                if (!game.BlackCheck)
                {
                    if (!isMoved && y + 2 >= 0 && game.GameBoard[y + 2, x] == null)
                        result[y + 2][x] = MoveType.Move;

                    if (y + 1 >= 0 && game.GameBoard[y + 1, x] == null)
                        result[y + 1][x] = MoveType.Move;

                    if (y + 1 >= 0 && x - 1 >= 0)
                    {
                        var piece = game.GameBoard[y + 1, x - 1];
                        if (piece != null)
                        {
                            if (piece.Color != color)
                            {
                                if (piece is King)
                                    result[y + 1][x - 1] = MoveType.Check;
                                else
                                    result[y + 1][x - 1] = MoveType.Kill;
                            }
                            else
                            {
                                result[y + 1][x - 1] = MoveType.Protect;
                            }
                        }
                    }
                    if (y + 1 >= 0 && x + 1 >= 0)
                    {
                        var piece = game.GameBoard[y + 1, x + 1];
                        if (piece != null)
                        {
                            if (piece.Color != color)
                            {
                                if (piece is King)
                                    result[y + 1][x + 1] = MoveType.Check;
                                else
                                    result[y + 1][x + 1] = MoveType.Kill;
                            }
                            else
                            {
                                result[y + 1][x + 1] = MoveType.Protect;
                            }
                        }
                    }
                }
                else
                {

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

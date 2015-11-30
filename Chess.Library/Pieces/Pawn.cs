using System;

namespace Chess.Library.Pieces
{

    public class Pawn : Piece
    {

        public Pawn(Players owner)
            : base(owner) { }

        public Pawn(BoardPoint coordinates, Players owner)
            : base(coordinates, owner) { }

        public Pawn(int y, int x, Players owner)
            : base(y, x, owner) { }

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

            if (owner == Players.PlayerOne)
            {
                if (!game.PlayerOneCheck)
                {
                    if (y - 1 >= 0 && game.GameBoard[y - 1, x] == null)
                    {
                        result[y - 1][x] = MoveType.Move;

                        if (!isMoved && y - 2 >= 0 && game.GameBoard[y - 2, x] == null)
                            result[y - 2][x] = MoveType.Move;
                    }

                    if (y - 1 >= 0 && x - 1 >= 0)
                    {
                        var piece = game.GameBoard[y - 1, x - 1];
                        if (piece != null)
                        {
                            if (piece.Owner != owner)
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
                        else
                        {
                            result[y - 1][x - 1] = MoveType.GhostKill;
                        }
                    }
                    if (y - 1 >= 0 && x + 1 >= 0)
                    {
                        var piece = game.GameBoard[y - 1, x + 1];
                        if (piece != null)
                        {
                            if (piece.Owner != owner)
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
                        else
                        {
                            result[y - 1][x + 1] = MoveType.GhostKill;
                        }
                    }
                }
                else
                {

                }
            }
            else
            {
                if (!game.PlayerTwoCheck)
                {
                    if (y + 1 >= 0 && game.GameBoard[y + 1, x] == null)
                    {
                        result[y + 1][x] = MoveType.Move;

                        if (!isMoved && y + 2 >= 0 && game.GameBoard[y + 2, x] == null)
                            result[y + 2][x] = MoveType.Move;
                    }

                    if (y + 1 >= 0 && x - 1 >= 0)
                    {
                        var piece = game.GameBoard[y + 1, x - 1];
                        if (piece != null)
                        {
                            if (piece.Owner != owner)
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
                        else
                        {
                            result[y + 1][x - 1] = MoveType.GhostKill;
                        }
                    }
                    if (y + 1 >= 0 && x + 1 >= 0)
                    {
                        var piece = game.GameBoard[y + 1, x + 1];
                        if (piece != null)
                        {
                            if (piece.Owner != owner)
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
                        else
                        {
                            result[y + 1][x + 1] = MoveType.GhostKill;
                        }
                    }
                }
                else
                {

                }
            }

            return result;
        }

    }

}

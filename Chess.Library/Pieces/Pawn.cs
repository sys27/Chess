﻿using System;
using System.Linq;

namespace Chess.Library.Pieces
{

    public class Pawn : Piece
    {

        public Pawn(Players owner) : base(owner) { }

        public Pawn(BoardPoint coordinates, Players owner) : base(coordinates, owner) { }

        public Pawn(int y, int x, Players owner) : base(y, x, owner) { }

        public override string ToString()
        {
            return base.ToString("Pawn");
        }

        private MoveType CheckEnPassant(Game game)
        {
            var lastMove = game.Moves.LastOrDefault();
            if (lastMove != null && game.GameBoard[lastMove.To] is Pawn &&
                Math.Abs(lastMove.To.Y - lastMove.From.Y) == 2)
                return MoveType.EnPassant;
            else
                return MoveType.GhostKill;
        }

        protected override MoveType _CanMove(Game game, int y, int x)
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
                if (!game.GetCheck(owner))
                {
                    if (Board.CheckY(y - 1) && game.GameBoard[y - 1, x] == null)
                    {
                        result[y - 1][x] = MoveType.Move;

                        if (!isMoved && y - 2 >= 0 && game.GameBoard[y - 2, x] == null)
                            result[y - 2][x] = MoveType.Move;
                    }

                    if (Board.CheckCoordinates(y - 1, x - 1))
                    {
                        var piece = game.GameBoard[y - 1, x - 1];

                        result[y - 1][x - 1] = piece != null ? GetMoveTypeByPiece(piece) : CheckEnPassant(game);
                    }
                    if (Board.CheckCoordinates(y - 1, x + 1))
                    {
                        var piece = game.GameBoard[y - 1, x + 1];

                        result[y - 1][x + 1] = piece != null ? GetMoveTypeByPiece(piece) : CheckEnPassant(game);
                    }
                }
                else
                {

                }
            }
            else
            {
                if (!game.GetCheck(owner))
                {
                    if (Board.CheckY(y + 1) && game.GameBoard[y + 1, x] == null)
                    {
                        result[y + 1][x] = MoveType.Move;

                        if (!isMoved && y + 2 >= 0 && game.GameBoard[y + 2, x] == null)
                            result[y + 2][x] = MoveType.Move;
                    }

                    if (Board.CheckCoordinates(y + 1, x - 1))
                    {
                        var piece = game.GameBoard[y + 1, x - 1];

                        result[y + 1][x - 1] = piece != null ? GetMoveTypeByPiece(piece) : CheckEnPassant(game);
                    }
                    if (Board.CheckCoordinates(y + 1, x + 1))
                    {
                        var piece = game.GameBoard[y + 1, x + 1];

                        result[y + 1][x + 1] = piece != null ? GetMoveTypeByPiece(piece) : CheckEnPassant(game);
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

﻿using System;

namespace Chess.Library.Pieces
{

    public class King : Piece
    {

        public King(Players owner)
            : base(owner)
        {

        }

        public King(BoardPoint coordinates, Players owner)
            : base(coordinates, owner)
        {

        }

        public King(int y, int x, Players owner)
            : base(y, x, owner)
        {

        }

        public override string ToString()
        {
            return base.ToString("King");
        }

        private void CheckCell(int y, int x, MoveType[][] result, Game game)
        {
            if (game.IsCellNotAttacked(y, x, owner))
            {
                var piece = game.GameBoard[y, x];

                result[y][x] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.Move;
            }
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

            var y = coordinates.Y;
            var x = coordinates.X;

            if (y - 1 >= 0)
            {
                if (x - 1 >= 0)
                    CheckCell(y - 1, x - 1, result, game);
                if (x + 1 < 8)
                    CheckCell(y - 1, x + 1, result, game);

                CheckCell(y - 1, x, result, game);
            }

            if (x - 1 >= 0)
                CheckCell(y, x - 1, result, game);
            if (x + 1 < 8)
                CheckCell(y, x + 1, result, game);

            if (y + 1 < 8)
            {
                if (x - 1 >= 0)
                    CheckCell(y + 1, x - 1, result, game);
                if (x + 1 < 8)
                    CheckCell(y + 1, x + 1, result, game);

                CheckCell(y + 1, x, result, game);
            }

            // castling
            if (!game.GetCheck(owner) && !isMoved && (y == 0 || y == 7) && x == 4)
            {
                if (result[y][x + 1] == MoveType.Move)
                {
                    if (game.IsCellNotAttacked(y, x + 2, owner) && game.GameBoard[y, x + 2] == null)
                    {
                        var rook = game.GameBoard[y, x + 3] as Rook;
                        if (rook != null && !rook.IsMoved)
                            result[y][x + 2] = MoveType.Castling;
                    }
                }

                if (result[y][x - 1] == MoveType.Move)
                {
                    if (game.IsCellNotAttacked(y, x - 2, owner) && game.GameBoard[y, x - 2] == null &&
                        game.IsCellNotAttacked(y, x - 3, owner) && game.GameBoard[y, x - 3] == null)
                    {
                        var rook = game.GameBoard[y, x - 4] as Rook;
                        if (rook != null && !rook.IsMoved)
                            result[y][x - 2] = MoveType.Castling;
                    }
                }
            }

            return result;
        }

    }

}

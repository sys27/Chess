using System;

namespace Chess.Library.Pieces
{

    public class Knight : Piece
    {

        public Knight(Players owner)
            : base(owner)
        {

        }

        public Knight(BoardPoint coordinates, Players owner)
            : base(coordinates, owner)
        {

        }

        public Knight(int y, int x, Players owner)
            : base(y, x, owner)
        {

        }

        public override string ToString()
        {
            return base.ToString("Knight");
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

            if (!game.GetCheck(owner))
            {
                var y = coordinates.Y;
                var x = coordinates.X;

                if (y + 2 < 8)
                {
                    if (x + 1 < 8)
                    {
                        var piece = game.GameBoard[y + 2, x + 1];

                        result[y + 2][x + 1] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.Move;
                    }
                    if (x - 1 >= 0)
                    {
                        var piece = game.GameBoard[y + 2, x - 1];

                        result[y + 2][x - 1] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.Move;
                    }
                }

                if (y + 1 < 8)
                {
                    if (x + 2 < 8)
                    {
                        var piece = game.GameBoard[y + 1, x + 2];

                        result[y + 1][x + 2] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.Move;
                    }
                    if (x - 2 >= 0)
                    {
                        var piece = game.GameBoard[y + 1, x - 2];

                        result[y + 1][x - 2] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.Move;
                    }
                }

                if (y - 1 >= 0)
                {
                    if (x + 2 < 8)
                    {
                        var piece = game.GameBoard[y - 1, x + 2];

                        result[y - 1][x + 2] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.Move;
                    }
                    if (x - 2 >= 0)
                    {
                        var piece = game.GameBoard[y - 1, x - 2];

                        result[y - 1][x - 2] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.Move;
                    }
                }

                if (y - 2 >= 0)
                {
                    if (x + 1 < 8)
                    {
                        var piece = game.GameBoard[y - 2, x + 1];

                        result[y - 2][x + 1] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.Move;
                    }
                    if (x - 1 >= 0)
                    {
                        var piece = game.GameBoard[y - 2, x - 1];

                        result[y - 2][x - 1] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.Move;
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

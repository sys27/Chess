using System;

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

        public override MoveType CanMove(Game game, int y, int x)
        {
            if (y < 0 || y > 7 || x < 0 || x > 7)
                throw new ArgumentOutOfRangeException();

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
                    if (y - 1 >= 0 && game.GameBoard[y - 1, x] == null)
                    {
                        result[y - 1][x] = MoveType.Move;

                        if (!isMoved && y - 2 >= 0 && game.GameBoard[y - 2, x] == null)
                            result[y - 2][x] = MoveType.Move;
                    }

                    if (y - 1 >= 0 && x - 1 >= 0)
                    {
                        var piece = game.GameBoard[y - 1, x - 1];

                        result[y - 1][x - 1] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.GhostKill;
                    }
                    if (y - 1 >= 0 && x + 1 <= 7)
                    {
                        var piece = game.GameBoard[y - 1, x + 1];

                        result[y - 1][x + 1] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.GhostKill;
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
                    if (y + 1 >= 0 && game.GameBoard[y + 1, x] == null)
                    {
                        result[y + 1][x] = MoveType.Move;

                        if (!isMoved && y + 2 >= 0 && game.GameBoard[y + 2, x] == null)
                            result[y + 2][x] = MoveType.Move;
                    }

                    if (y + 1 >= 0 && x - 1 >= 0)
                    {
                        var piece = game.GameBoard[y + 1, x - 1];

                        result[y + 1][x - 1] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.GhostKill;
                    }
                    if (y + 1 >= 0 && x + 1 <= 7)
                    {
                        var piece = game.GameBoard[y + 1, x + 1];

                        result[y + 1][x + 1] = piece != null ? GetMoveTypeByPiece(piece) : MoveType.GhostKill;
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

using System;

namespace Chess.Library.Pieces
{

    public class King : Piece
    {

        public King(Players owner)
            : base(owner) { }

        public King(BoardPoint coordinates, Players owner)
            : base(coordinates, owner) { }

        public King(int y, int x, Players owner)
            : base(y, x, owner) { }

        public override string ToString()
        {
            return base.ToString("King");
        }

        public override MoveType CanMove(Game game, int y, int x)
        {
            // todo: reimplement
            return GetAvailableMoves(game)[y][x];
        }

        private void CheckCell(int y, int x, MoveType[][] result, Game game)
        {
            if (game.IsCellNotAttacked(y, x, owner))
            {
                var piece = game.GameBoard[y, x];
                if (piece != null)
                {
                    if (piece.Owner == owner)
                        result[y][x] = MoveType.Protect;
                    else
                        result[y][x] = MoveType.Kill;
                }
                else
                {
                    result[y][x] = MoveType.Move;
                }
            }
        }

        public override MoveType[][] GetAvailableMoves(Game game)
        {
            var result = new MoveType[8][];
            for (int i = 0; i < 8; i++)
                result[i] = new MoveType[8];

            // todo: Castling

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

            return result;
        }

    }

}

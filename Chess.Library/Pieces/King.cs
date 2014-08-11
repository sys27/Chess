using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{

    public class King : Piece
    {

        private bool isMoved;

        public King(PieceColor color)
            : base(color) { }

        public King(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public King(int y, int x, PieceColor color)
            : base(y, x, color) { }

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
            if (game.IsCellNotAttacked(y - 1, x, color))
            {
                var piece = game.GameBoard[y - 1, x];
                if (piece != null)
                {
                    if (piece.Color == color)
                        result[y - 1][x] = MoveType.Protect;
                    else
                        result[y - 1][x] = MoveType.Kill;
                }
                else
                {
                    result[y - 1][x] = MoveType.Move;
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

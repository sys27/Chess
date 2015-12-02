using System;

namespace Chess.Library.Pieces
{

    public class Rook : Piece
    {

        public Rook(Players owner)
            : base(owner)
        {

        }

        public Rook(BoardPoint coordinates, Players owner)
            : base(coordinates, owner)
        {

        }

        public Rook(int y, int x, Players owner)
            : base(y, x, owner)
        {

        }

        public override string ToString()
        {
            return base.ToString("Rook");
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

            // todo: Castling

            if (!game.GetCheck(owner))
            {
                // left
                for (int i = coordinates.X - 1; i >= 0; i--)
                {
                    var piece = game.GameBoard[coordinates.Y, i];
                    if (piece != null)
                    {
                        result[coordinates.Y][i] = GetMoveTypeByPiece(piece);

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
                        result[coordinates.Y][i] = GetMoveTypeByPiece(piece);

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
                        result[i][coordinates.X] = GetMoveTypeByPiece(piece);

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
                        result[i][coordinates.X] = GetMoveTypeByPiece(piece);

                        break;
                    }

                    result[i][coordinates.X] = MoveType.Move;
                }
            }
            else
            {

            }

            return result;
        }

    }

}

using System;

namespace Chess.Library.Pieces
{

    public class Queen : Piece
    {

        public Queen(Players owner)
            : base(owner)
        {

        }

        public Queen(BoardPoint coordinates, Players owner)
            : base(coordinates, owner)
        {

        }

        public Queen(int y, int x, Players owner)
            : base(y, x, owner)
        {

        }

        public override string ToString()
        {
            return base.ToString("Queen");
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

                // up-left
                for (int x = coordinates.X - 1, y = coordinates.Y - 1; x >= 0 && y >= 0; x--, y--)
                {
                    var piece = game.GameBoard[y, x];
                    if (piece != null)
                    {
                        result[y][x] = GetMoveTypeByPiece(piece);

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
                        result[y][x] = GetMoveTypeByPiece(piece);

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
                        result[y][x] = GetMoveTypeByPiece(piece);

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
                        result[y][x] = GetMoveTypeByPiece(piece);

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

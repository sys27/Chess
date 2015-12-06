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
            if (y < 0 || y > 7 || x < 0 || x > 7)
                throw new ArgumentOutOfRangeException();

            if (!game.GetCheck(owner))
            {
                // same cell
                if (coordinates.Y == y && coordinates.X == x)
                    return MoveType.None;

                if (coordinates.Y != y && coordinates.X != x)
                    return MoveType.None;

                Piece piece;
                if (x < coordinates.X) // left
                {
                    for (int i = coordinates.X - 1; i >= x + 1; i--)
                    {
                        piece = game.GameBoard[coordinates.Y, i];
                        if (piece != null)
                            return MoveType.None;
                    }
                }
                else if (x > coordinates.X) // right
                {
                    for (int i = coordinates.X + 1; i <= x - 1; i++)
                    {
                        piece = game.GameBoard[coordinates.Y, i];
                        if (piece != null)
                            return MoveType.None;
                    }
                }
                else if (y < coordinates.Y) // up
                {
                    for (int i = coordinates.Y - 1; i >= y + 1; i--)
                    {
                        piece = game.GameBoard[i, coordinates.X];
                        if (piece != null)
                            return MoveType.None;
                    }
                }
                else if (y > coordinates.Y) // down
                {
                    for (int i = coordinates.Y + 1; i <= y - 1; i++)
                    {
                        piece = game.GameBoard[i, coordinates.X];
                        if (piece != null)
                            return MoveType.None;
                    }
                }

                piece = game.GameBoard[y, x];

                return piece != null ? GetMoveTypeByPiece(piece) : MoveType.Move;
            }

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
            }
            else
            {

            }

            return result;
        }

    }

}

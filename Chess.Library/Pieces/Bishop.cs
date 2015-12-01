using System;

namespace Chess.Library.Pieces
{

    public class Bishop : Piece
    {

        public Bishop(Players owner)
            : base(owner)
        {

        }

        public Bishop(BoardPoint coordinates, Players owner)
            : base(coordinates, owner)
        {

        }

        public Bishop(int y, int x, Players owner)
            : base(y, x, owner)
        {

        }

        public override string ToString()
        {
            return base.ToString("Bishop");
        }

        private MoveType CheckPiece(Piece piece)
        {
            if (piece.Owner == owner)
                return MoveType.Protect;
            else if (piece is King)
                return MoveType.Check;
            else
                return MoveType.Kill;
        }

        public override MoveType CanMove(Game game, int y, int x)
        {
            if (!game.GetCheck(owner))
            {
                // a cell is not on diagonal
                if (Math.Abs(coordinates.Y - y) != Math.Abs(coordinates.X - x))
                    return MoveType.None;

                Piece piece;
                if (y < coordinates.Y && x < coordinates.X) // up-left
                {
                    for (int _x = coordinates.X - 1, _y = coordinates.Y - 1; _x >= x + 1 && _y >= y + 1; _x--, _y--)
                    {
                        piece = game.GameBoard[_y, _x];
                        if (piece != null)
                            return MoveType.None;
                    }
                }
                else if (y < coordinates.Y && x > coordinates.X) // up-right
                {
                    for (int _x = coordinates.X + 1, _y = coordinates.Y - 1; _x <= x - 1 && _y >= y + 1; _x++, _y--)
                    {
                        piece = game.GameBoard[_y, _x];
                        if (piece != null)
                            return MoveType.None;
                    }
                }
                else if (y > coordinates.Y && x < coordinates.X) // down-left
                {
                    for (int _x = coordinates.X - 1, _y = coordinates.Y + 1; _x >= x + 1 && _y <= y - 1; _x--, _y++)
                    {
                        piece = game.GameBoard[_y, _x];
                        if (piece != null)
                            return MoveType.None;
                    }
                }
                else if (y > coordinates.Y && x > coordinates.X) // down-right
                {
                    for (int _x = coordinates.X + 1, _y = coordinates.Y + 1; _x <= x - 1 && _y <= y - 1; _x++, _y++)
                    {
                        piece = game.GameBoard[_y, _x];
                        if (piece != null)
                            return MoveType.None;
                    }
                }

                piece = game.GameBoard[y, x];

                return piece != null ? CheckPiece(piece) : MoveType.Move;
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
                // up-left
                for (int x = coordinates.X - 1, y = coordinates.Y - 1; x >= 0 && y >= 0; x--, y--)
                {
                    var piece = game.GameBoard[y, x];
                    if (piece != null)
                    {
                        result[y][x] = CheckPiece(piece);

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
                        result[y][x] = CheckPiece(piece);

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
                        result[y][x] = CheckPiece(piece);

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
                        result[y][x] = CheckPiece(piece);

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

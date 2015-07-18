using System;

namespace Chess.Library.Pieces
{

    public class Bishop : Piece
    {

        public Bishop(Players owner)
            : base(owner) { }

        public Bishop(BoardPoint coordinates, Players owner)
            : base(coordinates, owner) { }

        public Bishop(int y, int x, Players owner)
            : base(y, x, owner) { }

        public override string ToString()
        {
            return base.ToString("Bishop");
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
                // up-left
                for (int x = coordinates.X - 1, y = coordinates.Y - 1; x >= 0 && y >= 0; x--, y--)
                {
                    var piece = game.GameBoard[y, x];
                    if (piece != null)
                    {
                        if (piece.Owner != owner)
                        {
                            if (piece is King)
                                result[y][x] = MoveType.Check;
                            else
                                result[y][x] = MoveType.Kill;
                        }
                        else
                            result[y][x] = MoveType.Protect;

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
                        if (piece.Owner != owner)
                        {
                            if (piece is King)
                                result[y][x] = MoveType.Check;
                            else
                                result[y][x] = MoveType.Kill;
                        }
                        else
                            result[y][x] = MoveType.Protect;

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
                        if (piece.Owner != owner)
                        {
                            if (piece is King)
                                result[y][x] = MoveType.Check;
                            else
                                result[y][x] = MoveType.Kill;
                        }
                        else
                            result[y][x] = MoveType.Protect;

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
                        if (piece.Owner != owner)
                        {
                            if (piece is King)
                                result[y][x] = MoveType.Check;
                            else
                                result[y][x] = MoveType.Kill;
                        }
                        else
                            result[y][x] = MoveType.Protect;

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

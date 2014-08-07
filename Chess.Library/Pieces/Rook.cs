using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{

    public class Rook : Piece
    {

        private bool isMoved;

        public Rook(PieceColor color)
            : base(color) { }

        public Rook(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public Rook(int y, int x, PieceColor color)
            : base(y, x, color) { }

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

            if (!game.GetCheck(color))
            {
                // left
                for (int i = coordinates.X - 1; i >= 0; i--)
                {
                    var piece = game.GameBoard[coordinates.Y, i];
                    if (piece != null)
                    {
                        if (!(piece is King))
                        {
                            if (piece.Color != color)
                                result[coordinates.Y][i] = MoveType.Kill;
                            else
                                result[coordinates.Y][i] = MoveType.Protect;
                        }

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
                        if (!(piece is King))
                        {
                            if (piece.Color != color)
                                result[coordinates.Y][i] = MoveType.Kill;
                            else
                                result[coordinates.Y][i] = MoveType.Protect;
                        }

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
                        if (!(piece is King))
                        {
                            if (piece.Color != color)
                                result[i][coordinates.X] = MoveType.Kill;
                            else
                                result[i][coordinates.X] = MoveType.Protect;
                        }

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
                        if (!(piece is King))
                        {
                            if (piece.Color != color)
                                result[i][coordinates.X] = MoveType.Kill;
                            else
                                result[i][coordinates.X] = MoveType.Protect;
                        }

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

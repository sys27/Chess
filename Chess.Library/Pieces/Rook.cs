﻿using System;

namespace Chess.Library.Pieces
{

    public class Rook : Piece
    {

        private bool isMoved;

        public Rook(Players owner)
            : base(owner) { }

        public Rook(BoardPoint coordinates, Players owner)
            : base(coordinates, owner) { }

        public Rook(int y, int x, Players owner)
            : base(y, x, owner) { }

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

            if (!game.GetCheck(owner))
            {
                // left
                for (int i = coordinates.X - 1; i >= 0; i--)
                {
                    var piece = game.GameBoard[coordinates.Y, i];
                    if (piece != null)
                    {
                        if (piece.Owner != owner)
                        {
                            if (piece is King)
                                result[coordinates.Y][i] = MoveType.Check;
                            else
                                result[coordinates.Y][i] = MoveType.Kill;
                        }
                        else
                            result[coordinates.Y][i] = MoveType.Protect;

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
                        if (piece.Owner != owner)
                        {
                            if (piece is King)
                                result[coordinates.Y][i] = MoveType.Check;
                            else
                                result[coordinates.Y][i] = MoveType.Kill;
                        }
                        else
                            result[coordinates.Y][i] = MoveType.Protect;

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
                        if (piece.Owner != owner)
                        {
                            if (piece is King)
                                result[i][coordinates.X] = MoveType.Check;
                            else
                                result[i][coordinates.X] = MoveType.Kill;
                        }
                        else
                            result[i][coordinates.X] = MoveType.Protect;

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
                        if (piece.Owner != owner)
                        {
                            if (piece is King)
                                result[i][coordinates.X] = MoveType.Check;
                            else
                                result[i][coordinates.X] = MoveType.Kill;
                        }
                        else
                            result[i][coordinates.X] = MoveType.Protect;

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

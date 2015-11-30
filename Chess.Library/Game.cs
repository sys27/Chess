using System;
using System.Collections.Generic;

namespace Chess.Library
{

    public class Game
    {

        private Board board;

        private bool undoable;
        private Players currentPlayer;

        private List<PieceMove> allMoves;

        public Game()
            : this(new Board()) { }

        public Game(Board board)
        {
            this.board = board;
            this.allMoves = new List<PieceMove>();
            this.currentPlayer = Players.PlayerOne;
            this.undoable = true;
        }

        public void Turn(int fromY, int fromX, int toY, int toX)
        {
            Turn(new PieceMove(new BoardPoint(fromY, fromX), new BoardPoint(toY, toX)));
        }

        public void Turn(BoardPoint from, BoardPoint to)
        {
            Turn(new PieceMove(from, to));
        }

        public void Turn(PieceMove pieceMove)
        {
            var piece = board[pieceMove.From];
            if (piece == null)
                // todo: ...
                throw new GameTurnException();

            if (piece.Owner != currentPlayer)
                // todo: ...
                throw new GameTurnException();

            var move = piece.CanMove(this, pieceMove.To);

            if (move == MoveType.Move)
                board.Move(pieceMove.From, pieceMove.To);
            else if (move == MoveType.Kill)
                pieceMove.OriginalPiece = board.Kill(pieceMove.From, pieceMove.To);
            else
                // todo: ...
                throw new GameTurnException();

            allMoves.Add(pieceMove);

            currentPlayer = currentPlayer == Players.PlayerOne ? Players.PlayerTwo : Players.PlayerOne;
        }

        public void Undo()
        {
            if (!undoable)
                // todo: ...
                throw new GameTurnException();

            if (allMoves.Count < 2)
                // todo: ...
                throw new GameTurnException();

            var lastIndex = allMoves.Count - 1;
            var last = allMoves[lastIndex];
            if (last.OriginalPiece == null)
                board.Undo(last.From, last.To);
            else
                board.UndoKill(last.From, last.To, last.OriginalPiece);
            allMoves.RemoveAt(lastIndex);

            lastIndex--;
            last = allMoves[lastIndex];
            if (last.OriginalPiece == null)
                board.Undo(last.From, last.To);
            else
                board.UndoKill(last.From, last.To, last.OriginalPiece);
            allMoves.RemoveAt(lastIndex);
        }

        internal bool IsCellNotAttacked(int y, int x, Players oppositePlayer)
        {
            return IsCellAttacked(y, x, oppositePlayer) == MoveType.None;
        }

        internal MoveType IsCellAttacked(int y, int x, Players oppositePlayer)
        {
            var color = oppositePlayer == Players.PlayerOne ? Players.PlayerTwo : Players.PlayerOne;

            for (int _y = 0; _y < 8; _y++)
            {
                for (int _x = 0; _x < 8; _x++)
                {
                    var piece = board[_y, _x];
                    if (piece != null && piece.Owner == color)
                    {
                        var moves = piece.GetAvailableMoves(this);
                        var move = moves[y][x];
                        if (move != MoveType.None)
                            return move;
                    }
                }
            }

            return MoveType.None;
        }

        public bool GetCheck(Players owner)
        {
            // todo: !!!
            return false;
        }

        public Board GameBoard
        {
            get
            {
                return board;
            }
        }

        public Players CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }
        }

        public bool Undoable
        {
            get
            {
                return undoable;
            }
            set
            {
                undoable = value;
            }
        }

        public IEnumerable<PieceMove> Moves
        {
            get
            {
                return allMoves;
            }
        }

    }

}

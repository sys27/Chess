using Chess.Library.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library
{

    public class Game
    {

        private Board board;
        private bool whiteCheck;
        private bool blackCheck;

        private Players currentPlayer;
        private Dictionary<Players, PieceColor> playersColors;

        private List<PieceMove> allMoves;

        public Game()
            : this(new Board()) { }

        public Game(Board board)
        {
            this.board = board;
            this.allMoves = new List<PieceMove>();
            this.currentPlayer = Players.PlayerTwo;
            this.playersColors = new Dictionary<Players, PieceColor>()
            {
                { Players.PlayerOne, PieceColor.Black },
                { Players.PlayerTwo, PieceColor.White }
            };
        }

        public void Turn(BoardPoint from, BoardPoint to)
        {
            Turn(new PieceMove(from, to));
        }

        public void Turn(PieceMove pieceMove)
        {
            var piece = board[pieceMove.From];
            if (piece == null)
                //todo: ...
                throw new GameTurnException();

            if (piece.Color != playersColors[currentPlayer])
                //todo: ...
                throw new GameTurnException();

            var moves = piece.GetAvailableMoves(this);
            var move = moves[pieceMove.To.Y][pieceMove.To.X];

            if (move == MoveType.Move)
            {
                board.Move(pieceMove.From, pieceMove.To);
            }
            else if (move == MoveType.Kill)
            {
                var killedPiece = board.Kill(pieceMove.From, pieceMove.To);
                pieceMove.OriginalPiece = killedPiece;
            }
            else
            {
                //todo: ...
                throw new GameTurnException();
            }

            allMoves.Add(pieceMove);
            currentPlayer = currentPlayer == Players.PlayerOne ? Players.PlayerTwo : Players.PlayerOne;
        }

        public void Undo()
        {
            if (allMoves.Count < 2)
                //todo: ...
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

        internal bool IsCellNotAttacked(int y, int x, PieceColor oppositeColor)
        {
            return IsCellAttacked(y, x, oppositeColor) == MoveType.None;
        }

        internal MoveType IsCellAttacked(int y, int x, PieceColor oppositeColor)
        {
            var color = oppositeColor == PieceColor.White ? PieceColor.Black : PieceColor.White;

            for (int _y = 0; _y < 8; _y++)
            {
                for (int _x = 0; _x < 8; _x++)
                {
                    var piece = board[_y, _x];
                    if (piece != null && piece.Color == color)
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

        public bool GetCheck(PieceColor color)
        {
            if (color == PieceColor.White)
                return WhiteCheck;

            return BlackCheck;
        }

        public bool WhiteCheck
        {
            get
            {
                return whiteCheck;
            }
        }

        public bool BlackCheck
        {
            get
            {
                return blackCheck;
            }
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

    }

}

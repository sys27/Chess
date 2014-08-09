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

        private List<PieceMove> moves;

        public Game()
            : this(new Board()) { }

        public Game(Board board)
        {
            this.board = board;
            this.moves = new List<PieceMove>();
        }

        internal MoveType IsCellAttacked(BoardPoint position, PieceColor color)
        {
            //var color = oppositeColor == PieceColor.White ? PieceColor.Black : PieceColor.White;

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    var piece = board[y, x];
                    if (piece != null && piece.Color == color)
                    {
                        var moves = piece.GetAvailableMoves(this);
                        var move = moves[position.Y][position.X];
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

    }

}

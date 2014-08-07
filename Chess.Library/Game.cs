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

        private List<PieceMove> moves;

        public Game()
            : this(new Board()) { }

        public Game(Board board)
        {
            this.board = board;
            this.moves = new List<PieceMove>();
        }

        internal bool IsCellAttacked(BoardPoint position, PieceColor oppositeColor)
        {
            //var color = oppositeColor == PieceColor.White ? PieceColor.Black : PieceColor.White;

            //for (int y = 0; y < 8; y++)
            //{
            //    for (int x = 0; x < 8; x++)
            //    {
            //        var piece = board[y, x];
            //        if (piece != null && piece.Color == color)
            //        {
            //            var moves = piece.GetAvailableMoves(this);
            //            if (moves[position.Y][position.X])
            //                return true;
            //        }
            //    }
            //}

            return false;
        }
        
        public bool GetCheck(PieceColor color)
        {
            if (color == PieceColor.White)
                return WhiteKingCheck;

            return BlackKingCheck;
        }

        public bool WhiteKingCheck
        {
            get
            {
                return board.WhiteKing == null ? false : board.WhiteKing.Check;
            }
        }

        public bool BlackKingCheck
        {
            get
            {
                return board.BlackKing == null ? false : board.BlackKing.Check;
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

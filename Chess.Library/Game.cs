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

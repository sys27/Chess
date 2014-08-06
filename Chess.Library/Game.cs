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

        private King whiteKing;
        private King blackKing;
        private List<PieceMove> moves;

        public Game()
            : this(new Board()) { }

        public Game(Board board)
        {
            this.board = board;
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
                return whiteKing == null ? false : whiteKing.Check;
            }
        }

        public bool BlackKingCheck
        {
            get
            {
                return blackKing == null ? false : blackKing.Check;
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

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

        internal MoveType IsCellAttacked(int y, int x, PieceColor color)
        {
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

    }

}

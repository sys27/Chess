using Chess.Library.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library
{

    public class Board
    {

        private Piece[][] board;

        public Board()
        {
            InitializeBoard();
        }

        public Piece this[int y, int x]
        {
            get
            {
                return board[y][x];
            }
        }

        private void InitializeBoard()
        {
            board = new Piece[8][];
            for (int i = 0; i < board.Length; i++)
                board[i] = new Piece[8];

            InitializeWhitePieces();
            InitializeBlackPieces();
        }

        private void InitializeWhitePieces()
        {
            // rooks
            board[7][0] = new Rook(7, 0, PieceColor.White);
            board[7][7] = new Rook(7, 7, PieceColor.White);

            // knights
            board[7][1] = new Knight(7, 1, PieceColor.White);
            board[7][6] = new Knight(7, 6, PieceColor.White);

            // bishops
            board[7][2] = new Bishop(7, 2, PieceColor.White);
            board[7][5] = new Bishop(7, 5, PieceColor.White);

            // queen
            board[7][3] = new Queen(7, 3, PieceColor.White);
            // king
            board[7][4] = new King(7, 4, PieceColor.White);

            // pawns
            for (int i = 0; i < 8; i++)
                board[6][i] = new Pawn(6, i, PieceColor.White);
        }

        private void InitializeBlackPieces()
        {
            // rooks
            board[0][0] = new Rook(0, 0, PieceColor.Black);
            board[0][7] = new Rook(0, 7, PieceColor.Black);

            // knights
            board[0][1] = new Knight(0, 1, PieceColor.Black);
            board[0][6] = new Knight(0, 6, PieceColor.Black);

            // bishops
            board[0][2] = new Bishop(0, 2, PieceColor.Black);
            board[0][5] = new Bishop(0, 5, PieceColor.Black);

            // queen
            board[0][3] = new Queen(0, 3, PieceColor.Black);
            // king
            board[0][4] = new King(0, 4, PieceColor.Black);

            // pawns
            for (int i = 0; i < 8; i++)
                board[1][i] = new Pawn(1, i, PieceColor.Black);
        }

    }

}

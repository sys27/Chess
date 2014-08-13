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
            : this(false) { }

        private Board(bool isEmpty)
        {
            InitializeBoard(isEmpty);
        }

        public Piece this[int y, int x]
        {
            get
            {
                return board[y][x];
            }
            set
            {
                if (value != null)
                    value.Coordinates = new BoardPoint(y, x);
                board[y][x] = value;
            }
        }

        public Piece this[BoardPoint position]
        {
            get
            {
                return this[position.Y, position.X];
            }
            set
            {
                this[position.Y, position.X] = value;
            }
        }

        private void InitializeBoard(bool isEmpty)
        {
            board = new Piece[8][];
            for (int i = 0; i < board.Length; i++)
                board[i] = new Piece[8];

            if (!isEmpty)
            {
                InitializeWhitePieces();
                InitializeBlackPieces();
            }
        }

        private void InitializeWhitePieces()
        {
            // rooks
            this[7, 0] = new Rook(PieceColor.White);
            this[7, 7] = new Rook(PieceColor.White);

            // knights
            this[7, 1] = new Knight(PieceColor.White);
            this[7, 6] = new Knight(PieceColor.White);

            // bishops
            this[7, 2] = new Bishop(PieceColor.White);
            this[7, 5] = new Bishop(PieceColor.White);

            // queen
            this[7, 3] = new Queen(PieceColor.White);
            // king
            this[7, 4] = new King(PieceColor.White);

            // pawns
            for (int i = 0; i < 8; i++)
                this[6, i] = new Pawn(PieceColor.White);
        }

        private void InitializeBlackPieces()
        {
            // rooks
            this[0, 0] = new Rook(PieceColor.Black);
            this[0, 7] = new Rook(PieceColor.Black);

            // knights
            this[0, 1] = new Knight(PieceColor.Black);
            this[0, 6] = new Knight(PieceColor.Black);

            // bishops
            this[0, 2] = new Bishop(PieceColor.Black);
            this[0, 5] = new Bishop(PieceColor.Black);

            // queen
            this[0, 3] = new Queen(PieceColor.Black);
            // king
            this[0, 4] = new King(PieceColor.Black);

            // pawns
            for (int i = 0; i < 8; i++)
                this[1, i] = new Pawn(PieceColor.Black);
        }

        public void Move(BoardPoint from, BoardPoint to)
        {
            if (this[to] != null)
                // todo: ...
                throw new BoardMoveException();

            this[to] = this[from];
            this[from] = null;
        }

        public Piece Kill(BoardPoint from, BoardPoint to)
        {
            var piece = this[to];

            this[to] = this[from];
            this[from] = null;

            return piece;
        }

        public void Undo(BoardPoint from, BoardPoint to)
        {
            if (this[from] != null)
                // todo: ...
                throw new BoardMoveException();

            this[from] = this[to];
            this[to] = null;
        }

        public void UndoKill(BoardPoint from, BoardPoint to, Piece piece)
        {
            this[from] = this[to];
            this[to] = piece;
        }

        public static Board CreateEmpty()
        {
            return new Board(true);
        }

    }

}

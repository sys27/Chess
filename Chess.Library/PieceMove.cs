using Chess.Library.Pieces;
using System;

namespace Chess.Library
{
    
    public class PieceMove
    {

        private BoardPoint from;
        private BoardPoint to;
        private Piece originalPiece;

        public PieceMove(BoardPoint from, BoardPoint to)
        {
            this.from = from;
            this.to = to;
        }

        public BoardPoint From
        {
            get
            {
                return from;
            }
        }

        public BoardPoint To
        {
            get
            {
                return to;
            }
        }

        public Piece OriginalPiece
        {
            get
            {
                return originalPiece;
            }
            internal set
            {
                originalPiece = value;
            }
        }

    }

}

using Chess.Library.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library
{
    
    public class PieceMove
    {

        private BoardPoint from;
        private BoardPoint to;
        private Piece originalPiece;

        public PieceMove(BoardPoint from, BoardPoint to, Piece originalPiece)
        {
            this.from = from;
            this.to = to;
            this.originalPiece = originalPiece;
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
        }

    }

}

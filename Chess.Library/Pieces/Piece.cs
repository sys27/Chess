using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{

    public abstract class Piece
    {

        protected BoardPoint coordinates;
        protected PieceColor color;

        protected Piece(BoardPoint coordinates, PieceColor color)
        {
            this.coordinates = coordinates;
            this.color = color;
        }

        protected Piece(int x, int y, PieceColor color)
            : this(new BoardPoint(x, y), color) { }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            var piece = obj as Piece;
            if (piece == null)
                return false;

            return coordinates == piece.coordinates && color == piece.color;
        }

        public BoardPoint Coordinates
        {
            get
            {
                return coordinates;
            }
        }

        public PieceColor Color
        {
            get
            {
                return color;
            }
        }

    }

}

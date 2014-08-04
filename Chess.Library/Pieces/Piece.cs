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

        protected Piece(int y, int x, PieceColor color)
            : this(new BoardPoint(y, x), color) { }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            var piece = (Piece)obj;
            return coordinates == piece.coordinates && color == piece.color;
        }

        protected string ToString(string pieceName)
        {
            return string.Format("{0}: {1}, {2}", pieceName, coordinates.Y, coordinates.X);
        }

        public bool CanMove(int y, int x)
        {
            return GetAvailableMoves()[y][x];
        }

        public bool CanMove(BoardPoint to)
        {
            return CanMove(to.Y, to.X);
        }

        public abstract bool[][] GetAvailableMoves();

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

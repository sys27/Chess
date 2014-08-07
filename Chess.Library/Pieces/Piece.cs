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

        protected Piece(PieceColor color)
            : this(new BoardPoint(), color) { }

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
            return string.Format("{0}: {1}, {2} ({3})", pieceName, coordinates.Y.ToString(), coordinates.X.ToString(), color.ToString());
        }

        public abstract MoveType CanMove(Game game, int y, int x);

        public MoveType CanMove(Game game, BoardPoint to)
        {
            return CanMove(game, to.Y, to.X);
        }

        public abstract MoveType[][] GetAvailableMoves(Game game);

        public BoardPoint Coordinates
        {
            get
            {
                return coordinates;
            }
            set
            {
                coordinates = value;
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

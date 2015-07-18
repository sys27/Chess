using System;

namespace Chess.Library.Pieces
{

    public abstract class Piece
    {

        protected BoardPoint coordinates;
        protected readonly Players owner;

        protected Piece(Players owner)
            : this(new BoardPoint(), owner) { }

        protected Piece(BoardPoint coordinates, Players owner)
        {
            this.coordinates = coordinates;
            this.owner = owner;
        }

        protected Piece(int y, int x, Players color)
            : this(new BoardPoint(y, x), color) { }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            var piece = (Piece)obj;
            return coordinates == piece.coordinates && owner == piece.owner;
        }

        protected string ToString(string pieceName)
        {
            return string.Format("{0}: {1}, {2} ({3})", pieceName, coordinates.Y.ToString(), coordinates.X.ToString(), owner.ToString());
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

        public Players Owner
        {
            get
            {
                return owner;
            }
        }

    }

}

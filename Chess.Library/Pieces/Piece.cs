using System;

namespace Chess.Library.Pieces
{

    public abstract class Piece
    {

        protected BoardPoint coordinates;
        protected readonly Players owner;
        protected bool isMoved;

        protected Piece(Players owner)
            : this(new BoardPoint(), owner)
        {

        }

        protected Piece(BoardPoint coordinates, Players owner)
        {
            this.coordinates = coordinates;
            this.owner = owner;
        }

        protected Piece(int y, int x, Players color)
            : this(new BoardPoint(y, x), color)
        {

        }

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

        protected MoveType GetMoveTypeByPiece(Piece piece)
        {
            if (piece.Owner == owner)
                return MoveType.Protect;
            else if (piece is King)
                return MoveType.Check;
            else
                return MoveType.Kill;
        }

        protected abstract MoveType _CanMove(Game game, int y, int x);

        public MoveType CanMove(Game game, int y, int x)
        {
            if (y < 0 || y > 7 || x < 0 || x > 7)
                throw new ArgumentOutOfRangeException();

            return _CanMove(game, y, x);
        }

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

        public bool IsMoved
        {
            get
            {
                return isMoved;
            }
            set
            {
                isMoved = value;
            }
        }

    }

}

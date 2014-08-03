using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library
{

    public struct BoardPoint
    {

        private readonly int x;
        private readonly int y;

        public BoardPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(BoardPoint point)
        {
            return x == point.x && y == point.y;
        }

        public static bool operator ==(BoardPoint left, BoardPoint right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BoardPoint left, BoardPoint right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (obj.GetType() != typeof(BoardPoint))
                return false;

            return Equals((BoardPoint)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 47087;

                hash = hash * 22343 + x.GetHashCode();
                hash = hash & 22343 + y.GetHashCode();

                return hash;
            }
        }

        public override string ToString()
        {
            return string.Format("x: {0}, y: {1}", x.ToString(), y.ToString());
        }

        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }

    }

}

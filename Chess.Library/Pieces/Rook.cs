﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{

    public class Rook : Piece
    {

        public Rook(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public Rook(int y, int x, PieceColor color)
            : base(y, x, color) { }

        public override string ToString()
        {
            return base.ToString("Rook");
        }
        
        public override bool CanMove(int y, int x)
        {
            throw new NotImplementedException();
        }

        public override bool CanMove(BoardPoint to)
        {
            throw new NotImplementedException();
        }

        public override bool[][] GetAvailableMoves()
        {
            throw new NotImplementedException();
        }

    }

}

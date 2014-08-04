﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library.Pieces
{
    
    public class Pawn : Piece
    {

        public Pawn(BoardPoint coordinates, PieceColor color)
            : base(coordinates, color) { }

        public Pawn(int y, int x, PieceColor color)
            : base(y, x, color) { }

        public override string ToString()
        {
            return base.ToString("Pawn");
        }

        public override bool[][] GetAvailableMoves()
        {
            throw new NotImplementedException();
        }

    }

}

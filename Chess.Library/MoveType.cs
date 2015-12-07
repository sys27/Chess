using System;

namespace Chess.Library
{
    
    public enum MoveType
    {

        None,
        Move,
        Protect,
        Kill,
        GhostKill,
        Check,
        Castling,
        EnPassant

    }

}

using System;
using System.Runtime.Serialization;

namespace Chess.Library
{

    [Serializable]
    public class BoardMoveException : Exception
    {

        // todo: add info about positions

        public BoardMoveException() { }

        public BoardMoveException(string message) : base(message) { }

        public BoardMoveException(string message, Exception inner) : base(message, inner) { }

        protected BoardMoveException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

    }

}

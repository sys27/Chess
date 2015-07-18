using System;
using System.Runtime.Serialization;

namespace Chess.Library
{

    [Serializable]
    public class GameTurnException : Exception
    {

        // todo: add info about move

        public GameTurnException() { }

        public GameTurnException(string message) : base(message) { }

        public GameTurnException(string message, Exception inner) : base(message, inner) { }

        protected GameTurnException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

    }

}

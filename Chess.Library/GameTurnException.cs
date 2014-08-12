using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Library
{

    [Serializable]
    public class GameTurnException : Exception
    {

        public GameTurnException() { }

        public GameTurnException(string message) : base(message) { }

        public GameTurnException(string message, Exception inner) : base(message, inner) { }

        protected GameTurnException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

    }

}

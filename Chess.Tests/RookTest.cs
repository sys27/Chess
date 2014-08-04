using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Library;

namespace Chess.Tests
{

    [TestClass]
    public class RookTest
    {

        private Board board;

        [TestInitialize]
        public void TestInitialize()
        {
            board = new Board();
        }

    }

}

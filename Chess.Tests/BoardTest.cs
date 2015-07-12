using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Library;
using Chess.Library.Pieces;

namespace Chess.Tests
{

    [TestClass]
    public class BoardTest
    {

        private Board board;

        [TestInitialize]
        public void TestInitialize()
        {
            board = new Board();
        }

        [TestMethod]
        public void InitTest()
        {
            // black
            Assert.AreEqual(new Rook(0, 0, Players.PlayerTwo), board[0, 0]);
            Assert.AreEqual(new Rook(0, 7, Players.PlayerTwo), board[0, 7]);

            Assert.AreEqual(new Knight(0, 1, Players.PlayerTwo), board[0, 1]);
            Assert.AreEqual(new Knight(0, 6, Players.PlayerTwo), board[0, 6]);

            Assert.AreEqual(new Bishop(0, 2, Players.PlayerTwo), board[0, 2]);
            Assert.AreEqual(new Bishop(0, 5, Players.PlayerTwo), board[0, 5]);

            Assert.AreEqual(new Queen(0, 3, Players.PlayerTwo), board[0, 3]);
            Assert.AreEqual(new King(0, 4, Players.PlayerTwo), board[0, 4]);

            for (int i = 0; i < 8; i++)
                Assert.AreEqual(new Pawn(1, i, Players.PlayerTwo), board[1, i]);

            // white
            Assert.AreEqual(new Rook(7, 0, Players.PlayerOne), board[7, 0]);
            Assert.AreEqual(new Rook(7, 7, Players.PlayerOne), board[7, 7]);

            Assert.AreEqual(new Knight(7, 1, Players.PlayerOne), board[7, 1]);
            Assert.AreEqual(new Knight(7, 6, Players.PlayerOne), board[7, 6]);

            Assert.AreEqual(new Bishop(7, 2, Players.PlayerOne), board[7, 2]);
            Assert.AreEqual(new Bishop(7, 5, Players.PlayerOne), board[7, 5]);

            Assert.AreEqual(new Queen(7, 3, Players.PlayerOne), board[7, 3]);
            Assert.AreEqual(new King(7, 4, Players.PlayerOne), board[7, 4]);

            for (int i = 0; i < 8; i++)
                Assert.AreEqual(new Pawn(6, i, Players.PlayerOne), board[6, i]);
        }

    }

}

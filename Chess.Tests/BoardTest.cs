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
            Assert.AreEqual(new Rook(0, 0, PieceColor.Black), board[0, 0]);
            Assert.AreEqual(new Rook(0, 7, PieceColor.Black), board[0, 7]);

            Assert.AreEqual(new Knight(0, 1, PieceColor.Black), board[0, 1]);
            Assert.AreEqual(new Knight(0, 6, PieceColor.Black), board[0, 6]);

            Assert.AreEqual(new Bishop(0, 2, PieceColor.Black), board[0, 2]);
            Assert.AreEqual(new Bishop(0, 5, PieceColor.Black), board[0, 5]);

            Assert.AreEqual(new Queen(0, 3, PieceColor.Black), board[0, 3]);
            Assert.AreEqual(new King(0, 4, PieceColor.Black), board[0, 4]);

            for (int i = 0; i < 8; i++)
                Assert.AreEqual(new Pawn(1, i, PieceColor.Black), board[1, i]);

            // white
            Assert.AreEqual(new Rook(7, 0, PieceColor.White), board[7, 0]);
            Assert.AreEqual(new Rook(7, 7, PieceColor.White), board[7, 7]);

            Assert.AreEqual(new Knight(7, 1, PieceColor.White), board[7, 1]);
            Assert.AreEqual(new Knight(7, 6, PieceColor.White), board[7, 6]);

            Assert.AreEqual(new Bishop(7, 2, PieceColor.White), board[7, 2]);
            Assert.AreEqual(new Bishop(7, 5, PieceColor.White), board[7, 5]);

            Assert.AreEqual(new Queen(7, 3, PieceColor.White), board[7, 3]);
            Assert.AreEqual(new King(7, 4, PieceColor.White), board[7, 4]);

            for (int i = 0; i < 8; i++)
                Assert.AreEqual(new Pawn(6, i, PieceColor.White), board[6, i]);
        }

    }

}

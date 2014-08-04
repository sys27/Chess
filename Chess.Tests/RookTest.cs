using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Library;
using Chess.Library.Pieces;

namespace Chess.Tests
{

    [TestClass]
    public class RookTest
    {

        private Board board;

        [TestInitialize]
        public void TestInitialize()
        {
            board = Board.CreateEmpty();
        }

        [TestMethod]
        public void GetAvailableMoves_LeftMove()
        {
            var rook = new Rook(PieceColor.White);
            board[4, 4] = rook;
            board[4, 1] = new Pawn(PieceColor.White);

            var moves = rook.GetAvailableMoves(board);

            Assert.IsTrue(moves[4][3]);
            Assert.IsTrue(moves[4][2]);
            Assert.IsFalse(moves[4][1]);
            Assert.IsFalse(moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_LeftKill()
        {
            var rook = new Rook(PieceColor.White);
            board[4, 4] = rook;
            board[4, 1] = new Pawn(PieceColor.Black);

            var moves = rook.GetAvailableMoves(board);

            Assert.IsTrue(moves[4][3]);
            Assert.IsTrue(moves[4][2]);
            Assert.IsTrue(moves[4][1]);
            Assert.IsFalse(moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightMove()
        {
            var rook = new Rook(PieceColor.White);
            board[4, 4] = rook;
            board[4, 6] = new Pawn(PieceColor.White);

            var moves = rook.GetAvailableMoves(board);

            Assert.IsTrue(moves[4][5]);
            Assert.IsFalse(moves[4][6]);
            Assert.IsFalse(moves[4][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightKill()
        {
            var rook = new Rook(PieceColor.White);
            board[4, 4] = rook;
            board[4, 6] = new Pawn(PieceColor.Black);

            var moves = rook.GetAvailableMoves(board);

            Assert.IsTrue(moves[4][5]);
            Assert.IsTrue(moves[4][6]);
            Assert.IsFalse(moves[4][7]);
        }

    }

}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Library;
using Chess.Library.Pieces;

namespace Chess.Tests
{

    [TestClass]
    public class BishopTest
    {

        private Board board;

        [TestInitialize]
        public void TestInitialize()
        {
            board = Board.CreateEmpty();
        }

        [TestMethod]
        public void GetAvailableMoves_UpLeftMove()
        {
            var bishop = new Bishop(PieceColor.White);
            board[3, 4] = bishop;
            board[1, 2] = new Pawn(PieceColor.White);

            var moves = bishop.GetAvailableMoves(board);

            Assert.IsTrue(moves[2][3]);
            Assert.IsFalse(moves[1][2]);
            Assert.IsFalse(moves[0][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpLeftKill()
        {
            var bishop = new Bishop(PieceColor.White);
            board[3, 4] = bishop;
            board[1, 2] = new Pawn(PieceColor.Black);

            var moves = bishop.GetAvailableMoves(board);

            Assert.IsTrue(moves[2][3]);
            Assert.IsTrue(moves[1][2]);
            Assert.IsFalse(moves[0][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpRightMove()
        {
            var bishop = new Bishop(PieceColor.White);
            board[3, 4] = bishop;
            board[1, 6] = new Pawn(PieceColor.White);

            var moves = bishop.GetAvailableMoves(board);

            Assert.IsTrue(moves[2][5]);
            Assert.IsFalse(moves[1][6]);
            Assert.IsFalse(moves[0][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpRightKill()
        {
            var bishop = new Bishop(PieceColor.White);
            board[3, 4] = bishop;
            board[1, 6] = new Pawn(PieceColor.Black);

            var moves = bishop.GetAvailableMoves(board);

            Assert.IsTrue(moves[2][5]);
            Assert.IsTrue(moves[1][6]);
            Assert.IsFalse(moves[0][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownLeftMove()
        {
            var bishop = new Bishop(PieceColor.White);
            board[3, 4] = bishop;
            board[6, 1] = new Pawn(PieceColor.White);

            var moves = bishop.GetAvailableMoves(board);

            Assert.IsTrue(moves[4][3]);
            Assert.IsTrue(moves[5][2]);
            Assert.IsFalse(moves[6][1]);
            Assert.IsFalse(moves[7][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownLeftKill()
        {
            var bishop = new Bishop(PieceColor.White);
            board[3, 4] = bishop;
            board[6, 1] = new Pawn(PieceColor.Black);

            var moves = bishop.GetAvailableMoves(board);

            Assert.IsTrue(moves[4][3]);
            Assert.IsTrue(moves[5][2]);
            Assert.IsTrue(moves[6][1]);
            Assert.IsFalse(moves[7][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownRightMove()
        {
            var bishop = new Bishop(PieceColor.White);
            board[3, 4] = bishop;
            board[5, 6] = new Pawn(PieceColor.White);

            var moves = bishop.GetAvailableMoves(board);

            Assert.IsTrue(moves[4][5]);
            Assert.IsFalse(moves[5][6]);
            Assert.IsFalse(moves[6][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownRightKill()
        {
            var bishop = new Bishop(PieceColor.White);
            board[3, 4] = bishop;
            board[5, 6] = new Pawn(PieceColor.Black);

            var moves = bishop.GetAvailableMoves(board);

            Assert.IsTrue(moves[4][5]);
            Assert.IsTrue(moves[5][6]);
            Assert.IsFalse(moves[6][7]);
        }

    }

}

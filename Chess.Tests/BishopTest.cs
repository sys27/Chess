using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Library;
using Chess.Library.Pieces;

namespace Chess.Tests
{
    
    [TestClass]
    public class BishopTest
    {

        private Game game;

        [TestInitialize]
        public void TestInitialize()
        {
            game = new Game(Board.CreateEmpty());
        }

        [TestMethod]
        public void GetAvailableMoves_UpLeftMove()
        {
            var bishop = new Bishop(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 2] = new Pawn(PieceColor.White);

            var moves = bishop.GetAvailableMoves(game);

            Assert.IsTrue(moves[2][3]);
            Assert.IsFalse(moves[1][2]);
            Assert.IsFalse(moves[0][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpLeftKill()
        {
            var bishop = new Bishop(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 2] = new Pawn(PieceColor.Black);

            var moves = bishop.GetAvailableMoves(game);

            Assert.IsTrue(moves[2][3]);
            Assert.IsTrue(moves[1][2]);
            Assert.IsFalse(moves[0][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpRightMove()
        {
            var bishop = new Bishop(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 6] = new Pawn(PieceColor.White);

            var moves = bishop.GetAvailableMoves(game);

            Assert.IsTrue(moves[2][5]);
            Assert.IsFalse(moves[1][6]);
            Assert.IsFalse(moves[0][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpRightKill()
        {
            var bishop = new Bishop(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 6] = new Pawn(PieceColor.Black);

            var moves = bishop.GetAvailableMoves(game);

            Assert.IsTrue(moves[2][5]);
            Assert.IsTrue(moves[1][6]);
            Assert.IsFalse(moves[0][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownLeftMove()
        {
            var bishop = new Bishop(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[6, 1] = new Pawn(PieceColor.White);

            var moves = bishop.GetAvailableMoves(game);

            Assert.IsTrue(moves[4][3]);
            Assert.IsTrue(moves[5][2]);
            Assert.IsFalse(moves[6][1]);
            Assert.IsFalse(moves[7][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownLeftKill()
        {
            var bishop = new Bishop(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[6, 1] = new Pawn(PieceColor.Black);

            var moves = bishop.GetAvailableMoves(game);

            Assert.IsTrue(moves[4][3]);
            Assert.IsTrue(moves[5][2]);
            Assert.IsTrue(moves[6][1]);
            Assert.IsFalse(moves[7][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownRightMove()
        {
            var bishop = new Bishop(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[5, 6] = new Pawn(PieceColor.White);

            var moves = bishop.GetAvailableMoves(game);

            Assert.IsTrue(moves[4][5]);
            Assert.IsFalse(moves[5][6]);
            Assert.IsFalse(moves[6][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownRightKill()
        {
            var bishop = new Bishop(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[5, 6] = new Pawn(PieceColor.Black);

            var moves = bishop.GetAvailableMoves(game);

            Assert.IsTrue(moves[4][5]);
            Assert.IsTrue(moves[5][6]);
            Assert.IsFalse(moves[6][7]);
        }

    }

}

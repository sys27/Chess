using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Library;
using Chess.Library.Pieces;

namespace Chess.Tests
{

    [TestClass]
    public class RookTest
    {

        private Game game;

        [TestInitialize]
        public void TestInitialize()
        {
            game = new Game(Board.CreateEmpty());
        }

        [TestMethod]
        public void GetAvailableMoves_LeftMove()
        {
            var rook = new Rook(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 1] = new Pawn(PieceColor.White);

            var moves = rook.GetAvailableMoves(game);

            Assert.IsTrue(moves[4][3]);
            Assert.IsTrue(moves[4][2]);
            Assert.IsFalse(moves[4][1]);
            Assert.IsFalse(moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_LeftKill()
        {
            var rook = new Rook(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 1] = new Pawn(PieceColor.Black);

            var moves = rook.GetAvailableMoves(game);

            Assert.IsTrue(moves[4][3]);
            Assert.IsTrue(moves[4][2]);
            Assert.IsTrue(moves[4][1]);
            Assert.IsFalse(moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightMove()
        {
            var rook = new Rook(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 6] = new Pawn(PieceColor.White);

            var moves = rook.GetAvailableMoves(game);

            Assert.IsTrue(moves[4][5]);
            Assert.IsFalse(moves[4][6]);
            Assert.IsFalse(moves[4][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightKill()
        {
            var rook = new Rook(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 6] = new Pawn(PieceColor.Black);

            var moves = rook.GetAvailableMoves(game);

            Assert.IsTrue(moves[4][5]);
            Assert.IsTrue(moves[4][6]);
            Assert.IsFalse(moves[4][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpMove()
        {
            var rook = new Rook(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[1, 4] = new Pawn(PieceColor.White);

            var moves = rook.GetAvailableMoves(game);

            Assert.IsTrue(moves[3][4]);
            Assert.IsTrue(moves[2][4]);
            Assert.IsFalse(moves[1][4]);
            Assert.IsFalse(moves[0][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpKill()
        {
            var rook = new Rook(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[1, 4] = new Pawn(PieceColor.Black);

            var moves = rook.GetAvailableMoves(game);

            Assert.IsTrue(moves[3][4]);
            Assert.IsTrue(moves[2][4]);
            Assert.IsTrue(moves[1][4]);
            Assert.IsFalse(moves[0][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownMove()
        {
            var rook = new Rook(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[6, 4] = new Pawn(PieceColor.White);

            var moves = rook.GetAvailableMoves(game);

            Assert.IsTrue(moves[5][4]);
            Assert.IsFalse(moves[6][4]);
            Assert.IsFalse(moves[7][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownKill()
        {
            var rook = new Rook(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[6, 4] = new Pawn(PieceColor.Black);

            var moves = rook.GetAvailableMoves(game);

            Assert.IsTrue(moves[5][4]);
            Assert.IsTrue(moves[6][4]);
            Assert.IsFalse(moves[7][4]);
        }

    }

}

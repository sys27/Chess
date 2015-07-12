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
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 1] = new Pawn(Players.PlayerOne);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[4][2]);
            Assert.AreEqual(MoveType.Protect, moves[4][1]);
            Assert.AreEqual(MoveType.None, moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_LeftKill()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 1] = new Pawn(Players.PlayerTwo);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[4][2]);
            Assert.AreEqual(MoveType.Kill, moves[4][1]);
            Assert.AreEqual(MoveType.None, moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_LeftCheck()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 1] = new King(Players.PlayerTwo);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[4][2]);
            Assert.AreEqual(MoveType.Check, moves[4][1]);
            Assert.AreEqual(MoveType.None, moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightMove()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 6] = new Pawn(Players.PlayerOne);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Protect, moves[4][6]);
            Assert.AreEqual(MoveType.None, moves[4][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightKill()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 6] = new Pawn(Players.PlayerTwo);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Kill, moves[4][6]);
            Assert.AreEqual(MoveType.None, moves[4][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightCheck()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 6] = new King(Players.PlayerTwo);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Check, moves[4][6]);
            Assert.AreEqual(MoveType.None, moves[4][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpMove()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[1, 4] = new Pawn(Players.PlayerOne);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[3][4]);
            Assert.AreEqual(MoveType.Move, moves[2][4]);
            Assert.AreEqual(MoveType.Protect, moves[1][4]);
            Assert.AreEqual(MoveType.None, moves[0][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpKill()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[1, 4] = new Pawn(Players.PlayerTwo);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[3][4]);
            Assert.AreEqual(MoveType.Move, moves[2][4]);
            Assert.AreEqual(MoveType.Kill, moves[1][4]);
            Assert.AreEqual(MoveType.None, moves[0][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpCheck()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[1, 4] = new King(Players.PlayerTwo);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[3][4]);
            Assert.AreEqual(MoveType.Move, moves[2][4]);
            Assert.AreEqual(MoveType.Check, moves[1][4]);
            Assert.AreEqual(MoveType.None, moves[0][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownMove()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[6, 4] = new Pawn(Players.PlayerOne);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Protect, moves[6][4]);
            Assert.AreEqual(MoveType.None, moves[7][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownKill()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[6, 4] = new Pawn(Players.PlayerTwo);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Kill, moves[6][4]);
            Assert.AreEqual(MoveType.None, moves[7][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownCheck()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[6, 4] = new King(Players.PlayerTwo);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Check, moves[6][4]);
            Assert.AreEqual(MoveType.None, moves[7][4]);
        }

    }

}

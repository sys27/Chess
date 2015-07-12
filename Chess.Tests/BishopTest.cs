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
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 2] = new Pawn(Players.PlayerOne);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][3]);
            Assert.AreEqual(MoveType.Protect, moves[1][2]);
            Assert.AreEqual(MoveType.None, moves[0][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpLeftKill()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 2] = new Pawn(Players.PlayerTwo);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][3]);
            Assert.AreEqual(MoveType.Kill, moves[1][2]);
            Assert.AreEqual(MoveType.None, moves[0][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpLeftCheck()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 2] = new King(Players.PlayerTwo);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][3]);
            Assert.AreEqual(MoveType.Check, moves[1][2]);
            Assert.AreEqual(MoveType.None, moves[0][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpRightMove()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 6] = new Pawn(Players.PlayerOne);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][5]);
            Assert.AreEqual(MoveType.Protect, moves[1][6]);
            Assert.AreEqual(MoveType.None, moves[0][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpRightKill()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 6] = new Pawn(Players.PlayerTwo);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][5]);
            Assert.AreEqual(MoveType.Kill, moves[1][6]);
            Assert.AreEqual(MoveType.None, moves[0][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpRightCheck()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 6] = new King(Players.PlayerTwo);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][5]);
            Assert.AreEqual(MoveType.Check, moves[1][6]);
            Assert.AreEqual(MoveType.None, moves[0][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownLeftMove()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[6, 1] = new Pawn(Players.PlayerOne);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[5][2]);
            Assert.AreEqual(MoveType.Protect, moves[6][1]);
            Assert.AreEqual(MoveType.None, moves[7][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownLeftKill()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[6, 1] = new Pawn(Players.PlayerTwo);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[5][2]);
            Assert.AreEqual(MoveType.Kill, moves[6][1]);
            Assert.AreEqual(MoveType.None, moves[7][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownLeftCheck()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[6, 1] = new King(Players.PlayerTwo);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[5][2]);
            Assert.AreEqual(MoveType.Check, moves[6][1]);
            Assert.AreEqual(MoveType.None, moves[7][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownRightMove()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[5, 6] = new Pawn(Players.PlayerOne);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Protect, moves[5][6]);
            Assert.AreEqual(MoveType.None, moves[6][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownRightKill()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[5, 6] = new Pawn(Players.PlayerTwo);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Kill, moves[5][6]);
            Assert.AreEqual(MoveType.None, moves[6][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownRightCheck()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[5, 6] = new King(Players.PlayerTwo);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Check, moves[5][6]);
            Assert.AreEqual(MoveType.None, moves[6][7]);
        }

    }

}

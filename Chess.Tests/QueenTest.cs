using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Library;
using Chess.Library.Pieces;

namespace Chess.Tests
{

    [TestClass]
    public class QueenTest
    {

        private Game game;

        [TestInitialize]
        public void TestInitialize()
        {
            game = new Game(Board.CreateEmpty());
        }

        [TestMethod]
        public void CanMove_LeftMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[4, 1] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 2));
            Assert.AreEqual(MoveType.Protect, queen.CanMove(game, 4, 1));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 4, 0));
        }

        [TestMethod]
        public void CanMove_LeftKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[4, 1] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 2));
            Assert.AreEqual(MoveType.Kill, queen.CanMove(game, 4, 1));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 4, 0));
        }

        [TestMethod]
        public void CanMove_LeftCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[4, 1] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 2));
            Assert.AreEqual(MoveType.Check, queen.CanMove(game, 4, 1));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 4, 0));
        }

        [TestMethod]
        public void CanMove_RightMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[4, 6] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Protect, queen.CanMove(game, 4, 6));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 4, 7));
        }

        [TestMethod]
        public void CanMove_RightKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[4, 6] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Kill, queen.CanMove(game, 4, 6));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 4, 7));
        }

        [TestMethod]
        public void CanMove_RightCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[4, 6] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Check, queen.CanMove(game, 4, 6));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 4, 7));
        }

        [TestMethod]
        public void CanMove_UpMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[1, 4] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 3, 4));
            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 2, 4));
            Assert.AreEqual(MoveType.Protect, queen.CanMove(game, 1, 4));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 0, 4));
        }

        [TestMethod]
        public void CanMove_UpKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[1, 4] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 3, 4));
            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 2, 4));
            Assert.AreEqual(MoveType.Kill, queen.CanMove(game, 1, 4));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 0, 4));
        }

        [TestMethod]
        public void CanMove_UpCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[1, 4] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 3, 4));
            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 2, 4));
            Assert.AreEqual(MoveType.Check, queen.CanMove(game, 1, 4));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 0, 4));
        }

        [TestMethod]
        public void CanMove_DownMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[6, 4] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 5, 4));
            Assert.AreEqual(MoveType.Protect, queen.CanMove(game, 6, 4));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 7, 4));
        }

        [TestMethod]
        public void CanMove_DownKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[6, 4] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 5, 4));
            Assert.AreEqual(MoveType.Kill, queen.CanMove(game, 6, 4));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 7, 4));
        }

        [TestMethod]
        public void CanMove_DownCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[6, 4] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 5, 4));
            Assert.AreEqual(MoveType.Check, queen.CanMove(game, 6, 4));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 7, 4));
        }

        [TestMethod]
        public void CanMove_UpLeftMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[1, 2] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 2, 3));
            Assert.AreEqual(MoveType.Protect, queen.CanMove(game, 1, 2));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 0, 1));
        }

        [TestMethod]
        public void CanMove_UpLeftKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[1, 2] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 2, 3));
            Assert.AreEqual(MoveType.Kill, queen.CanMove(game, 1, 2));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 0, 1));
        }

        [TestMethod]
        public void CanMove_UpLeftCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[1, 2] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 2, 3));
            Assert.AreEqual(MoveType.Check, queen.CanMove(game, 1, 2));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 0, 1));
        }

        [TestMethod]
        public void CanMove_UpRightMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[1, 6] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 2, 5));
            Assert.AreEqual(MoveType.Protect, queen.CanMove(game, 1, 6));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 0, 7));
        }

        [TestMethod]
        public void CanMove_UpRightKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[1, 6] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 2, 5));
            Assert.AreEqual(MoveType.Kill, queen.CanMove(game, 1, 6));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 0, 7));
        }

        [TestMethod]
        public void CanMove_UpRightCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[1, 6] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 2, 5));
            Assert.AreEqual(MoveType.Check, queen.CanMove(game, 1, 6));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 0, 7));
        }

        [TestMethod]
        public void CanMove_DownLeftMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[6, 1] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 5, 2));
            Assert.AreEqual(MoveType.Protect, queen.CanMove(game, 6, 1));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 7, 0));
        }

        [TestMethod]
        public void CanMove_DownLeftKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[6, 1] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 5, 2));
            Assert.AreEqual(MoveType.Kill, queen.CanMove(game, 6, 1));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 7, 0));
        }

        [TestMethod]
        public void CanMove_DownLeftCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[6, 1] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 5, 2));
            Assert.AreEqual(MoveType.Check, queen.CanMove(game, 6, 1));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 7, 0));
        }

        [TestMethod]
        public void CanMove_DownRightMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[5, 6] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Protect, queen.CanMove(game, 5, 6));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 6, 7));
        }

        [TestMethod]
        public void CanMove_DownRightKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[5, 6] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Kill, queen.CanMove(game, 5, 6));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 6, 7));
        }

        [TestMethod]
        public void CanMove_DownRightCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[5, 6] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, queen.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Check, queen.CanMove(game, 5, 6));
            Assert.AreEqual(MoveType.None, queen.CanMove(game, 6, 7));
        }

        [TestMethod]
        public void GetAvailableMoves_LeftMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[4, 1] = new Pawn(Players.PlayerOne);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[4][2]);
            Assert.AreEqual(MoveType.Protect, moves[4][1]);
            Assert.AreEqual(MoveType.None, moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_LeftKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[4, 1] = new Pawn(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[4][2]);
            Assert.AreEqual(MoveType.Kill, moves[4][1]);
            Assert.AreEqual(MoveType.None, moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_LeftCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[4, 1] = new King(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[4][2]);
            Assert.AreEqual(MoveType.Check, moves[4][1]);
            Assert.AreEqual(MoveType.None, moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[4, 6] = new Pawn(Players.PlayerOne);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Protect, moves[4][6]);
            Assert.AreEqual(MoveType.None, moves[4][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[4, 6] = new Pawn(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Kill, moves[4][6]);
            Assert.AreEqual(MoveType.None, moves[4][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[4, 6] = new King(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Check, moves[4][6]);
            Assert.AreEqual(MoveType.None, moves[4][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[1, 4] = new Pawn(Players.PlayerOne);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[3][4]);
            Assert.AreEqual(MoveType.Move, moves[2][4]);
            Assert.AreEqual(MoveType.Protect, moves[1][4]);
            Assert.AreEqual(MoveType.None, moves[0][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[1, 4] = new Pawn(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[3][4]);
            Assert.AreEqual(MoveType.Move, moves[2][4]);
            Assert.AreEqual(MoveType.Kill, moves[1][4]);
            Assert.AreEqual(MoveType.None, moves[0][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[1, 4] = new King(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[3][4]);
            Assert.AreEqual(MoveType.Move, moves[2][4]);
            Assert.AreEqual(MoveType.Check, moves[1][4]);
            Assert.AreEqual(MoveType.None, moves[0][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[6, 4] = new Pawn(Players.PlayerOne);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Protect, moves[6][4]);
            Assert.AreEqual(MoveType.None, moves[7][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[6, 4] = new Pawn(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Kill, moves[6][4]);
            Assert.AreEqual(MoveType.None, moves[7][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = queen;
            game.GameBoard[6, 4] = new King(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Check, moves[6][4]);
            Assert.AreEqual(MoveType.None, moves[7][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpLeftMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[1, 2] = new Pawn(Players.PlayerOne);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][3]);
            Assert.AreEqual(MoveType.Protect, moves[1][2]);
            Assert.AreEqual(MoveType.None, moves[0][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpLeftKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[1, 2] = new Pawn(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][3]);
            Assert.AreEqual(MoveType.Kill, moves[1][2]);
            Assert.AreEqual(MoveType.None, moves[0][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpLeftCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[1, 2] = new King(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][3]);
            Assert.AreEqual(MoveType.Check, moves[1][2]);
            Assert.AreEqual(MoveType.None, moves[0][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpRightMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[1, 6] = new Pawn(Players.PlayerOne);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][5]);
            Assert.AreEqual(MoveType.Protect, moves[1][6]);
            Assert.AreEqual(MoveType.None, moves[0][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpRightKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[1, 6] = new Pawn(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][5]);
            Assert.AreEqual(MoveType.Kill, moves[1][6]);
            Assert.AreEqual(MoveType.None, moves[0][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpRightCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[1, 6] = new King(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][5]);
            Assert.AreEqual(MoveType.Check, moves[1][6]);
            Assert.AreEqual(MoveType.None, moves[0][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownLeftMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[6, 1] = new Pawn(Players.PlayerOne);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[5][2]);
            Assert.AreEqual(MoveType.Protect, moves[6][1]);
            Assert.AreEqual(MoveType.None, moves[7][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownLeftKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[6, 1] = new Pawn(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[5][2]);
            Assert.AreEqual(MoveType.Kill, moves[6][1]);
            Assert.AreEqual(MoveType.None, moves[7][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownLeftCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[6, 1] = new King(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[5][2]);
            Assert.AreEqual(MoveType.Check, moves[6][1]);
            Assert.AreEqual(MoveType.None, moves[7][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownRightMove()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[5, 6] = new Pawn(Players.PlayerOne);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Protect, moves[5][6]);
            Assert.AreEqual(MoveType.None, moves[6][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownRightKill()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[5, 6] = new Pawn(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Kill, moves[5][6]);
            Assert.AreEqual(MoveType.None, moves[6][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownRightCheck()
        {
            var queen = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = queen;
            game.GameBoard[5, 6] = new King(Players.PlayerTwo);

            var moves = queen.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Check, moves[5][6]);
            Assert.AreEqual(MoveType.None, moves[6][7]);
        }

    }

}

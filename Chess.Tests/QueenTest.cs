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
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 1] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 4, 2));
            Assert.AreEqual(MoveType.Protect, rook.CanMove(game, 4, 1));
            Assert.AreEqual(MoveType.None, rook.CanMove(game, 4, 0));
        }

        [TestMethod]
        public void CanMove_LeftKill()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 1] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 4, 2));
            Assert.AreEqual(MoveType.Kill, rook.CanMove(game, 4, 1));
            Assert.AreEqual(MoveType.None, rook.CanMove(game, 4, 0));
        }

        [TestMethod]
        public void CanMove_LeftCheck()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 1] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 4, 2));
            Assert.AreEqual(MoveType.Check, rook.CanMove(game, 4, 1));
            Assert.AreEqual(MoveType.None, rook.CanMove(game, 4, 0));
        }

        [TestMethod]
        public void CanMove_RightMove()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 6] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Protect, rook.CanMove(game, 4, 6));
            Assert.AreEqual(MoveType.None, rook.CanMove(game, 4, 7));
        }

        [TestMethod]
        public void CanMove_RightKill()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 6] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Kill, rook.CanMove(game, 4, 6));
            Assert.AreEqual(MoveType.None, rook.CanMove(game, 4, 7));
        }

        [TestMethod]
        public void CanMove_RightCheck()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 6] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Check, rook.CanMove(game, 4, 6));
            Assert.AreEqual(MoveType.None, rook.CanMove(game, 4, 7));
        }

        [TestMethod]
        public void CanMove_UpMove()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[1, 4] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 3, 4));
            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 2, 4));
            Assert.AreEqual(MoveType.Protect, rook.CanMove(game, 1, 4));
            Assert.AreEqual(MoveType.None, rook.CanMove(game, 0, 4));
        }

        [TestMethod]
        public void CanMove_UpKill()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[1, 4] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 3, 4));
            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 2, 4));
            Assert.AreEqual(MoveType.Kill, rook.CanMove(game, 1, 4));
            Assert.AreEqual(MoveType.None, rook.CanMove(game, 0, 4));
        }

        [TestMethod]
        public void CanMove_UpCheck()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[1, 4] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 3, 4));
            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 2, 4));
            Assert.AreEqual(MoveType.Check, rook.CanMove(game, 1, 4));
            Assert.AreEqual(MoveType.None, rook.CanMove(game, 0, 4));
        }

        [TestMethod]
        public void CanMove_DownMove()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[6, 4] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 5, 4));
            Assert.AreEqual(MoveType.Protect, rook.CanMove(game, 6, 4));
            Assert.AreEqual(MoveType.None, rook.CanMove(game, 7, 4));
        }

        [TestMethod]
        public void CanMove_DownKill()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[6, 4] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 5, 4));
            Assert.AreEqual(MoveType.Kill, rook.CanMove(game, 6, 4));
            Assert.AreEqual(MoveType.None, rook.CanMove(game, 7, 4));
        }

        [TestMethod]
        public void CanMove_DownCheck()
        {
            var rook = new Rook(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[6, 4] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, rook.CanMove(game, 5, 4));
            Assert.AreEqual(MoveType.Check, rook.CanMove(game, 6, 4));
            Assert.AreEqual(MoveType.None, rook.CanMove(game, 7, 4));
        }

        [TestMethod]
        public void CanMove_UpLeftMove()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 2] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 2, 3));
            Assert.AreEqual(MoveType.Protect, bishop.CanMove(game, 1, 2));
            Assert.AreEqual(MoveType.None, bishop.CanMove(game, 0, 1));
        }

        [TestMethod]
        public void CanMove_UpLeftKill()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 2] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 2, 3));
            Assert.AreEqual(MoveType.Kill, bishop.CanMove(game, 1, 2));
            Assert.AreEqual(MoveType.None, bishop.CanMove(game, 0, 1));
        }

        [TestMethod]
        public void CanMove_UpLeftCheck()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 2] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 2, 3));
            Assert.AreEqual(MoveType.Check, bishop.CanMove(game, 1, 2));
            Assert.AreEqual(MoveType.None, bishop.CanMove(game, 0, 1));
        }

        [TestMethod]
        public void CanMove_UpRightMove()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 6] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 2, 5));
            Assert.AreEqual(MoveType.Protect, bishop.CanMove(game, 1, 6));
            Assert.AreEqual(MoveType.None, bishop.CanMove(game, 0, 7));
        }

        [TestMethod]
        public void CanMove_UpRightKill()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 6] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 2, 5));
            Assert.AreEqual(MoveType.Kill, bishop.CanMove(game, 1, 6));
            Assert.AreEqual(MoveType.None, bishop.CanMove(game, 0, 7));
        }

        [TestMethod]
        public void CanMove_UpRightCheck()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 6] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 2, 5));
            Assert.AreEqual(MoveType.Check, bishop.CanMove(game, 1, 6));
            Assert.AreEqual(MoveType.None, bishop.CanMove(game, 0, 7));
        }

        [TestMethod]
        public void CanMove_DownLeftMove()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[6, 1] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 5, 2));
            Assert.AreEqual(MoveType.Protect, bishop.CanMove(game, 6, 1));
            Assert.AreEqual(MoveType.None, bishop.CanMove(game, 7, 0));
        }

        [TestMethod]
        public void CanMove_DownLeftKill()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[6, 1] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 5, 2));
            Assert.AreEqual(MoveType.Kill, bishop.CanMove(game, 6, 1));
            Assert.AreEqual(MoveType.None, bishop.CanMove(game, 7, 0));
        }

        [TestMethod]
        public void CanMove_DownLeftCheck()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[6, 1] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 5, 2));
            Assert.AreEqual(MoveType.Check, bishop.CanMove(game, 6, 1));
            Assert.AreEqual(MoveType.None, bishop.CanMove(game, 7, 0));
        }

        [TestMethod]
        public void CanMove_DownRightMove()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[5, 6] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Protect, bishop.CanMove(game, 5, 6));
            Assert.AreEqual(MoveType.None, bishop.CanMove(game, 6, 7));
        }

        [TestMethod]
        public void CanMove_DownRightKill()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[5, 6] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Kill, bishop.CanMove(game, 5, 6));
            Assert.AreEqual(MoveType.None, bishop.CanMove(game, 6, 7));
        }

        [TestMethod]
        public void CanMove_DownRightCheck()
        {
            var bishop = new Bishop(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[5, 6] = new King(Players.PlayerTwo);

            Assert.AreEqual(MoveType.Move, bishop.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Check, bishop.CanMove(game, 5, 6));
            Assert.AreEqual(MoveType.None, bishop.CanMove(game, 6, 7));
        }

        [TestMethod]
        public void GetAvailableMoves_LeftMove()
        {
            var rook = new Queen(Players.PlayerOne);
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
            var rook = new Queen(Players.PlayerOne);
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
            var rook = new Queen(Players.PlayerOne);
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
            var rook = new Queen(Players.PlayerOne);
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
            var rook = new Queen(Players.PlayerOne);
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
            var rook = new Queen(Players.PlayerOne);
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
            var rook = new Queen(Players.PlayerOne);
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
            var rook = new Queen(Players.PlayerOne);
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
            var rook = new Queen(Players.PlayerOne);
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
            var rook = new Queen(Players.PlayerOne);
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
            var rook = new Queen(Players.PlayerOne);
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
            var rook = new Queen(Players.PlayerOne);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[6, 4] = new King(Players.PlayerTwo);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Check, moves[6][4]);
            Assert.AreEqual(MoveType.None, moves[7][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpLeftMove()
        {
            var bishop = new Queen(Players.PlayerOne);
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
            var bishop = new Queen(Players.PlayerOne);
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
            var bishop = new Queen(Players.PlayerOne);
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
            var bishop = new Queen(Players.PlayerOne);
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
            var bishop = new Queen(Players.PlayerOne);
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
            var bishop = new Queen(Players.PlayerOne);
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
            var bishop = new Queen(Players.PlayerOne);
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
            var bishop = new Queen(Players.PlayerOne);
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
            var bishop = new Queen(Players.PlayerOne);
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
            var bishop = new Queen(Players.PlayerOne);
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
            var bishop = new Queen(Players.PlayerOne);
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
            var bishop = new Queen(Players.PlayerOne);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[5, 6] = new King(Players.PlayerTwo);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Check, moves[5][6]);
            Assert.AreEqual(MoveType.None, moves[6][7]);
        }

    }

}

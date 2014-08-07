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
        public void GetAvailableMoves_LeftMove()
        {
            var rook = new Queen(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 1] = new Pawn(PieceColor.White);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[4][2]);
            Assert.AreEqual(MoveType.Protect, moves[4][1]);
            Assert.AreEqual(MoveType.None, moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_LeftKill()
        {
            var rook = new Queen(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 1] = new Pawn(PieceColor.Black);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[4][2]);
            Assert.AreEqual(MoveType.Kill, moves[4][1]);
            Assert.AreEqual(MoveType.None, moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightMove()
        {
            var rook = new Queen(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 6] = new Pawn(PieceColor.White);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Protect, moves[4][6]);
            Assert.AreEqual(MoveType.None, moves[4][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightKill()
        {
            var rook = new Queen(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[4, 6] = new Pawn(PieceColor.Black);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Kill, moves[4][6]);
            Assert.AreEqual(MoveType.None, moves[4][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpMove()
        {
            var rook = new Queen(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[1, 4] = new Pawn(PieceColor.White);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[3][4]);
            Assert.AreEqual(MoveType.Move, moves[2][4]);
            Assert.AreEqual(MoveType.Protect, moves[1][4]);
            Assert.AreEqual(MoveType.None, moves[0][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpKill()
        {
            var rook = new Queen(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[1, 4] = new Pawn(PieceColor.Black);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[3][4]);
            Assert.AreEqual(MoveType.Move, moves[2][4]);
            Assert.AreEqual(MoveType.Kill, moves[1][4]);
            Assert.AreEqual(MoveType.None, moves[0][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownMove()
        {
            var rook = new Queen(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[6, 4] = new Pawn(PieceColor.White);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Protect, moves[6][4]);
            Assert.AreEqual(MoveType.None, moves[7][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownKill()
        {
            var rook = new Queen(PieceColor.White);
            game.GameBoard[4, 4] = rook;
            game.GameBoard[6, 4] = new Pawn(PieceColor.Black);

            var moves = rook.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Kill, moves[6][4]);
            Assert.AreEqual(MoveType.None, moves[7][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpLeftMove()
        {
            var bishop = new Queen(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 2] = new Pawn(PieceColor.White);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][3]);
            Assert.AreEqual(MoveType.Protect, moves[1][2]);
            Assert.AreEqual(MoveType.None, moves[0][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpLeftKill()
        {
            var bishop = new Queen(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 2] = new Pawn(PieceColor.Black);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][3]);
            Assert.AreEqual(MoveType.Kill, moves[1][2]);
            Assert.AreEqual(MoveType.None, moves[0][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpRightMove()
        {
            var bishop = new Queen(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 6] = new Pawn(PieceColor.White);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][5]);
            Assert.AreEqual(MoveType.Protect, moves[1][6]);
            Assert.AreEqual(MoveType.None, moves[0][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_UpRightKill()
        {
            var bishop = new Queen(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[1, 6] = new Pawn(PieceColor.Black);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[2][5]);
            Assert.AreEqual(MoveType.Kill, moves[1][6]);
            Assert.AreEqual(MoveType.None, moves[0][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownLeftMove()
        {
            var bishop = new Queen(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[6, 1] = new Pawn(PieceColor.White);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[5][2]);
            Assert.AreEqual(MoveType.Protect, moves[6][1]);
            Assert.AreEqual(MoveType.None, moves[7][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownLeftKill()
        {
            var bishop = new Queen(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[6, 1] = new Pawn(PieceColor.Black);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[5][2]);
            Assert.AreEqual(MoveType.Kill, moves[6][1]);
            Assert.AreEqual(MoveType.None, moves[7][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownRightMove()
        {
            var bishop = new Queen(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[5, 6] = new Pawn(PieceColor.White);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Protect, moves[5][6]);
            Assert.AreEqual(MoveType.None, moves[6][7]);
        }

        [TestMethod]
        public void GetAvailableMoves_DownRightKill()
        {
            var bishop = new Queen(PieceColor.White);
            game.GameBoard[3, 4] = bishop;
            game.GameBoard[5, 6] = new Pawn(PieceColor.Black);

            var moves = bishop.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Kill, moves[5][6]);
            Assert.AreEqual(MoveType.None, moves[6][7]);
        }

    }

}

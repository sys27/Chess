using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Library;
using Chess.Library.Pieces;

namespace Chess.Tests
{

    [TestClass]
    public class KingTest
    {

        private Game game;

        [TestInitialize]
        public void TestInitialize()
        {
            game = new Game(Board.CreateEmpty());
        }

        [TestMethod]
        public void GetAvailableMoves_AllMove()
        {
            var king = new King(PieceColor.White);
            game.GameBoard[4, 4] = king;

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[3][4]);
            Assert.AreEqual(MoveType.Move, moves[3][3]);
            Assert.AreEqual(MoveType.Move, moves[3][5]);
            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Move, moves[5][3]);
            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Move, moves[5][5]);
        }

        [TestMethod]
        public void GetAvailableMoves_Protect()
        {
            var king = new King(PieceColor.White);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 4] = new Pawn(PieceColor.White);

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Protect, moves[3][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_MoveToCheck()
        {
            var king = new King(PieceColor.White);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 0] = new Rook(PieceColor.Black);

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.None, moves[3][4]);
            Assert.AreEqual(MoveType.None, moves[3][3]);
            Assert.AreEqual(MoveType.None, moves[3][5]);
            Assert.AreEqual(MoveType.Move, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.Move, moves[5][3]);
            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Move, moves[5][5]);
        }

        [TestMethod]
        public void GetAvailableMoves_KillToCheck()
        {
            var king = new King(PieceColor.White);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 0] = new Rook(PieceColor.Black);
            game.GameBoard[3, 4] = new Pawn(PieceColor.Black);

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.None, moves[3][4]);
            Assert.AreEqual(MoveType.None, moves[3][3]);
            Assert.AreEqual(MoveType.Move, moves[3][5]);
            Assert.AreEqual(MoveType.None, moves[4][3]);
            Assert.AreEqual(MoveType.None, moves[4][5]);
            Assert.AreEqual(MoveType.Move, moves[5][3]);
            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Move, moves[5][5]);
        }

        [TestMethod]
        public void GetAvailableMoves_Kill()
        {
            var king = new King(PieceColor.White);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 3] = new Rook(PieceColor.Black);

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.None, moves[3][4]);
            Assert.AreEqual(MoveType.Kill, moves[3][3]);
            Assert.AreEqual(MoveType.None, moves[3][5]);
            Assert.AreEqual(MoveType.None, moves[4][3]);
            Assert.AreEqual(MoveType.Move, moves[4][5]);
            Assert.AreEqual(MoveType.None, moves[5][3]);
            Assert.AreEqual(MoveType.Move, moves[5][4]);
            Assert.AreEqual(MoveType.Move, moves[5][5]);
        }

        [TestMethod]
        public void GetAvailableMoves_NoMoves()
        {
            var king = new King(PieceColor.White);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 3] = new Rook(PieceColor.Black);
            game.GameBoard[3, 5] = new Rook(PieceColor.Black);
            game.GameBoard[5, 3] = new Rook(PieceColor.Black);
            game.GameBoard[5, 5] = new Rook(PieceColor.Black);

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.None, moves[3][4]);
            Assert.AreEqual(MoveType.None, moves[3][3]);
            Assert.AreEqual(MoveType.None, moves[3][5]);
            Assert.AreEqual(MoveType.None, moves[4][3]);
            Assert.AreEqual(MoveType.None, moves[4][5]);
            Assert.AreEqual(MoveType.None, moves[5][3]);
            Assert.AreEqual(MoveType.None, moves[5][4]);
            Assert.AreEqual(MoveType.None, moves[5][5]);
        }

    }

}

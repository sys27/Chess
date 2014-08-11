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

    }

}

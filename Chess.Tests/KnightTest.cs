using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Library;
using Chess.Library.Pieces;

namespace Chess.Tests
{

    [TestClass]
    public class KnightTest
    {

        private Game game;

        [TestInitialize]
        public void TestInitialize()
        {
            game = new Game(Board.CreateEmpty());
        }

        [TestMethod]
        public void GetAvailableMoves_All()
        {
            var knight = new Knight(PieceColor.White);
            game.GameBoard[4, 4] = knight;

            var moves = knight.GetAvailableMoves(game);

            Assert.IsTrue(moves[6][3]);
            Assert.IsTrue(moves[6][5]);

            Assert.IsTrue(moves[5][2]);
            Assert.IsTrue(moves[5][6]);

            Assert.IsTrue(moves[3][2]);
            Assert.IsTrue(moves[3][6]);

            Assert.IsTrue(moves[2][3]);
            Assert.IsTrue(moves[2][5]);
        }

        [TestMethod]
        public void GetAvailableMoves()
        {
            var knight = new Knight(PieceColor.White);
            game.GameBoard[4, 4] = knight;
            game.GameBoard[6, 3] = new Pawn(PieceColor.White);

            var moves = knight.GetAvailableMoves(game);

            Assert.IsFalse(moves[6][3]);
            Assert.IsTrue(moves[6][5]);

            Assert.IsTrue(moves[5][2]);
            Assert.IsTrue(moves[5][6]);

            Assert.IsTrue(moves[3][2]);
            Assert.IsTrue(moves[3][6]);

            Assert.IsTrue(moves[2][3]);
            Assert.IsTrue(moves[2][5]);
        }

        [TestMethod]
        public void GetAvailableMoves_Kill()
        {
            var knight = new Knight(PieceColor.White);
            game.GameBoard[4, 4] = knight;
            game.GameBoard[6, 3] = new Pawn(PieceColor.Black);

            var moves = knight.GetAvailableMoves(game);

            Assert.IsTrue(moves[6][3]);
            Assert.IsTrue(moves[6][5]);

            Assert.IsTrue(moves[5][2]);
            Assert.IsTrue(moves[5][6]);

            Assert.IsTrue(moves[3][2]);
            Assert.IsTrue(moves[3][6]);

            Assert.IsTrue(moves[2][3]);
            Assert.IsTrue(moves[2][5]);
        }

    }

}

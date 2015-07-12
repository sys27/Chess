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
            var knight = new Knight(Players.PlayerOne);
            game.GameBoard[4, 4] = knight;

            var moves = knight.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Move, moves[6][3]);
            Assert.AreEqual(MoveType.Move, moves[6][5]);

            Assert.AreEqual(MoveType.Move, moves[5][2]);
            Assert.AreEqual(MoveType.Move, moves[5][6]);

            Assert.AreEqual(MoveType.Move, moves[3][2]);
            Assert.AreEqual(MoveType.Move, moves[3][6]);

            Assert.AreEqual(MoveType.Move, moves[2][3]);
            Assert.AreEqual(MoveType.Move, moves[2][5]);
        }

        [TestMethod]
        public void GetAvailableMoves()
        {
            var knight = new Knight(Players.PlayerOne);
            game.GameBoard[4, 4] = knight;
            game.GameBoard[6, 3] = new Pawn(Players.PlayerOne);

            var moves = knight.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Protect, moves[6][3]);
            Assert.AreEqual(MoveType.Move, moves[6][5]);

            Assert.AreEqual(MoveType.Move, moves[5][2]);
            Assert.AreEqual(MoveType.Move, moves[5][6]);

            Assert.AreEqual(MoveType.Move, moves[3][2]);
            Assert.AreEqual(MoveType.Move, moves[3][6]);

            Assert.AreEqual(MoveType.Move, moves[2][3]);
            Assert.AreEqual(MoveType.Move, moves[2][5]);
        }

        [TestMethod]
        public void GetAvailableMoves_Kill()
        {
            var knight = new Knight(Players.PlayerOne);
            game.GameBoard[4, 4] = knight;
            game.GameBoard[6, 3] = new Pawn(Players.PlayerTwo);

            var moves = knight.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Kill, moves[6][3]);
            Assert.AreEqual(MoveType.Move, moves[6][5]);

            Assert.AreEqual(MoveType.Move, moves[5][2]);
            Assert.AreEqual(MoveType.Move, moves[5][6]);

            Assert.AreEqual(MoveType.Move, moves[3][2]);
            Assert.AreEqual(MoveType.Move, moves[3][6]);

            Assert.AreEqual(MoveType.Move, moves[2][3]);
            Assert.AreEqual(MoveType.Move, moves[2][5]);
        }

        [TestMethod]
        public void GetAvailableMoves_Check()
        {
            var knight = new Knight(Players.PlayerOne);
            game.GameBoard[4, 4] = knight;
            game.GameBoard[6, 3] = new King(Players.PlayerTwo);

            var moves = knight.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Check, moves[6][3]);
            Assert.AreEqual(MoveType.Move, moves[6][5]);

            Assert.AreEqual(MoveType.Move, moves[5][2]);
            Assert.AreEqual(MoveType.Move, moves[5][6]);

            Assert.AreEqual(MoveType.Move, moves[3][2]);
            Assert.AreEqual(MoveType.Move, moves[3][6]);

            Assert.AreEqual(MoveType.Move, moves[2][3]);
            Assert.AreEqual(MoveType.Move, moves[2][5]);
        }

    }

}

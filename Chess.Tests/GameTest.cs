﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Library;
using System.Linq;
using Chess.Library.Pieces;

namespace Chess.Tests
{

    [TestClass]
    public class GameTest
    {

        private Game game;

        [TestInitialize]
        public void TestInitialize()
        {
            game = new Game();
        }

        [TestMethod]
        public void TurnTest()
        {
            var whitePawn = game.GameBoard[6, 0];
            game.Turn(6, 0, 4, 0);

            Assert.IsNull(game.GameBoard[6, 0]);
            Assert.AreEqual(whitePawn, game.GameBoard[4, 0]);

            var blackPawn = game.GameBoard[1, 0];
            game.Turn(1, 0, 3, 0);

            Assert.IsNull(game.GameBoard[1, 0]);
            Assert.AreEqual(blackPawn, game.GameBoard[3, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(GameTurnException))]
        public void WrongPlayerTurn()
        {
            var whitePawn = game.GameBoard[6, 0];
            game.Turn(6, 0, 4, 0);

            Assert.IsNull(game.GameBoard[6, 0]);
            Assert.AreEqual(whitePawn, game.GameBoard[4, 0]);

            var whiteKnight = game.GameBoard[7, 1];
            game.Turn(7, 1, 5, 2);
        }

        [TestMethod]
        public void KillTest()
        {
            var whitePawn = game.GameBoard[6, 4];
            game.Turn(6, 4, 4, 4);

            Assert.IsNull(game.GameBoard[6, 4]);
            Assert.AreEqual(whitePawn, game.GameBoard[4, 4]);

            var blackPawn = game.GameBoard[1, 3];
            game.Turn(1, 3, 3, 3);

            Assert.IsNull(game.GameBoard[1, 3]);
            Assert.AreEqual(blackPawn, game.GameBoard[3, 3]);

            game.Turn(4, 4, 3, 3);
            Assert.IsNull(game.GameBoard[4, 4]);
            Assert.AreEqual(whitePawn, game.GameBoard[3, 3]);
        }

        [TestMethod]
        public void MoveUndo()
        {
            var whitePawn = game.GameBoard[6, 0];
            game.Turn(6, 0, 4, 0);

            Assert.IsNull(game.GameBoard[6, 0]);
            Assert.AreEqual(whitePawn, game.GameBoard[4, 0]);

            var blackPawn = game.GameBoard[1, 0];
            game.Turn(1, 0, 3, 0);

            Assert.IsNull(game.GameBoard[1, 0]);
            Assert.AreEqual(blackPawn, game.GameBoard[3, 0]);

            game.Undo();

            Assert.AreEqual(0, game.Moves.Count());
            Assert.AreEqual(whitePawn, game.GameBoard[6, 0]);
            Assert.AreEqual(blackPawn, game.GameBoard[1, 0]);
        }

        [TestMethod]
        public void KillUndo()
        {
            var whitePawn = game.GameBoard[6, 4];
            game.Turn(6, 4, 4, 4);

            Assert.IsNull(game.GameBoard[6, 4]);
            Assert.AreEqual(whitePawn, game.GameBoard[4, 4]);

            var blackPawn = game.GameBoard[1, 3];
            game.Turn(1, 3, 3, 3);

            Assert.IsNull(game.GameBoard[1, 3]);
            Assert.AreEqual(blackPawn, game.GameBoard[3, 3]);

            game.Turn(4, 4, 3, 3);
            Assert.IsNull(game.GameBoard[4, 4]);
            Assert.AreEqual(whitePawn, game.GameBoard[3, 3]);

            game.Undo();

            Assert.AreEqual(1, game.Moves.Count());
            Assert.IsNull(game.GameBoard[6, 4]);
            Assert.AreEqual(whitePawn, game.GameBoard[4, 4]);
            Assert.AreEqual(blackPawn, game.GameBoard[1, 3]);
        }

        [TestMethod]
        public void CheckPlayerOneTest()
        {
            var board = new Board(true);
            board[4, 4] = new King(Players.PlayerOne);
            board[5, 1] = new Rook(Players.PlayerTwo);

            var game = new Game(board);
            game.Turn(4, 4, 4, 5);
            game.Turn(5, 1, 4, 1);

            Assert.IsTrue(game.GetCheck(Players.PlayerOne));
        }

        [TestMethod]
        public void CheckPlayerTwoTest()
        {
            var board = new Board(true);
            board[4, 4] = new King(Players.PlayerTwo);
            board[5, 1] = new Rook(Players.PlayerOne);

            var game = new Game(board);
            game.Turn(5, 1, 4, 1);

            Assert.IsTrue(game.GetCheck(Players.PlayerTwo));
        }

    }

}

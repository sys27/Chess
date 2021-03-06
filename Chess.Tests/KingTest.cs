﻿using System;
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
        public void CanMove_AllMove()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[4, 4] = king;

            Assert.AreEqual(MoveType.Move, king.CanMove(game, 3, 4));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 3, 3));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 3, 5));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 5, 3));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 5, 4));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 5, 5));
        }

        [TestMethod]
        public void CanMove_Protect()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 4] = new Pawn(Players.PlayerOne);

            Assert.AreEqual(MoveType.Protect, king.CanMove(game, 3, 4));
        }

        [TestMethod]
        public void CanMove_MoveToCheck()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 0] = new Rook(Players.PlayerTwo);

            Assert.AreEqual(MoveType.None, king.CanMove(game, 3, 4));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 3, 3));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 3, 5));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 5, 3));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 5, 4));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 5, 5));
        }

        [TestMethod]
        public void CanMove_KillToCheck()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 0] = new Rook(Players.PlayerTwo);
            game.GameBoard[3, 4] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.None, king.CanMove(game, 3, 4));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 3, 3));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 3, 5));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 5, 3));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 5, 4));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 5, 5));
        }

        [TestMethod]
        public void CanMove_Kill()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 3] = new Rook(Players.PlayerTwo);

            Assert.AreEqual(MoveType.None, king.CanMove(game, 3, 4));
            Assert.AreEqual(MoveType.Kill, king.CanMove(game, 3, 3));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 3, 5));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 5, 3));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 5, 4));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 5, 5));
        }

        [TestMethod]
        public void CanMove_NoMoves()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 3] = new Rook(Players.PlayerTwo);
            game.GameBoard[3, 5] = new Rook(Players.PlayerTwo);
            game.GameBoard[5, 3] = new Rook(Players.PlayerTwo);
            game.GameBoard[5, 5] = new Rook(Players.PlayerTwo);

            Assert.AreEqual(MoveType.None, king.CanMove(game, 3, 4));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 3, 3));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 3, 5));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 4, 3));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 4, 5));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 5, 3));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 5, 4));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 5, 5));
        }

        [TestMethod]
        public void CanMove_LeftCastling()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[7, 4] = king;
            game.GameBoard[7, 0] = new Rook(Players.PlayerOne);

            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 4));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 7, 3));
            Assert.AreEqual(MoveType.Castling, king.CanMove(game, 7, 2));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 1));
        }

        [TestMethod]
        public void CanMove_RightCastling()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[7, 4] = king;
            game.GameBoard[7, 7] = new Rook(Players.PlayerOne);

            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 4));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 7, 5));
            Assert.AreEqual(MoveType.Castling, king.CanMove(game, 7, 6));
        }

        [TestMethod]
        public void CanMove_NoLeftCastling_Blocking()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[7, 4] = king;
            game.GameBoard[7, 0] = new Rook(Players.PlayerOne);
            game.GameBoard[7, 1] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 4));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 7, 3));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 2));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 1));
        }

        [TestMethod]
        public void CanMove_NoRightCastling_Blocking()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[7, 4] = king;
            game.GameBoard[7, 7] = new Rook(Players.PlayerOne);
            game.GameBoard[7, 6] = new Pawn(Players.PlayerTwo);

            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 4));
            Assert.AreEqual(MoveType.Move, king.CanMove(game, 7, 5));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 6));
        }

        [TestMethod]
        public void CanMove_NoLeftCastling_Underattack()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[7, 4] = king;
            game.GameBoard[7, 0] = new Rook(Players.PlayerOne);
            game.GameBoard[0, 3] = new Rook(Players.PlayerTwo);

            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 4));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 3));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 2));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 1));
        }

        [TestMethod]
        public void CanMove_NoRightCastling_Underattack()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[7, 4] = king;
            game.GameBoard[7, 7] = new Rook(Players.PlayerOne);
            game.GameBoard[0, 5] = new Rook(Players.PlayerTwo);

            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 4));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 5));
            Assert.AreEqual(MoveType.None, king.CanMove(game, 7, 6));
        }

        [TestMethod]
        public void CanMove_TwoKingAttack()
        {
            var whiteKing = new King(Players.PlayerOne);
            var blackKing = new King(Players.PlayerTwo);

            game.GameBoard[4, 4] = whiteKing;
            game.GameBoard[6, 4] = blackKing;

            Assert.AreEqual(MoveType.None, whiteKing.CanMove(game, 5, 4));
        }

        [TestMethod]
        public void GetAvailableMoves_AllMove()
        {
            var king = new King(Players.PlayerOne);
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
            var king = new King(Players.PlayerOne);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 4] = new Pawn(Players.PlayerOne);

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.Protect, moves[3][4]);
        }

        [TestMethod]
        public void GetAvailableMoves_MoveToCheck()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 0] = new Rook(Players.PlayerTwo);

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
            var king = new King(Players.PlayerOne);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 0] = new Rook(Players.PlayerTwo);
            game.GameBoard[3, 4] = new Pawn(Players.PlayerTwo);

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
            var king = new King(Players.PlayerOne);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 3] = new Rook(Players.PlayerTwo);

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
            var king = new King(Players.PlayerOne);
            game.GameBoard[4, 4] = king;
            game.GameBoard[3, 3] = new Rook(Players.PlayerTwo);
            game.GameBoard[3, 5] = new Rook(Players.PlayerTwo);
            game.GameBoard[5, 3] = new Rook(Players.PlayerTwo);
            game.GameBoard[5, 5] = new Rook(Players.PlayerTwo);

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

        [TestMethod]
        public void GetAvailableMoves_LeftCastling()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[7, 4] = king;
            game.GameBoard[7, 0] = new Rook(Players.PlayerOne);

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.None, moves[7][4]);
            Assert.AreEqual(MoveType.Move, moves[7][3]);
            Assert.AreEqual(MoveType.Castling, moves[7][2]);
            Assert.AreEqual(MoveType.None, moves[7][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_RightCastling()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[7, 4] = king;
            game.GameBoard[7, 7] = new Rook(Players.PlayerOne);

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.None, moves[7][4]);
            Assert.AreEqual(MoveType.Move, moves[7][5]);
            Assert.AreEqual(MoveType.Castling, moves[7][6]);
        }

        [TestMethod]
        public void GetAvailableMoves_NoLeftCastling_Blocking()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[7, 4] = king;
            game.GameBoard[7, 0] = new Rook(Players.PlayerOne);
            game.GameBoard[7, 1] = new Pawn(Players.PlayerTwo);

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.None, moves[7][4]);
            Assert.AreEqual(MoveType.Move, moves[7][3]);
            Assert.AreEqual(MoveType.None, moves[7][2]);
            Assert.AreEqual(MoveType.None, moves[7][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_NoRightCastling_Blocking()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[7, 4] = king;
            game.GameBoard[7, 7] = new Rook(Players.PlayerOne);
            game.GameBoard[7, 6] = new Pawn(Players.PlayerTwo);

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.None, moves[7][4]);
            Assert.AreEqual(MoveType.Move, moves[7][5]);
            Assert.AreEqual(MoveType.None, moves[7][6]);
        }

        [TestMethod]
        public void GetAvailableMoves_NoLeftCastling_Underattack()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[7, 4] = king;
            game.GameBoard[7, 0] = new Rook(Players.PlayerOne);
            game.GameBoard[0, 3] = new Rook(Players.PlayerTwo);

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.None, moves[7][4]);
            Assert.AreEqual(MoveType.None, moves[7][3]);
            Assert.AreEqual(MoveType.None, moves[7][2]);
            Assert.AreEqual(MoveType.None, moves[7][1]);
        }

        [TestMethod]
        public void GetAvailableMoves_NoRightCastling_Underattack()
        {
            var king = new King(Players.PlayerOne);
            game.GameBoard[7, 4] = king;
            game.GameBoard[7, 7] = new Rook(Players.PlayerOne);
            game.GameBoard[0, 5] = new Rook(Players.PlayerTwo);

            var moves = king.GetAvailableMoves(game);

            Assert.AreEqual(MoveType.None, moves[7][4]);
            Assert.AreEqual(MoveType.None, moves[7][5]);
            Assert.AreEqual(MoveType.None, moves[7][6]);
        }

    }

}

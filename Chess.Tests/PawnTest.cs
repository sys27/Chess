﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Library;
using Chess.Library.Pieces;

namespace Chess.Tests
{

    [TestClass]
    public class PawnTest
    {

        private Board board;

        [TestInitialize]
        public void TestInitialize()
        {
            board = Board.CreateEmpty();
        }

        [TestMethod]
        public void GetAvailableMoves_BlackStartMove()
        {
            var pawn = new Pawn(PieceColor.Black);
            board[1, 0] = pawn;

            var moves = pawn.GetAvailableMoves(board);

            Assert.IsFalse(moves[1][0]);
            Assert.IsTrue(moves[2][0]);
            Assert.IsTrue(moves[3][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_BlackMove()
        {
            var pawn = new Pawn(PieceColor.Black) { IsMoved = true };
            board[4, 0] = pawn;

            var moves = pawn.GetAvailableMoves(board);

            Assert.IsFalse(moves[4][0]);
            Assert.IsTrue(moves[5][0]);
            Assert.IsFalse(moves[6][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_BlackKill()
        {
            var pawn = new Pawn(PieceColor.Black) { IsMoved = true };
            board[4, 4] = pawn;
            board[5, 3] = new Pawn(PieceColor.White) { IsMoved = true };
            board[5, 5] = new Pawn(PieceColor.White) { IsMoved = true };

            var moves = pawn.GetAvailableMoves(board);

            Assert.IsFalse(moves[4][4]);
            Assert.IsTrue(moves[5][4]);
            Assert.IsFalse(moves[6][4]);

            Assert.IsTrue(moves[5][3]);
            Assert.IsTrue(moves[5][5]);
        }

        [TestMethod]
        public void GetAvailableMoves_WhiteStartMove()
        {
            var pawn = new Pawn(PieceColor.White);
            board[6, 0] = pawn;

            var moves = pawn.GetAvailableMoves(board);

            Assert.IsFalse(moves[6][0]);
            Assert.IsTrue(moves[5][0]);
            Assert.IsTrue(moves[4][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_WhiteMove()
        {
            var pawn = new Pawn(PieceColor.White) { IsMoved = true };
            board[4, 0] = pawn;

            var moves = pawn.GetAvailableMoves(board);

            Assert.IsFalse(moves[4][0]);
            Assert.IsTrue(moves[3][0]);
            Assert.IsFalse(moves[2][0]);
        }

        [TestMethod]
        public void GetAvailableMoves_WhiteKill()
        {
            var pawn = new Pawn(PieceColor.White) { IsMoved = true };
            board[4, 4] = pawn;
            board[3, 3] = new Pawn(PieceColor.Black) { IsMoved = true };
            board[3, 5] = new Pawn(PieceColor.Black) { IsMoved = true };

            var moves = pawn.GetAvailableMoves(board);

            Assert.IsFalse(moves[4][4]);
            Assert.IsTrue(moves[3][4]);
            Assert.IsFalse(moves[2][4]);

            Assert.IsTrue(moves[3][3]);
            Assert.IsTrue(moves[3][5]);
        }

    }

}
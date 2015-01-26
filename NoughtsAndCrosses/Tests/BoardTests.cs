using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoughtsAndCrosses.Classes;
using NoughtsAndCrosses.Exceptions;
using NUnit.Framework;

namespace NoughtsAndCrosses.Tests
{
	[TestFixture]
	class BoardTests
	{
		[Test]
		public void When_BoardIsCreated_Then_ShouldBe9MovesLeft()
		{
			Board board = new Board();
			Assert.AreEqual(9, board.CountEmptyCells());
		}

		[Test]
		public void When_OneSignatureIsPlaced_Then_BoardShouldHas8MovesLeft()
		{
			Board board = new Board();
			board.PlaceSignature(0,0,'X');
			Assert.AreEqual(8, board.CountEmptyCells());
		}

		[Test]
		public void When_9SingnaturesIsPlaces_Then_BoardShouldNotHaveMovesLeft()
		{
			Board board = new Board();
			board.PlaceSignature(0, 0, 'X');
			board.PlaceSignature(0, 1, 'X');
			board.PlaceSignature(0, 2, 'X');
			board.PlaceSignature(1, 0, 'X');
			board.PlaceSignature(1, 1, 'X');
			board.PlaceSignature(1, 2, 'X');
			board.PlaceSignature(2, 0, 'X');
			board.PlaceSignature(2, 1, 'X');
			board.PlaceSignature(2, 2, 'X');
			Assert.AreEqual(0, board.CountEmptyCells());
		}

		[Test]
		[ExpectedException(typeof(BoardCellIsOccupiedException))]
		public void When_SignatureIsPlacedInOccupiedCell_Then_BoardShouldReturnException()
		{
			Board board = new Board();
			board.PlaceSignature(0, 0, 'X');
			board.PlaceSignature(0, 0, '0');
		}

		[Test]
		public void When_SignatureIsPlaced_Then_ThisPlaceShouldBeNotEmpty()
		{
			Board board = new Board();
			board.PlaceSignature(2, 2, 'X');
			Assert.IsFalse(board.IsCellEmpty(2, 2));
		}

		[Test]
		public void When_SingrantureIsPlaced_Then_BoardShouldPrintFirstRowOfBoardWithPlacedSignature()
		{
			Board board = new Board();
			board.PlaceSignature(0, 0, 'X');
			Assert.AreEqual("X| | ", board.PrintBoard().Substring(0,5));
		}

		[Test]
		public void When_2DifferentSingranturesArePlaced_Then_BoardShouldPrintFirstRowOfBoardWithPlacedSignatures()
		{
			Board board = new Board();
			board.PlaceSignature(0, 0, 'X');
			board.PlaceSignature(0, 1, '0');
			Assert.AreEqual("X|0| ", board.PrintBoard().Substring(0, 5));
		}

		[Test]
		public void When_WholeBoardIsFull_Then_BoardShouldPrintAppriopariateMarks()
		{
			Board board = new Board();
			board.PlaceSignature(0, 0, 'X');
			board.PlaceSignature(0, 1, '0');
			board.PlaceSignature(0, 2, 'X');
			board.PlaceSignature(1, 0, '0');
			board.PlaceSignature(1, 1, 'X');
			board.PlaceSignature(1, 2, '0');
			board.PlaceSignature(2, 0, 'X');
			board.PlaceSignature(2, 1, '0');
			board.PlaceSignature(2, 2, 'X');
			Assert.AreEqual("X|0|X\n" +
							"-------\n" +
							"0|X|0\n" +
							"-------\n" +
							"X|0|X\n", board.PrintBoard());
		}

		[Test]
		public void When_BoardIsEmpty_Then_BoardShouldNotBeWinning()
		{
			Board board = new Board();
			
			Assert.AreEqual(false, board.IsWin('X'));
		}

		[Test]
		public void When_BoardIsFullWitoutWin_Then_BoardShouldNotBeWinning()
		{
			Board board = new Board();
			board.PlaceSignature(0, 0, '0');
			board.PlaceSignature(0, 1, '0');
			board.PlaceSignature(0, 2, 'X');
			board.PlaceSignature(1, 0, 'X');
			board.PlaceSignature(1, 1, 'X');
			board.PlaceSignature(1, 2, '0');
			board.PlaceSignature(2, 0, '0');
			board.PlaceSignature(2, 1, 'X');
			board.PlaceSignature(2, 2, '0');

			Assert.AreEqual(false, board.IsWin('X'));
			Assert.AreEqual(false, board.IsWin('0'));
		}

		[Test]
		public void When_BoardIsFullWitoutWinLastRowCheck_Then_BoardShouldNotBeWinning()
		{
			Board board = new Board();
			board.PlaceSignature(0, 0, '0');
			board.PlaceSignature(0, 1, 'X');
			board.PlaceSignature(0, 2, 'X');
			board.PlaceSignature(1, 0, 'X');
			board.PlaceSignature(1, 1, '0');
			board.PlaceSignature(1, 2, '0');
			board.PlaceSignature(2, 0, '0');
			board.PlaceSignature(2, 1, 'X');
			board.PlaceSignature(2, 2, 'X');

			Assert.AreEqual(false, board.IsWin('X'));
			Assert.AreEqual(false, board.IsWin('0'));
		}

		[Test]
		public void When_BoardIsFullWitoutWinMiddleRowCheck_Then_BoardShouldBeWinningForOne()
		{
			Board board = new Board();
			board.PlaceSignature(0, 0, 'X');
			board.PlaceSignature(0, 1, ' ');
			board.PlaceSignature(0, 2, ' ');
			board.PlaceSignature(1, 0, '0');
			board.PlaceSignature(1, 1, '0');
			board.PlaceSignature(1, 2, '0');
			board.PlaceSignature(2, 0, 'X');
			board.PlaceSignature(2, 1, ' ');
			board.PlaceSignature(2, 2, 'X');

			Assert.AreEqual(false, board.IsWin('X'));
			Assert.AreEqual(true, board.IsWin('0'));
		}

		[Test]
		public void When_FirstRowIsWinning_Then_BoardShouldBeWinning()
		{
			Board board = new Board();
			board.PlaceSignature(0,0,'X');
			board.PlaceSignature(0,1,'X');
			board.PlaceSignature(0,2,'X');
			
			Assert.AreEqual(true, board.IsWin('X'));
		}

		[Test]
		public void When_SecondRowIsWinning_Then_BoardShouldBeWinning()
		{
			Board board = new Board();
			board.PlaceSignature(1, 0, 'X');
			board.PlaceSignature(1, 1, 'X');
			board.PlaceSignature(1, 2, 'X');

			Assert.AreEqual(true, board.IsWin('X'));
		}

		[Test]
		public void When_ThirdRowIsWinning_Then_BoardShouldBeWinning()
		{
			Board board = new Board();
			board.PlaceSignature(2, 0, 'X');
			board.PlaceSignature(2, 1, 'X');
			board.PlaceSignature(2, 2, 'X');

			Assert.AreEqual(true, board.IsWin('X'));
		}

		[Test]
		public void When_FirstColumnIsWinning_Then_BoardShouldBeWinning()
		{
			Board board = new Board();
			board.PlaceSignature(0, 0, 'X');
			board.PlaceSignature(1, 0, 'X');
			board.PlaceSignature(2, 0, 'X');

			Assert.AreEqual(true, board.IsWin('X'));
		}

		[Test]
		public void When_SecondColumnIsWinning_Then_BoardShouldBeWinning()
		{
			Board board = new Board();
			board.PlaceSignature(0, 1, 'X');
			board.PlaceSignature(1, 1, 'X');
			board.PlaceSignature(2, 1, 'X');

			Assert.AreEqual(true, board.IsWin('X'));
		}

		[Test]
		public void When_ThirdColumnIsWinning_Then_BoardShouldBeWinning()
		{
			Board board = new Board();
			board.PlaceSignature(0, 2, 'X');
			board.PlaceSignature(1, 2, 'X');
			board.PlaceSignature(2, 2, 'X');

			Assert.AreEqual(true, board.IsWin('X'));
		}

		[Test]
		public void When_CrossLeftIsWinning_Then_BoardShouldBeWinning()
		{
			Board board = new Board();
			board.PlaceSignature(0, 0, 'X');
			board.PlaceSignature(1, 1, 'X');
			board.PlaceSignature(2, 2, 'X');

			Assert.AreEqual(true, board.IsWin('X'));
		}

		[Test]
		public void When_CrossRightIsWinning_Then_BoardShouldBeWinning()
		{
			Board board = new Board();
			board.PlaceSignature(0, 2, 'X');
			board.PlaceSignature(1, 1, 'X');
			board.PlaceSignature(2, 0, 'X');

			Assert.AreEqual(true, board.IsWin('X'));
		}


		
		




	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoughtsAndCrosses.Classes;
using NoughtsAndCrosses.Interfaces;
using NUnit.Framework;

namespace NoughtsAndCrosses.Tests
{
	[TestFixture]
	class BotTests
	{
		[Test]
		public void When_BotMakesFirstMove_Then_BoardShouldHas8MovesLeft()
		{
			Board board = new Board();
			BotRandomMovesForDefaultBoard botRandom = new BotRandomMovesForDefaultBoard(board, 'X');
			GameController gameController = new GameController(board, botRandom, botRandom);
			botRandom.MakeMove();
			
			Assert.AreEqual(8, gameController.HowManyMovesLeft());
		}

		[Test]
		public void When_BotMakesTwoMoves_Then_BoardShouldHas7MovesLeft()
		{
			Board board = new Board();
			BotRandomMovesForDefaultBoard botRandom = new BotRandomMovesForDefaultBoard(board, 'X');
			GameController gameController = new GameController(board, botRandom, botRandom);
			botRandom.MakeMove();
			botRandom.MakeMove();
			
			Assert.AreEqual(7, gameController.HowManyMovesLeft());
		}

		[Test]
		public void When_BotMakes9Moves_Then_BoardShouldHas0MovesLeft()
		{
			Board board = new Board();
			BotRandomMovesForDefaultBoard botRandom = new BotRandomMovesForDefaultBoard(board, 'X');
			GameController gameController = new GameController(board, botRandom, botRandom);
			botRandom.MakeMove();
			botRandom.MakeMove();
			botRandom.MakeMove();
			botRandom.MakeMove();
			botRandom.MakeMove();
			botRandom.MakeMove();
			botRandom.MakeMove();
			botRandom.MakeMove();
			botRandom.MakeMove();
			
			Assert.AreEqual(0, gameController.HowManyMovesLeft());
		}

		[Test]
		public void When_TwoBotsMake9Moves_Then_BoardShouldHas0MovesLeft()
		{
			Board board = new Board();
			BotRandomMovesForDefaultBoard botRandom1 = new BotRandomMovesForDefaultBoard(board, 'X');
			BotRandomMovesForDefaultBoard botRandom2 = new BotRandomMovesForDefaultBoard(board, '0');
			GameController gameController = new GameController(board, botRandom1, botRandom2);
			botRandom1.MakeMove();
			botRandom2.MakeMove();
			
			Assert.AreEqual(7, gameController.HowManyMovesLeft());
		}
	}
}

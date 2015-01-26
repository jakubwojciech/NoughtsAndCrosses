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
	class GameControllerTests
	{
		[Test]
		public void When_GameControllerIsCreated_Then_BoardShouldHas9MovesLeft()
		{
			Board board = new Board();
			BotRandomMovesForDefaultBoard botRandom = new BotRandomMovesForDefaultBoard(board, 'X');
			GameController gameController = new GameController(board, botRandom, botRandom);
			
			Assert.AreEqual(9, gameController.HowManyMovesLeft());
		}

		[Test]
		public void When_GameControllerLetstoMake1Move_Then_BoardShouldHas8MovesLeft()
		{
			Board board = new Board();
			BotRandomMovesForDefaultBoard botRandom1 = new BotRandomMovesForDefaultBoard(board, 'X');
			GameController gameController = new GameController(board, botRandom1, botRandom1);
			gameController.LetToMakeNextMove();

			Assert.AreEqual(8, gameController.HowManyMovesLeft());
		}

		[Test]
		public void When_GameControllersLetsToMake4Moves_Then_BoardShouldHas4SignaturesAppropriateForBots()
		{
			Board board = new Board();
			BotRandomMovesForDefaultBoard botRandom1 = new BotRandomMovesForDefaultBoard(board, 'X');
			BotRandomMovesForDefaultBoard botRandom2 = new BotRandomMovesForDefaultBoard(board, '0');
			GameController gameController = new GameController(board, botRandom1, botRandom2);
			gameController.LetToMakeNextMove();
			gameController.LetToMakeNextMove();
			gameController.LetToMakeNextMove();
			gameController.LetToMakeNextMove();

			Assert.AreEqual(5, gameController.HowManyMovesLeft());
			Assert.AreEqual(2 , gameController.PrintCurrentBoard().Count(x => x == 'X'));
			Assert.AreEqual(2 , gameController.PrintCurrentBoard().Count(x => x == '0'));
		}



		//[Test]


		//public void IsWin()
		//{
		//	GameController gameController = new GameController();
		//	BotRandomMovesForDefaultBoard bot = new BotRandomMovesForDefaultBoard(gameController, 'X');
		//	bot.MakeMove();
		//	Assert.AreEqual(8,gameController.HowManyMovesLeft());
		//}




	}
}

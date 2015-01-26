using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NoughtsAndCrosses.Classes;
using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses
{
	class Program
	{
		/// <summary>
		/// Application plays 'Noughts and Crosses' aka Tic Tac Toe game.
		/// 
		/// To create this application I have used 3 main classes:
		/// 
		/// Board - which is board representation, it implements IBoard which give us possibility to create other boards
		/// with different rules and sizes and apply to application without making any changes in current code,
		/// 
		/// BotRandomMovesForDefaultBoard - which is class representing default bot with random moves. This bot is created
		/// just for default 3x3 board. It implements IBot interface which give us possibility to create other bots
		/// with different behaviour for different boards witout making changes in current code,
		/// 
		/// GameController - which is flow controller. This controller contains all objects and manage them to make progress
		/// in game.
		/// 
		/// Thank you
		/// Jakub Wojciechowski
		/// 
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			Board board = new Board();
			BotRandomMovesForDefaultBoard bot1 = new BotRandomMovesForDefaultBoard(board, 'X');
			BotRandomMovesForDefaultBoard bot2 = new BotRandomMovesForDefaultBoard(board, '0');
			GameController gameController = new GameController(board,bot1,bot2);
			bool gameOver = false;
			int stepsCounter = 1;

			do
			{
				Console.WriteLine("Step {0}", stepsCounter++);
				
				gameController.LetToMakeNextMove();

				Console.Write(gameController.PrintCurrentBoard());
				Console.WriteLine();
				
				if (gameController.IsWin(gameController.LastMoveBot.Signature))
				{
					gameOver = true;
					Console.WriteLine(String.Format("WE HAVE A WINNER: {0} Won", gameController.LastMoveBot.Signature));
				}
				if (gameController.HowManyMovesLeft() == 0 && !gameController.IsWin(gameController.LastMoveBot.Signature))
				{
					gameOver = true;
					Console.WriteLine("IT IS A DRAW !");
				}

				Thread.Sleep(1000);

			} while (!gameOver);

			Console.ReadKey();
		}
	}
}

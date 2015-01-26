using System.Security.Cryptography.X509Certificates;
using NoughtsAndCrosses.Interfaces;
using NoughtsAndCrosses.Tests;

namespace NoughtsAndCrosses.Classes
{
	internal class GameController
	{
		private readonly IBoard board;
		private readonly IBot bot1;
		private readonly IBot bot2;

		/// <summary>
		/// Bot which made previus move
		/// </summary>
		public IBot LastMoveBot { get; private set; }

		public GameController(IBoard board, IBot bot1, IBot bot2)
		{
			this.board = board;
			this.bot1 = bot1;
			this.bot2 = bot2;
		}

		/// <summary>
		/// Place signature of the board in precise cell.
		/// </summary>
		/// <param name="x">Cell row</param>
		/// <param name="y">Cell column</param>
		/// <param name="signature">Signature to place</param>
		public void PlaceSignatureOnBoard(int x, int y, char signature)
		{
			board.PlaceSignature(x, y, signature);
		}

		/// <summary>
		/// Shows how many moves is left on the board.
		/// </summary>
		/// <returns>Number of moves left</returns>
		public int HowManyMovesLeft()
		{
			return board.CountEmptyCells();
		}

		/// <summary>
		/// Makes next move on the board by next bot. It automatically picks which player should play next.
		/// </summary>
		public void LetToMakeNextMove()
		{
			if (LastMoveBot == null || LastMoveBot == bot2)
			{
				bot1.MakeMove();
				LastMoveBot = bot1;
			}
			else
			{
				bot2.MakeMove();
				LastMoveBot = bot2;
			}
		}

		/// <summary>
		/// Prints current board.
		/// </summary>
		/// <returns>Board in plain text representation</returns>
		public string PrintCurrentBoard()
		{
			return board.PrintBoard();
		}

		/// <summary>
		/// Checks if on the board is win
		/// </summary>
		/// <param name="signature">Signature to check for winning</param>
		/// <returns>true- if on the board is win, false- if on the board is no win</returns>
		public bool IsWin(char signature)
		{
			return board.IsWin(signature);
		}
	}
}
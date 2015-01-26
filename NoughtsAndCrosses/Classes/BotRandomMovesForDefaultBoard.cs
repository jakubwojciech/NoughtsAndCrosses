using System;
using NoughtsAndCrosses.Interfaces;
using NoughtsAndCrosses.Tests;

namespace NoughtsAndCrosses.Classes
{
	/// <summary>
	/// Implementation of bot which randomly makes move
	/// </summary>
	internal class BotRandomMovesForDefaultBoard : IBot
	{
		private readonly IBoard board;

		public char Signature { get; private set; }

		public BotRandomMovesForDefaultBoard(IBoard board, char signature)
		{
			Signature = signature;
			this.board = board;
		}

		/// <summary>
		/// Make random move in empty space on the board
		/// </summary>
		public void MakeMove()
		{
			Random rnd = new Random();
			bool signaturePlaced = false;
				
			do
			{
				int x = rnd.Next(0, 3);
				int y = rnd.Next(0, 3);
				if(!board.IsCellEmpty(x, y))
					continue;

				board.PlaceSignature(x, y, Signature);
				signaturePlaced = true;

			} while (signaturePlaced == false);
		}
	}
}
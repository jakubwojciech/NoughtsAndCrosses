using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using NoughtsAndCrosses.Exceptions;
using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses.Classes
{
	internal class Board : IBoard
	{
		//initializing board with spaces, defualt for char is zero (0) which can be used as a signature
		private char[,] board = new char[3,3]
		{
			{' ',' ',' '},
			{' ',' ',' '},
			{' ',' ',' '}
		};

		/// <summary>
		/// Place signature on the board
		/// </summary>
		/// <param name="x">Row where signature will be placed</param>
		/// <param name="y">Column where signature will be placed</param>
		/// <param name="signature">Signature which will be placed on the board</param>
		public void PlaceSignature(int x, int y, char signature)
		{
			if (IsCellEmpty(x, y) == false)
			{
				throw new BoardCellIsOccupiedException(x, y);
			}
			board[x, y] = signature;
		}

		/// <summary>
		/// Checks if cell is empty and is possible to make a move in this cell
		/// </summary>
		/// <param name="x">Row to check</param>
		/// <param name="y">Column to check</param>
		/// <returns></returns>
		public bool IsCellEmpty(int x, int y)
		{
			if (board[x, y] == ' ')
				return true;
			else
				return false;
		}

		/// <summary>
		/// Shows how many empty cells are on the board.
		/// </summary>
		/// <returns>Number of empty cells. If zero - board is full</returns>
		public int CountEmptyCells()
		{
			int counter = 0;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (board[i, j] == ' ')
					{
						counter++;
					}
				}
			}

			return counter;
		}

		/// <summary>
		/// Prints board into string
		/// </summary>
		/// <returns>String with plain text board representation</returns>
		public string PrintBoard()
		{
			string result = "";
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (j == 1)
					{
						result += string.Format("|{0}|", board[i, j]);
					}
					else
					{
						result += board[i, j];						
					}
				}
				if (i != 2)
				{
					result += "\n-------";
				}
				result += "\n";
			}
			return result;
		}

		/// <summary>
		/// Checks if on the board is win
		/// </summary>
		/// <param name="signature">Signature to check for winning</param>
		/// <returns>true- if on the board is win, false- if on the board is no win</returns>
		public bool IsWin(char signature)
		{
			if (isRowWin(signature))
				return true;
			if (isColumnWin(signature))
				return true;
			if (isCrossWin(signature))
				return true;

			return false;
		}

		private bool isCrossWin(char signature)
		{
			if (board[0, 0] == signature && board[1, 1] == signature && board[2, 2] == signature)
				return true;
			if (board[0, 2] == signature && board[1, 1] == signature && board[2, 0] == signature)
				return true;

			return false;
		}

		private bool isColumnWin(char signature)
		{
			if (board[0, 0] == signature && board[1, 0] == signature && board[2, 0] == signature)
				return true;
			if (board[0, 1] == signature && board[1, 1] == signature && board[2, 1] == signature)
				return true;
			if (board[0, 2] == signature && board[1, 2] == signature && board[2, 2] == signature)
				return true;

			return false;
		}

		private bool isRowWin(char signature)
		{
			if (board[0, 0] == signature && board[0, 1] == signature && board[0, 2] == signature)
				return true;
			if (board[1, 0] == signature && board[1, 1] == signature && board[1, 2] == signature)
				return true;
			if (board[2, 0] == signature && board[2, 1] == signature && board[2, 2] == signature)
				return true;

			return false;
		}
	}
}
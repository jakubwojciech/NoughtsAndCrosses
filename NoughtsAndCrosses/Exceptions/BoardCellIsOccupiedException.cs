using System;

namespace NoughtsAndCrosses.Exceptions
{
	internal class BoardCellIsOccupiedException : Exception
	{
		private int x;
		private int y;
		public BoardCellIsOccupiedException(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public override string Message
		{
			get
			{
				return String.Format("You can't use this cell. This cell is occupied. Cell coordinates: x = {0}, y = {1}", 
					this.x, this.y);
			}
		}
	}
}
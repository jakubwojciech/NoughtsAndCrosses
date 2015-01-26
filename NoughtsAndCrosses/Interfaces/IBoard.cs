namespace NoughtsAndCrosses.Interfaces
{
	internal interface IBoard
	{
		void PlaceSignature(int x, int y, char signature);
		bool IsCellEmpty(int x, int y);
		int CountEmptyCells();
		string PrintBoard();
		bool IsWin(char signature);
	}
}
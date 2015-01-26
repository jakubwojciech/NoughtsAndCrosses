namespace NoughtsAndCrosses.Interfaces
{
	internal interface IBot
	{
		char Signature { get; }
		void MakeMove();
	}
}
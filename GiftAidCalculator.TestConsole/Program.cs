using System;

namespace GiftAidCalculator.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			// Calc Gift Aid Based on Previous
			Console.WriteLine("Please Enter donation amount:");
			Console.WriteLine( new AidCalculator(new FakeTaxRateRepository()).CalculateGiftAidFor(decimal.Parse(Console.ReadLine())));
			Console.WriteLine("Press any key to exit.");
			Console.ReadLine();
		}
	}
}

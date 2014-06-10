using System;

namespace GiftAidCalculator.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
		    var calculator = CreateCalculator();

			// Calc Gift Aid Based on Previous
			Console.WriteLine("Please Enter donation amount:");
			Console.WriteLine(calculator.CalculateGiftAidFor(decimal.Parse(Console.ReadLine())));
			Console.WriteLine("Press any key to exit.");
			Console.ReadLine();
		}

	    private static AidCalculator CreateCalculator()
	    {
	        var calculator = new AidCalculator(new FakeTaxRateRepository());
	        return calculator;
	    }
	}
}

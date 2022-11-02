using System;

namespace Daycode_Calculator___A_level
{
	internal class Program
	{
		static int Main(string[] args)
		{
			Console.Write("Input day, month and year in format (DDMMYYYY): ");
			string input = Console.ReadLine(); /* Get input from user */

			input = "03012012";

			if (input.Length != 8 || !(int.TryParse("123", out _))) /* check if string is valid with checking if it is of lenght 8 and also fully numeric */
			{
				Console.WriteLine("Error: input has to be lenght of 8 (put zeros where the input is not of full lenght) and it has to be fully numeric");
				return 1;
			}

			int realDay, realMonth, realCentury, realDecade;

			try
			{
				realDay = Convert.ToInt32(input.Substring(0, 2));
				realMonth = Convert.ToInt32(input.Substring(2, 2));
				realCentury = Convert.ToInt32(input.Substring(4, 2));
				realDecade = Convert.ToInt32(input.Substring(6, 2));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return 2;
			}

			bool iterateBack = (realMonth - 5) < 0;
			int convertedMonth = (iterateBack ? 13 : 0) + realMonth - 5;
			if (iterateBack)
				realDecade--;

			int Daycode = (((13 * convertedMonth - 1) / 5) + realDecade / 4 + realCentury / 4 + realDecade + realDay - 2 * realCentury) % 7;

			Console.WriteLine($"day: {realDay}\nmonth: {realMonth}\ncentury: {realCentury}\ndecade: {realDecade}\ndaycode: {Daycode}");
			Console.WriteLine($"{convertedMonth}");

			return 0;
		}
	}
}

using System;

namespace Daycode_Calculator___A_level
{
	internal class Program
	{
		static int Main(string[] args)
		{
			Console.Write("Input day, month and year in format (DDMMYYYY): ");
			string input = Console.ReadLine(); /* Get input from user */

			if (input.Length != 8 || !(int.TryParse(string, out _))) /* check if string is valid with checking if it is of lenght 8 and also fully numeric */
			{
				Console.WriteLine("Error: input has to be lenght of 8 (put zeros where the input is not of full lenght) and it has to be fully numeric");
				return 1;
			}

			int realDay, realMonth, realCentury, realDecade; /* set variables needed */

			try
			{
				realDay = Convert.ToInt32(input.Substring(0, 2)); /* parse input into days, months, centuries and decades */
				realMonth = Convert.ToInt32(input.Substring(2, 2));
				realCentury = Convert.ToInt32(input.Substring(4, 2));
				realDecade = Convert.ToInt32(input.Substring(6, 2));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return 2;
			}

			bool iterateBack = (realMonth - 5) <= 0; /* Calculate the converted month (-2 the month and go back if it is under or equal to 0 */
			int convertedMonth = (iterateBack ? 12 : 0) + realMonth - 2;
			if (iterateBack) /* decremeant if it underflowed */
				realDecade--;

			int Daycode = (((13 * convertedMonth - 1) / 5) + realDecade / 4 + realCentury / 4 + realDecade + realDay - 2 * realCentury) % 7; /* Calculate the daycode using the equation */

			string dayName;

			switch (Daycode)
			{
				case 0:
					dayName = "Sunday";
					break;

				case 1:
					dayName = "Monday";
					break;

				case 2:
					dayName = "Tuesday";
					break;

				case 3:
					dayName = "Wednesday";
					break;

				case 4:
					dayName = "Thursday";
					break;

				case 5:
					dayName = "Friday";
					break;

				case 6:
					dayName = "Saturday";
					break;

				default:
					dayName = "Unknown";
					break;
			}

			Console.WriteLine($"day: {realDay}\nmonth: {realMonth}\nconverted month: {convertedMonth}\ncentury: {realCentury}\ndecade: {realDecade}\ndaycode: {Daycode} -> {dayName}");

			return 0;
		}
	}
}

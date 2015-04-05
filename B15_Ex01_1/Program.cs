using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryChecker
{
	public class Program
	{
		private const int k_numberOfDigits = 3;
		private const int k_numberOfEntries = 5;

		public static void Main()
		{
			binaryCheck();
		}

		private static void binaryCheck()
		{
			int[] numbers = new int[k_numberOfEntries];
			int ascendingCount = 0;
			int descendungCount = 0;
			float binaryDigitCountAvarage = 0;
			float decimalAvarage = 0;

			Console.WriteLine("Please enter {0} numbers with {1} digits each:", k_numberOfEntries, k_numberOfDigits);
			for (int i = 0; i < k_numberOfEntries; i++)
			{
				numbers[i] = readNumberFromUser();
			}

			Console.Write("The binary numbers are:");
			foreach (int number in numbers)
			{
				string numberInBinary = intToBinary(number);

				Console.Write(" ");
				Console.Write(numberInBinary);

				if (isAscendingSeries(number))
				{
					ascendingCount++;
				}

				if (isDescendingSeries(number))
				{
					descendungCount++;
				}

				binaryDigitCountAvarage += (float)numberInBinary.Length / k_numberOfEntries;
				decimalAvarage += (float)number / k_numberOfEntries;
			}

			Console.WriteLine(".");
			Console.WriteLine(
				"There are {0} numbers which are an ascending series and {1} which are descending.",
				ascendingCount,
				descendungCount);
			Console.WriteLine("The avarege number of digits in the binary number is {0} .", binaryDigitCountAvarage);
			Console.WriteLine("The general avarege of the inserted numbers is {0}.", decimalAvarage);
			Console.ReadLine();
		}

		private static bool tryParseInput(string i_inputNumberStr, out int o_result)
		{
			bool isValid = i_inputNumberStr.Length == k_numberOfDigits;

			if (isValid)
			{
				isValid = int.TryParse(i_inputNumberStr, out o_result);
			}
			else
			{
				o_result = -1;
			}

			if (isValid)
			{
				isValid = o_result != 0;
			}

			return isValid;
		}

		private static int readNumberFromUser()
		{
			int inputNumber;

			while (!tryParseInput(Console.ReadLine(), out inputNumber))
			{
				Console.WriteLine("The input you entered is invalid. Please try again.");
			}

			return inputNumber;
		}

		private static bool isDescendingSeries(int i_number)
		{
			bool isDescending = true;
			int previousDigit = -1;

			while (i_number > 0 && isDescending)
			{
				int currentDigit = i_number % 10;
				isDescending = currentDigit > previousDigit;
				previousDigit = currentDigit;
				i_number /= 10;
			}

			return isDescending;
		}

		private static bool isAscendingSeries(int i_number)
		{
			bool isAscending = true;
			int previousDigit = 10;

			while(i_number > 0 && isAscending)
			{
				int currentDigit = i_number % 10;
				isAscending = currentDigit < previousDigit;
				previousDigit = currentDigit;
				i_number /= 10;
			}

			return isAscending;
		}

		private static string intToBinary(int i_number)
		{
			string binaryNumber = string.Empty;

			while (i_number > 0)
			{
				int digit = i_number % 2;
				binaryNumber = digit.ToString() + binaryNumber;
				i_number /= 2;
			}

			return binaryNumber;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberStatistics
{
	public class Program
	{
		private const int k_requiredNumberOfDigits = 8;

		public static void Main()
		{
			PrintStatistics();
		}

		private static int ReadValidNumber()
		{
			bool isValid = false;
			int number = 0;

			while (!isValid)
			{
				Console.WriteLine("Please enter a positive {0} digit number:", k_requiredNumberOfDigits);
				string numberStr = Console.ReadLine();
				isValid = numberStr.Length == k_requiredNumberOfDigits;

				if (isValid)
				{
					char firstChar = numberStr[0];
					isValid = char.IsDigit(firstChar) && firstChar != '0';
				}

				if (isValid)
				{
					isValid = int.TryParse(numberStr, out number);
				}

				if (isValid)
				{
					isValid = number > 0;
				}
			}

			return number;
		}

		private static void PrintStatistics()
		{
			int number = ReadValidNumber();
			int firstDigit = number % 10;
			int maxDigit = firstDigit;
			int minDigit = firstDigit;
			int digitsBiggerThanTheFirstCount = 0;
			int digitsSmallerThanTheFirstCount = 0;

			while (number > 0)
			{
				int digit = number % 10;
				number /= 10;
				if (digit > firstDigit)
				{
					digitsBiggerThanTheFirstCount++;
					if (digit > maxDigit)
					{
						maxDigit = digit;
					}
				}
				else if (digit < firstDigit)
				{
					digitsSmallerThanTheFirstCount++;
					if (digit < minDigit)
					{
						minDigit = digit;
					}
				}
			}

			Console.WriteLine("The first digits is {0}.", firstDigit);
			Console.WriteLine("There are {0} digits bigger than the first.", digitsBiggerThanTheFirstCount);
			Console.WriteLine("There are {0} digits smaller than the first.", digitsSmallerThanTheFirstCount);
			Console.WriteLine("The biggest digit is {0}.", maxDigit);
			Console.WriteLine("The smallest digit is {0}.", minDigit);
		}
	}
}

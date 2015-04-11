using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StringAnalizer
{
	public class Program
	{
		private const int k_NumberOdCharachters = 10;
		private static readonly Regex sr_LetterValidationRegex = new Regex(@"^[A-Za-z]+$");

		public static void Main()
		{
			AnalayzeString();
		}

		private static bool isCorrectLength(string i_input)
		{
			return i_input.Length == k_NumberOdCharachters;
		}

		private static void AnalayzeString()
		{
			string input = string.Empty;
			bool isDigitInput = false;
			bool isLetterInput = false;
			bool isInputValid = false;

			while (!isInputValid)
			{
				Console.WriteLine("Please enter a {0} charachter string of either letters or numbers:", k_NumberOdCharachters);
				input = Console.ReadLine();
				isInputValid = isCorrectLength(input);
				if (isInputValid)
				{
					isDigitInput = isDigitString(input);
					isLetterInput = isLetterString(input);
					isInputValid = (isDigitInput || isLetterInput) && !(isDigitInput && isLetterInput);
				}
			}

			if (isPalindrom(input))
			{
				Console.WriteLine("'{0}' is palindrom.", input);
			}
			else
			{
				Console.WriteLine("'{0}' is not palidrom.", input);
			}

			if (isDigitInput)
			{
				Console.WriteLine("The sum of digits in '{0}' is {1}.", input, sumDigitsInString(input));
			}
			else if (isLetterInput)
			{
				Console.WriteLine("There are {0} Capital letters in '{1}'.", countCapitalLetterInString(input), input);
			}
		}

		private static bool isPalindrom(string i_string)
		{
			int partition = i_string.Length / 2;
			bool isPalindrom = true;

			for (int i = 0; i < partition; i++)
			{
				isPalindrom = i_string[i] == i_string[i_string.Length - 1 - i];
				if (!isPalindrom)
				{
					break;
				}
			}

			return isPalindrom;
		}

		private static int sumDigitsInString(string i_string)
		{
			int sum = 0;

			foreach (char c in i_string)
			{
				// Can cast to in since we know all values are integers (0-9)
				sum += (int) char.GetNumericValue(c);
			}

			return sum;
		}

		private static int countCapitalLetterInString(string i_str)
		{
			int sum = 0;

			foreach(char c in i_str)
			{
				if (char.IsUpper(c))
				{
					sum++;
				}
			}

			return sum;
		}

		private static bool isDigitString(string i_string)
		{
			bool result = true;

			foreach (char c in i_string)
			{
				result = char.IsDigit(c);
				if (!result)
				{
					break;
				}
			}

			return result;
		}

		private static bool isLetterString(string i_string)
		{
			return sr_LetterValidationRegex.IsMatch(i_string);
		}
	}
}

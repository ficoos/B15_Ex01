using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeginnerClock
{
	public class Program
	{
		private const int k_numberOfLines = 5;

		public static void Main()
		{
			DrawClock(k_numberOfLines);
		}

		public static void DrawClock(int i_numberOfLines)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if (i_numberOfLines % 2 == 1)
			{
				i_numberOfLines--;
			}

			int halfNumberOfLines = i_numberOfLines / 2;

			for (int i = 0; i <= i_numberOfLines; i++)
			{
				int numberOfStars = Math.Abs((halfNumberOfLines - i) * 2) + 1;
				int numberOfSpaces = halfNumberOfLines - (numberOfStars / 2);

				for (int j = 0; j < numberOfSpaces; j++)
				{
					stringBuilder.Append(" ");
				}

				for (int j = 0; j < numberOfStars; j++)
				{
					stringBuilder.Append("*");
				}

				stringBuilder.AppendLine();
			}

			Console.WriteLine(stringBuilder.ToString());
		}
	}
}

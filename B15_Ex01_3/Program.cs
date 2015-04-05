using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedClock
{
	public class Program
	{
		public static void Main()
		{
			drawClock();
		}

		private static void drawClock()
		{
			int clockSize = -1;
			bool isInputValid = false;

			while (!isInputValid)
			{
				Console.WriteLine("Please enter the number of lines for the sand clock:");
				string clockSizeStr = Console.ReadLine();
				isInputValid = int.TryParse(clockSizeStr, out clockSize);
				if (isInputValid)
				{
					isInputValid = clockSize > 0;
				}
			}

			BeginnerClock.Program.DrawClock(clockSize);
		}
	}
}

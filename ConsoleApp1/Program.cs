using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(FormatNumber(10));
			Console.ReadKey();
		}

		public static int FormatNumber(int number)
		{
			var binaryRep = string.Empty;
			var result = 0;
			while (number > 0)
			{
				binaryRep += (number % 2) + binaryRep;
				number = number / 2;

				//Console.WriteLine(number.ToString());
			}

			//Console.WriteLine(binaryRep);

			int base1 = 1;
			int len = binaryRep.Length;
			for (int i = 0; i < len; i++)
			{
				if (binaryRep[i] == '1')
					result += base1;

				base1 = base1 * 2;
			}

			return result;
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481_Unit4_Assignment
{
	public class IT481_Unit4_Assignment
	{
		static void Main(string[] args)
		{
		}

		/// <summary>
		/// given an array of integers, and a number of times to look, return the minimum value
		/// </summary>
		/// <param name="arrayOfInts"></param>
		/// <param name="n"></param>
		/// <returns></returns>
		public static int Example1(int[] arrayOfInts, int n)
		{
			int currMin = 100;
			for (int i = 0; i < n; i++)
			{
				if (arrayOfInts[i] < currMin)
				{
					currMin = arrayOfInts[i];
				}
			}
			return currMin;
		}

		/// <summary>
		/// given an array of integers, print out each value
		/// </summary>
		/// <param name="arrayOfInts"></param>
		public static void Example2(int[] arrayOfInts)
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine(arrayOfInts[i].ToString());
			}
		}

		/// <summary>
		/// given two integer search values if they are equal to the values in the array
		/// </summary>
		/// <param name="arrayOfInts"></param>
		public static bool Example3(int[] arrayOfInts)
		{
			int a = 10;
			int b = 5;
			bool found = false;

			for (int i = 0; i < arrayOfInts.Length; i++)
			{
				if (a == arrayOfInts[i])
				{
					Console.WriteLine("The value of a was found in int array.");
					found = true;
				}
				else if (b == arrayOfInts[i])
				{
					Console.WriteLine("The value of b was found in int array.");
					found = true;
				}
			}
			if (found == false)
				Console.WriteLine("None of the search values were found.");

			return found;
		}

	}
}

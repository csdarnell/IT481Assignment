using IT481_Unit6_Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481_Unit7_Assignment
{
	class IT481_Unit7_Assignment
	{
		private const int _minNumber = 0;
		private const int _maxNumber = 100;

		static void Main(string[] args)
		{
			int[] list1 = PrepareTestSamples(10);

			int[] list1ToSort = DuplicateArray(list1);
			PrintArray(list1ToSort);

			MergeSort(list1ToSort, 0, list1ToSort.Length - 1);

			PrintArray(list1ToSort);

			Console.ReadKey();

		}

		public static void PrintArray(int[] array)
		{
			Console.WriteLine("----------------------------------------");

			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i].ToString());
				if (i < array.Length - 1)
				{
					Console.Write(", ");
				}
			}
			Console.WriteLine();

			Console.WriteLine("----------------------------------------");
		}
		public static int[] DuplicateArray(int[] arrayToDuplicate)
		{
			List<int> outputArray = new List<int>();

			for (int i = 0; i < arrayToDuplicate.Length; i++)
			{
				outputArray.Add(arrayToDuplicate[i]);
			}

			return outputArray.ToArray();
		}

		public static int[] PrepareTestSamples(int itemsToCreate)
		{
			List<int> samples = new List<int>();
			for (int i = 0; i < itemsToCreate; i++)
			{
				samples.Add(Randomizer.GetRandomNumber(_minNumber, _maxNumber));
			}
			return samples.ToArray();
		}

		public static void BubbleSort(int[] listToSort)
		{
			bool flag = true;

			for (int i = 1; (i <= (listToSort.Length - 1)) && flag; i++)
			{
				flag = false;
				for (int j = 0; j < (listToSort.Length - 1); j++)
				{
					if (listToSort[j + 1] < listToSort[j])
					{
						int temp = listToSort[j];
						listToSort[j] = listToSort[j + 1];
						listToSort[j + 1] = temp;
						flag = true;
					}
				}
			}
		}

		public static void MergeSortMain(int[] numbers, int left, int mid, int right)
		{
			int[] temp = new int[25];
			int i, eol, num, pos;
			eol = (mid - 1);
			pos = left;
			num = (right - left + 1);

			while ((left <= eol) && (mid <= right))
			{
				if (numbers[left] <= numbers[mid])
					temp[pos++] = numbers[left++];
				else
					temp[pos++] = numbers[mid++];
			}
			while (left <= eol)
				temp[pos++] = numbers[left++];
			while (mid <= right)
				temp[pos++] = numbers[mid++];
			for (i = 0; i < num; i++)
			{
				numbers[right] = temp[right];
				right--;
			}
		}

		public static void MergeSort(int[] numbers, int left, int right)
		{
			int mid;
			if (right > left)
			{
				mid = (right + left) / 2;
				MergeSort(numbers, left, mid);
				MergeSort(numbers, (mid + 1), right);
				MergeSortMain(numbers, left, (mid + 1), right);
			}
		}

	}
}

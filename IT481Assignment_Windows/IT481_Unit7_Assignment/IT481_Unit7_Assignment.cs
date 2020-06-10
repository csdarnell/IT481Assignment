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
			int list1SampleSize = 100;
			int[] list1 = PrepareTestSamples(list1SampleSize);
			int[] list1ForBubbleSort = DuplicateArray(list1);
			int[] list1ForMergeSort = DuplicateArray(list1);
			TimeSpan list1BubbleSortDiff;
			TimeSpan list1MergeSortDiff;

			int list2SampleSize = 1000;
			int[] list2 = PrepareTestSamples(list2SampleSize);
			int[] list2ForBubbleSort = DuplicateArray(list2);
			int[] list2ForMergeSort = DuplicateArray(list2);
			TimeSpan list2BubbleSortDiff;
			TimeSpan list2MergeSortDiff;

			int list3SampleSize = 10000;
			int[] list3 = PrepareTestSamples(list3SampleSize);
			int[] list3ForBubbleSort = DuplicateArray(list3);
			int[] list3ForMergeSort = DuplicateArray(list3);
			TimeSpan list3BubbleSortDiff;
			TimeSpan list3MergeSortDiff;


			DateTime start = DateTime.Now;
			BubbleSort(list1ForBubbleSort);
			DateTime end = DateTime.Now;
			list1BubbleSortDiff = end - start;

			start = DateTime.Now;
			MergeSort(list1ForMergeSort, 0, list1ForMergeSort.Length - 1);
			end = DateTime.Now;
			list1MergeSortDiff = end - start;

			start = DateTime.Now;
			BubbleSort(list2ForBubbleSort);
			end = DateTime.Now;
			list2BubbleSortDiff = end - start;

			start = DateTime.Now;
			MergeSort(list2ForMergeSort, 0, list2ForMergeSort.Length - 1);
			end = DateTime.Now;
			list2MergeSortDiff = end - start;

			start = DateTime.Now;
			BubbleSort(list3ForBubbleSort);
			end = DateTime.Now;
			list3BubbleSortDiff = end - start;

			start = DateTime.Now;
			MergeSort(list3ForMergeSort, 0, list3ForMergeSort.Length - 1);
			end = DateTime.Now;
			list3MergeSortDiff = end - start;

			Console.WriteLine($"List 1 had {list1SampleSize}.  Bubble Sort Time:  {list1BubbleSortDiff.Milliseconds} milliseconds;  Merge Sort Time:  {list1MergeSortDiff.Milliseconds} milliseconds");
			Console.WriteLine($"List 2 had {list2SampleSize}.  Bubble Sort Time:  {list2BubbleSortDiff.Milliseconds} milliseconds;  Merge Sort Time:  {list2MergeSortDiff.Milliseconds} milliseconds");
			Console.WriteLine($"List 3 had {list3SampleSize}.  Bubble Sort Time:  {list3BubbleSortDiff.Milliseconds} milliseconds;  Merge Sort Time:  {list3MergeSortDiff.Milliseconds} milliseconds");

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
			int[] temp = new int[1000000];
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

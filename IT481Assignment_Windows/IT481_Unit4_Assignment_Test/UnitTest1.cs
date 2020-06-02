using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IT481_Unit4_Assignment_Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestExample1_WithNullArray_Expect100()
		{
			int returnVal = IT481_Unit4_Assignment.IT481_Unit4_Assignment.Example1(null, 0);

			Assert.AreEqual(100, returnVal);
		}

		[TestMethod]
		public void TestExample1_WithArray_Expect50()
		{
			int[] testArray = new int[6] { 100, 200, 89, 50, 65, 64 };

			int returnVal = IT481_Unit4_Assignment.IT481_Unit4_Assignment.Example1(testArray, testArray.Length);

			Assert.AreEqual(50, returnVal);

		}

		[TestMethod]
		public void TestExample2_WithNullArray_ExpectNullReferenceException()
		{
			Assert.ThrowsException<NullReferenceException>(() => IT481_Unit4_Assignment.IT481_Unit4_Assignment.Example2(null));
		}

		[TestMethod]
		public void TestExample2_With100ItemArray_ExpectTheCallToComplete()
		{
			List<int> intList = new List<int>();
			for (int i = 0; i < 100; i++)
			{
				intList.Add(i);
			}

			IT481_Unit4_Assignment.IT481_Unit4_Assignment.Example2(intList.ToArray());

			Assert.IsTrue(true);
		}

		[TestMethod]
		public void TestExample3_WithNullArray_ExpectNullReferenceException()
		{
			Assert.ThrowsException<NullReferenceException>(() => IT481_Unit4_Assignment.IT481_Unit4_Assignment.Example3(null));
		}

		[TestMethod]
		public void TestExample3_With100ItemArray_ExpectTheCallToComplete()
		{
			List<int> intList = new List<int>();
			for (int i = 0; i < 100; i++)
			{
				intList.Add(i);
			}

			bool foundItem = IT481_Unit4_Assignment.IT481_Unit4_Assignment.Example3(intList.ToArray());

			Assert.IsTrue(foundItem);
		}

	}
}

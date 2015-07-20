using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringSearch;

namespace KMPTest
{
	[TestClass]
	public class KmpTest
	{
		[TestMethod]
		public void Contains_PerfectMatch_ReturnsTrue()
		{
			Assert.IsTrue(KMP.Contains("AAACAAAA", "AAACAAAA"));
		}

		[TestMethod]
		public void Contains_SubstringMatchNoBackTracking_ReturnsTrue()
		{
			Assert.IsTrue(KMP.Contains("ab", "jdhfgfabsdkfh"));
		}

		[TestMethod]
		public void Contains_NoMatch_ReturnsFalse()
		{
			Assert.IsFalse(KMP.Contains("ab", "vvvvvvv"));
		}

		[TestMethod]
		public void Contains_MatchWithTableLookup_ReturnsTrue()
		{
			Assert.IsTrue(KMP.Contains("AAACAAAA", "AAAAACAAAA"));
		}


		[TestMethod]
		public void Find_PerfectMatch_ReturnsTrue()
		{
			Assert.AreEqual(KMP.Find("AAACAAAA", "AAACAAAA"), 0);
		}

		[TestMethod]
		public void Find_SubstringMatchNoBackTracking_ReturnsTrue()
		{
			Assert.AreEqual(KMP.Find("ab", "jdhfgfabsdkfh"), 6);
		}

		[TestMethod]
		public void Find_NoMatch_ReturnsFalse()
		{
			Assert.AreEqual(KMP.Find("ab", "vvvvvvv"), -1);
		}

		[TestMethod]
		public void Find_MatchWithTableLookup_ReturnsTrue()
		{
			Assert.AreEqual(KMP.Find("AAACAAAA", "AAAAACAAAA"), 2);
		}


		[TestMethod]
		public void Find_MatchSubstringWithTableLookup_ReturnsTrue()
		{
			Assert.AreEqual(KMP.Find("ababab", "abacaabababab"), 5);
		}

		[TestMethod]
		public void BuildTable_NoPrefixes()
		{
			int[] expected = new[] { 0, 0, 0, 0, 0 };
			var pattern = "asdfg";
			var result = KMP.BuildLookupTable(pattern);
			CollectionAssert.AreEqual(result, expected);
		}


		[TestMethod]
		public void BuildTable_TwoPrefixes()
		{
			int[] expected = new[] { 0, 0, 1, 0, 1 };
			var pattern = "aacaa";
			var result = KMP.BuildLookupTable(pattern);
			CollectionAssert.AreEqual(result, expected);
		}

		[TestMethod]
		public void BuildTable_LargePrefix()
		{
			int[] expected = new[] { 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5 };
			var pattern = "abcdefabcdef";
			var result = KMP.BuildLookupTable(pattern);
			CollectionAssert.AreEqual(result, expected);
		}
	}
}

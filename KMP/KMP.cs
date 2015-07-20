using System;
namespace StringSearch
{
	public static class KMP
	{

		public static bool Contains(string pattern, string text)
		{
			return Find(pattern, text) != -1;
		}
		public static int Find(String pattern, String text)
		{
			int[] lookup_table = BuildLookupTable(pattern);
			int patternPos = 0;
			for (int textPos = 0; textPos < text.Length; textPos++)
			{
				if (patternPos > 0 && pattern[patternPos] != text[textPos])
					patternPos = lookup_table[patternPos];

				if (pattern[patternPos] == text[textPos])
				{
					patternPos++;
				}

				if (patternPos == pattern.Length)
					return textPos - (pattern.Length - 1);
			}

			return -1;
		}

		public static int[] BuildLookupTable(String pattern)
		{
			var lookup_table = new int[pattern.Length];
			lookup_table[0] = -1;
			for (int pos = 1; pos < pattern.Length; pos++)
			{
				int i = lookup_table[pos - 1];
				while (i >= 0 && pattern[i] != pattern[pos - 1])
					i = lookup_table[i];
				lookup_table[pos] = i + 1;
			}
			lookup_table[0] = 0;
			return lookup_table;
		}
	}
}

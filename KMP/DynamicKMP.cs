using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearch
{
	public static class DynamicKMP
	{
		/*
		 * Standard KMP string match algorithm, with the variation that lookup table values are not calculated unless they are needed.
		 */
		public static bool KMP(String pattern, String text)
		{
			int[] lookup_table = buildLookupTable(pattern);
			int patternPos = 0;
			for (int textPos = 0; textPos < text.Length; textPos++)
			{
				if (patternPos > 0 && pattern[patternPos] != text[textPos])
				{
					if (lookup_table[patternPos] == -2)
						updateField(pattern, lookup_table, patternPos);
					patternPos = lookup_table[patternPos];
				}
				if (pattern[patternPos] == text[textPos])
				{
					patternPos++;
				}

				if (patternPos == pattern.Length)
					return true;
			}

			return false;
		}

		/*
		 * Sets up the table and initializes all values to -2 to signifiy that they haven't been set
		 */
		static int[] buildLookupTable(String pattern)
		{
			var lookup_table = new int[pattern.Length];
			lookup_table = new int[pattern.Length];
			for (int i = 0; i < lookup_table.Count(); i++)
				lookup_table[i] = -2;

			lookup_table[0] = 0;
			return lookup_table;
		}

		/*
		 * Finds the lookup table value of the desired position in the pattern.
		 * If it needs a value that hasn't been set, it recursively sets it.
		 * 
		 */
		static void updateField(String pattern, int[] lookup_table, int pos)
		{
			lookup_table[0] = -1;
			if (lookup_table[pos - 1] == -2)
				updateField(pattern, lookup_table, pos - 1);
			int i = lookup_table[pos - 1];

			while (i >= 0 && pattern[i] != pattern[pos - 1])
			{
				if (lookup_table[i] == -2)
					updateField(pattern, lookup_table, i);
				i = lookup_table[i];
			}
			lookup_table[pos] = i + 1;
		}
	}
}


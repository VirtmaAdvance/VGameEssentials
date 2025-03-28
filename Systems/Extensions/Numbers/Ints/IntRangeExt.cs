using VGameEssentials.Systems.Extensions.Arrays;

namespace VGameEssentials.Systems.Extensions.Numbers.Ints
{
	/// <summary>
	/// Provides range validation extension methods.
	/// </summary>
	public static class IntRangeExt
	{
		/// <summary>
		/// Determines if the <paramref name="source"/> value is equal to or between both the <paramref name="min"/> and <paramref name="max"/> values.
		/// </summary>
		/// <param name="source">The value to analyze.</param>
		/// <param name="min">The minimum value allowed for the <paramref name="source"/> to be.</param>
		/// <param name="max">The maximum value allowed for the <paramref name="source"/> to be.</param>
		/// <returns>a <see cref="bool"/> representation where <see cref="bool">true</see> results in success, otherwise <see cref="bool">false</see>.</returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static bool IsBetween(this int source, int min, int max)
		{
			if (min > max)
				throw new ArgumentOutOfRangeException("The given minimum value is larger than the given maximum value.");
			if (min == max)
				throw new ArgumentOutOfRangeException("The given minimum value cannot be equal to the given maximum value.");
			return source >= min && source <= max;
		}
		/// <summary>
		/// Determines which of the given <paramref name="values"/> the <paramref name="source"/> value is closest to by calculating the differences between each value.
		/// </summary>
		/// <param name="source">The number to analyze.</param>
		/// <param name="values">The numbers to test against.</param>
		/// <returns>the numeric value </returns>
		public static int GetClosestValue(this int source, params int[] values)
		{
			KeyValuePair<int, int>[] differences = [];
			foreach (var value in values)
				differences = differences.Add(new((int)(Math.Max(value, source) - Math.Min(value, source)), value));
			Array.Sort(differences);
			return differences.FirstOrDefault().Value;
		}

	}
}

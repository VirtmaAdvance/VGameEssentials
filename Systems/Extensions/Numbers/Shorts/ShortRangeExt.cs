using VGameEssentials.Systems.Extensions.Arrays;

namespace VGameEssentials.Systems.Extensions.Numbers.Shorts
{
	/// <summary>
	/// Provides range validation extension methods.
	/// </summary>
	public static class ShortRangeExt
	{
		/// <inheritdoc cref="Ints.IntRangeExt.IsBetween(int, int, int)"/>
		public static bool IsBetween(this short source, short min, short max)
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
		public static short GetClosestValue(this short source, params short[] values)
		{
			KeyValuePair<short, short>[] differences = [];
			foreach (var value in values)
				differences = differences.Add(new((short)(Math.Max(value, source) - Math.Min(value, source)), value));
			Array.Sort(differences);
			return differences.FirstOrDefault().Value;
		}
	}
}

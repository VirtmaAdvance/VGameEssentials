using VGameEssentials.Systems.Extensions.Arrays;

namespace VGameEssentials.Systems.Extensions.Numbers.Doubles
{
	/// <summary>
	/// Provides range validation extension methods.
	/// </summary>
	public static class DoubleRangeExt
	{
		/// <inheritdoc cref="Ints.IntRangeExt.IsBetween(int, int, int)"/>
		public static bool IsBetween(this double source, double min, double max)
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
		public static double GetClosestValue(this double source, params double[] values)
		{
			KeyValuePair<double, double>[] differences = [];
			foreach (var value in values)
				differences = differences.Add(new((double)(Math.Max(value, source) - Math.Min(value, source)), value));
			Array.Sort(differences);
			return differences.FirstOrDefault().Value;
		}
	}
}

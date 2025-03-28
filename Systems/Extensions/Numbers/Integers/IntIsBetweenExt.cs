namespace VGameEssentials.Systems.Extensions.Numbers.Integers
{
	/// <summary>
	/// Provides range validation extension methods.
	/// </summary>
	public static class IntIsBetweenExt
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

	}
}

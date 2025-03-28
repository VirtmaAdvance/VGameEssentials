namespace VGameEssentials.Systems.Extensions.Numbers.Longs
{
	/// <summary>
	/// Provides range validation extension methods.
	/// </summary>
	public static class LongRangeExt
	{
		/// <inheritdoc cref="Ints.IntRangeExt.IsBetween(int, int, int)"/>
		public static bool IsBetween(this long source, long min, long max)
		{
			if (min > max)
				throw new ArgumentOutOfRangeException("The given minimum value is larger than the given maximum value.");
			if (min == max)
				throw new ArgumentOutOfRangeException("The given minimum value cannot be equal to the given maximum value.");
			return source >= min && source <= max;
		}
	}
}

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
	}
}

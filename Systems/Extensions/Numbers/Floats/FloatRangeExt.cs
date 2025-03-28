namespace VGameEssentials.Systems.Extensions.Numbers.Floats
{
	/// <summary>
	/// Provides range validation extension methods.
	/// </summary>
	public static class FloatRangeExt
	{
		/// <inheritdoc cref="Ints.IntRangeExt.IsBetween(int, int, int)"/>
		public static bool IsBetween(this float source, float min, float max)
		{
			if (min > max)
				throw new ArgumentOutOfRangeException("The given minimum value is larger than the given maximum value.");
			if (min == max)
				throw new ArgumentOutOfRangeException("The given minimum value cannot be equal to the given maximum value.");
			return source >= min && source <= max;
		}
	}
}

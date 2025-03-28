namespace VGameEssentials.Systems.Extensions.Numbers.Bytes
{
	/// <summary>
	/// Provides range validation extension methods.
	/// </summary>
	public static class ByteRangeExt
	{
		/// <inheritdoc cref="Integers.IntRangeExt.IsBetween(int, int, int)"/>
		public static bool IsBetween(this byte source, byte min, byte max)
		{
			if (min > max)
				throw new ArgumentOutOfRangeException("The given minimum value is larger than the given maximum value.");
			if (min == max)
				throw new ArgumentOutOfRangeException("The given minimum value cannot be equal to the given maximum value.");
			return source >= min && source <= max;
		}

	}
}

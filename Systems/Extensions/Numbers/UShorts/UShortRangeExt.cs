﻿namespace VGameEssentials.Systems.Extensions.Numbers.UShorts
{
	/// <summary>
	/// Provides range validation extensions.
	/// </summary>
	public static class UShortRangeExt
	{
		/// <inheritdoc cref="Ints.IntRangeExt.IsBetween(int, int, int)"/>
		public static bool IsBetween(this ushort source, ushort min, ushort max)
		{
			if (min > max)
				throw new ArgumentOutOfRangeException("The given minimum value is larger than the given maximum value.");
			if (min == max)
				throw new ArgumentOutOfRangeException("The given minimum value cannot be equal to the given maximum value.");
			return source >= min && source <= max;
		}
	}
}

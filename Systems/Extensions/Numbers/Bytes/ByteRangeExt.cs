﻿using VGameEssentials.Systems.Extensions.Arrays;

namespace VGameEssentials.Systems.Extensions.Numbers.Bytes
{
	/// <summary>
	/// Provides range validation extension methods.
	/// </summary>
	public static class ByteRangeExt
	{
		/// <inheritdoc cref="Ints.IntRangeExt.IsBetween(int, int, int)"/>
		public static bool IsBetween(this byte source, byte min, byte max)
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
		public static byte GetClosestValue(this byte source, params byte[] values)
		{
			KeyValuePair<byte, byte>[] differences = [];
			foreach (var value in values)
				differences = differences.Add(new ((byte)(Math.Max(value, source) - Math.Min(value, source)), value) );
			Array.Sort(differences);
			return differences.FirstOrDefault().Value;
		}

	}
}

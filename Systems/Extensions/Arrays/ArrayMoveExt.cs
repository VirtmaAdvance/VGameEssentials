using VGameEssentials.Systems.Extensions.Numbers.Ints;

namespace VGameEssentials.Systems.Extensions.Arrays
{
	/// <summary>
	/// Provides array item movement extension methods.
	/// </summary>
	public static class ArrayMoveExt
	{
		/// <summary>
		/// Moves the value at the <paramref name="fromIndex"/> position to the <paramref name="toIndex"/> position within the array.
		/// </summary>
		/// <typeparam name="T">The data-type of the items within the array.</typeparam>
		/// <param name="source">The source array to process.</param>
		/// <param name="fromIndex">The index position of the value that will be moved to the <paramref name="toIndex"/> position.</param>
		/// <param name="toIndex">The index position of the value that will be moved to the <paramref name="fromIndex"/> position.</param>
		/// <returns>the modified array.</returns>
		public static T?[] Move<T>(this T?[]? source, int fromIndex, int toIndex)
		{
			source ??= [];
			T? valueAtFromIndex, valueAtToIndex;
			var sourceMaxIndexableValue = source.Length - 1;
			int lowestIndexValue = Math.Min(fromIndex, toIndex);
			int highestIndexValue = Math.Max(fromIndex, toIndex);
			lowestIndexValue = Math.Min(lowestIndexValue, highestIndexValue).GetClosestValue(0, sourceMaxIndexableValue); // The lowest possible index.
			highestIndexValue = Math.Max(lowestIndexValue, highestIndexValue); // The highest index specified by the caller.
			if (!fromIndex.IsBetween(0, sourceMaxIndexableValue))
				fromIndex = fromIndex.GetClosestValue(0, sourceMaxIndexableValue);
			if (!toIndex.IsBetween(0, sourceMaxIndexableValue))
				Array.Resize(ref source, source.Length + (Math.Max(highestIndexValue, sourceMaxIndexableValue) - Math.Min(highestIndexValue, sourceMaxIndexableValue)));
			valueAtFromIndex = source[fromIndex];
			valueAtToIndex = source[toIndex];
			source[toIndex] = valueAtFromIndex;
			source[fromIndex] = valueAtToIndex;
			return source;
		}

	}
}

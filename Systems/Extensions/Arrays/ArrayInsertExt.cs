namespace VGameEssentials.Systems.Extensions.Arrays
{
	/// <summary>
	/// Provides insertion extension methods for arrays.
	/// </summary>
	public static class ArrayInsertExt
	{
		/// <summary>
		/// Inserts the <paramref name="item"/> into the <paramref name="source"/> array (Invokes Shift and Move extension methods).
		/// </summary>
		/// <typeparam name="T">The data-type of the items within the source array.</typeparam>
		/// <param name="source">The array to process.</param>
		/// <param name="item">The item to insert into the array.</param>
		/// <param name="indexPositionToSetItemAt">The index position to insert the <paramref name="item"/> at.</param>
		/// <returns>the modified array.</returns>
		public static T?[] Insert<T>(this T?[]? source, T? item, int indexPositionToSetItemAt)
		{
			if (source is null)
				source = [];
			source = source.Shift(indexPositionToSetItemAt, 1);
			source[indexPositionToSetItemAt] = item;
			return source;
		}

	}
}

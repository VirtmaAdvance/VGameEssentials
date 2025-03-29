namespace VGameEssentials.Systems.Extensions.Arrays
{
	/// <summary>
	/// Provides item shifting extensions for arrays.
	/// </summary>
	public static class ArrayShiftExt
	{
		/// <summary>
		/// Shifts all items within the array starting from the <paramref name="startingIndex"/> to the right by <paramref name="nth"/> many times
		/// </summary>
		/// <typeparam name="T">The data-type of the items within the array.</typeparam>
		/// <param name="source">The array to process.</param>
		/// <param name="startingIndex">The index position to start shifting everything (Includes the starting index position).</param>
		/// <param name="nth">Specifies the number of times to shift everything to the right (This will result in some values bein null).</param>
		/// <returns>the modified array.</returns>
		public static T?[] Shift<T>(this T?[]? source, int startingIndex, int nth)
		{
			if (source is null)
				source = [];
			for (int i = source.Length - 1; i > (startingIndex - 1); i--)
				source = source.Move(i, i++);
			return source;
		}

	}
}

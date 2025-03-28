namespace VGameEssentials.Systems.Extensions.Arrays
{
	/// <summary>
	/// Provides counting extension methods for array objects.
	/// </summary>
	public static class ArrayCountExt
	{
		/// <summary>
		/// Gets the number of items that pass the predicate results.
		/// </summary>
		/// <typeparam name="T">The data type of the array items.</typeparam>
		/// <param name="source">The array to iterate through.</param>
		/// <param name="predicate">The predicate to test each item within the array.</param>
		/// <returns>the number of matched items in the <paramref name="source"/> represented as an <see cref="int"/>.</returns>
		public static int Count<T>(this T?[]? source, Func<T?, bool> predicate)
		{
			if (source is null)
				return 0;
			int res = 0;
			foreach(var sel in source)
				if (predicate(sel))
					res++;
			return res;
		}

	}
}

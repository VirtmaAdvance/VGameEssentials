using VGameEssentials.Systems.Extensions.Objects;

namespace VGameEssentials.Systems.Extensions.Arrays
{
	/// <summary>
	/// Provides array item removal extension methods for arrays.
	/// </summary>
	public static class ArrayRemoveExt
	{
		/// <summary>
		/// Removes an item from the source array.
		/// </summary>
		/// <typeparam name="T">The data type of the array items.</typeparam>
		/// <param name="source">The array to iterate.</param>
		/// <param name="item">The item to remove.</param>
		/// <returns>the modified array.</returns>
		public static T?[] Remove<T>(this T?[]? source, T? item)
		{
			if (source is null)
				return [];
			return source.Prv_Remove(item);
		}
		/// <inheritdoc cref="Remove{T}(T[], T)"/>
		public static T?[] RemoveRange<T>(this T?[]? source, params T?[]? values)
		{
			if (source is null)
				return [];
			if (values is null)
				return source;
			foreach (var value in values)
				source = source.Prv_Remove(value);
			return source;
		}
		/// <inheritdoc cref="Remove{T}(T[], T)" path="/*"/>
		/// <param name="source">The array to iterate.</param>
		/// <param name="index">The index position to remove.</param>
		public static T?[] RemoveAt<T>(this T?[]? source, int index) => source is null ? [] : source.Prv_RemoveAt(index);
		/// <summary>
		/// Removes all items in the <paramref name="source"/> array where the predicate results to <see cref="bool">true</see>.
		/// </summary>
		/// <typeparam name="T">The data type of the items within the array.</typeparam>
		/// <param name="source">The array to iterate through.</param>
		/// <param name="predicate">The predicate function to perform on each element in the array.</param>
		/// <returns>the modified array.</returns>
		public static T?[] RemoveIf<T>(this T?[]? source, Func<T?, bool> predicate)
		{
			if (source is null)
				return [];
			T?[] res = [];
			foreach(var sel in source)
				if(predicate(sel))
					res=res.Remove(sel);
			return res;
		}

		private static T?[] Prv_RemoveAt<T>(this T?[] source, int index)
		{
			T?[] res = [];
			for (int i = 0; i < source.Length; i++)
				if (i != index)
					res = res.Add(source[i]);
			return res;
		}

		private static T?[] Prv_Remove<T>(this T?[] source, T? item)
		{
			T?[] res = [];
			foreach(var sel in source)
				if(!sel.IsEqualTo(item))
					res=res.Add(sel);
			return res;
		}

	}
}

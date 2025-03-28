namespace VGameEssentials.Systems.Extensions.Arrays
{
	/// <summary>
	/// Provides item adding extension methods for array objects.
	/// </summary>
	public static class ArrayAddExt
	{
		/// <summary>
		/// Adds an item to the source array.
		/// </summary>
		/// <typeparam name="T">The data type of the elements within the array.</typeparam>
		/// <param name="source">The source array to use.</param>
		/// <param name="value">The value to add to the end of the array.</param>
		/// <returns>the modified array.</returns>
		public static T?[] Add<T>(this T[]? source, T? value)
		{
			if (source is null)
				source = [];
			return source.Prv_Add(value);
		}
		/// <inheritdoc cref="Add{T}(T[], T)"/>
		public static T?[] AddRange<T>(this T?[]? source, params T?[]? values)
		{
			if(source is null)
				source = [];
			if(values is null)
				values = [];
			foreach(var value in values)
				source=source.Prv_Add(value);
			return source;
		}

		private static T?[] Prv_Add<T>(this T?[] source, T value)
		{
			Array.Resize(ref source, source.Length + 1);
			source[^1] = value;
			return source;
		}

	}
}

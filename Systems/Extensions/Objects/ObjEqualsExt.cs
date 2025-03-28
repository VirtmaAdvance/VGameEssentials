namespace VGameEssentials.Systems.Extensions.Objects
{
	/// <summary>
	/// Provides equals comparison extension methods for objects.
	/// </summary>
	public static class ObjEqualsExt
	{
		/// <summary>
		/// Determines if the source object is equal to the given <paramref name="value"/> (Null-safe comparison).
		/// </summary>
		/// <param name="source">The source object to use.</param>
		/// <param name="value">The object to compare to.</param>
		/// <returns>a <see cref="bool"/> representation where <see cref="bool">true</see> results in success, otherwise <see cref="bool">false</see>.</returns>
		public static bool IsEqualTo(this object? source, object? value)
		{
			if (source is null && value is null)
				return true;
			if ((source is not null && value is null) || (source is null && value is not null))
				return false;
			return source!.Equals(value);
		}

	}
}

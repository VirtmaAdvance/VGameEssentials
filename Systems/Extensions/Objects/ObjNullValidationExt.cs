namespace VGameEssentials.Systems.Extensions.Objects
{
	/// <summary>
	/// Provides extension methods for null validation checks for objects.
	/// </summary>
	public static class ObjNullValidationExt
	{
		/// <summary>
		/// Determines if the given <paramref name="source"/> is <see langword="null"/> or not.
		/// </summary>
		/// <param name="source">The <see cref="object"/> to analyze.</param>
		/// <returns>a<see cref="bool"/> representation where<see cref="bool">true</see> results in success, otherwise<see cref="bool">false</see>.</returns>
		public static bool IsNull(this object? source) => source is null;
		/// <inheritdoc cref="IsNull(object)"/>
		public static bool NotNull(this object? source) => source is not null;

	}
}

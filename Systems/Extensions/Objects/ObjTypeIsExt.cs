﻿using VGameEssentials.Systems.Extensions.Types;

namespace VGameEssentials.Systems.Extensions.Objects
{
	/// <summary>
	/// Provides data-type validation extension methods for objects.
	/// </summary>
	public static class ObjTypeIsExt
	{
		/// <inheritdoc cref="TypeIsExt.IsOfAny(Type, Type[])"/>
		public static bool IsOfAny<T>(this T? source, params Type[]? targetTypes) => source is null ? false : TypeIsExt.IsOfAny(source.GetType(), targetTypes);
		/// <inheritdoc cref="TypeIsExt.IsOfAny(Type, string[])"/>
		public static bool IsOfAny<T>(this T? source, params string[]? targetTypes) => source is null ? false : TypeIsExt.IsOfAny(source.GetType(), targetTypes);
		/// <inheritdoc cref="TypeIsExt.IsOfAll(Type, Type[])"/>
		public static bool IsOfAll<T>(this T? source, params Type[]? targetTypes) => source is null ? false : TypeIsExt.IsOfAll(source.GetType(), targetTypes);
		/// <inheritdoc cref="TypeIsExt.IsOfAll(Type, string[])"/>
		public static bool IsOfAll<T>(this T? source, params string[]? targetTypes) => source is null ? false : TypeIsExt.IsOfAll(source.GetType(), targetTypes);
		/// <inheritdoc cref="TypeIsExt.GetInheritences(Type, Type[])"/>
		public static Type[]? GetInheritences<T>(this T? source, params Type[]? targetTypes) => source is null ? null : TypeIsExt.GetInheritences(source.GetType(), targetTypes);
		/// <inheritdoc cref="TypeIsExt.GetInheritences(Type, string[])"/>
		public static Type[]? GetInheritences<T>(this T? source, params string[]? targetTypes) => source is null ? null : TypeIsExt.GetInheritences(source.GetType(), targetTypes);
		/// <summary>
		/// Determines if the given <paramref name="source"/> is a numeric data-type.
		/// </summary>
		/// <param name="source">The value to analyze.</param>
		/// <returns>a<see cref="bool"/> representation where<see cref="bool">true</see> results in success, otherwise<see cref="bool">false</see>.</returns>
		public static bool IsNumber(this object? source) => source.IsOfAny("sbyte", "byte", "ushort", "short", "uint", "int", "ulong", "long", "float", "double");

	}
}

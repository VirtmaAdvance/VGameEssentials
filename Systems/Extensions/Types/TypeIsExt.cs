using VGameEssentials.Systems.Extensions.Arrays;

namespace VGameEssentials.Systems.Extensions.Types
{
	/// <summary>
	/// Provides validation extension methods for data type checking.
	/// </summary>
	public static class TypeIsExt
	{
		/// <summary>
		/// Determines if the <paramref name="sourceType"/> inherits from any of the <paramref name="targetTypes"/>.
		/// </summary>
		/// <param name="sourceType">The source data-type to analyze.</param>
		/// <param name="targetTypes">The list of types to match against.</param>
		/// <returns>a <see cref="bool"/> representation where <see cref="bool">true</see> results in success, otherwise <see cref="bool">false</see>.</returns>
		public static bool IsOfAny(this Type sourceType, params Type[]? targetTypes) => targetTypes is null ? false : targetTypes.Any(targetType => targetType.IsAssignableFrom(sourceType));
		/// <inheritdoc cref="IsOfAny(Type, Type[])"/>
		public static bool IsOfAny(this Type sourceType, params string[]? targetTypes) => targetTypes is null ? false : targetTypes.Any(typeName => Type.GetType(typeName)?.IsAssignableFrom(sourceType)??false);
		/// <inheritdoc cref="IsOfAny(Type, Type[])" path="/returns | /param"/>
		/// <summary>
		/// Determines if the <paramref name="sourceType"/> inherits from all of the <paramref name="targetTypes"/>.
		/// </summary>
		public static bool IsOfAll(this Type sourceType, params Type[]? targetTypes) => targetTypes is null ? false : targetTypes.All(targetType => targetType.IsAssignableFrom(sourceType));
		/// <inheritdoc cref="IsOfAll(Type, Type[])"/>
		public static bool IsOfAll(this Type sourceType, params string[]? targetTypes) => targetTypes is null ? false : targetTypes.All(typeName => Type.GetType(typeName)?.IsAssignableFrom(sourceType)??false);
		/// <summary>
		/// Gets an array of all <see cref="Type"/> objects that the <paramref name="sourceType"/> inherits from.
		/// </summary>
		/// <param name="sourceType">The <see cref="Type"/> object to analyze.></param>
		/// <param name="targetTypes">The types to look for.</param>
		/// <returns>array of <see cref="Type"/>s that were found matching as a parent of the <paramref name="sourceType"/>.</returns>
		public static Type[]? GetInheritences(this Type sourceType, params Type[]? targetTypes)
		{
			if (sourceType is null)
				return null;
			if (targetTypes is null)
				targetTypes = [];
			Type[] res = [];
			if (targetTypes.Length == 0)
			{
				Type? parentType = sourceType.BaseType;
				while(parentType is not null)
					res = res.Add(parentType.BaseType)!;
			}
			else
			{
				foreach (var targetType in targetTypes)
					if (targetType.IsAssignableFrom(sourceType))
						res = res.Add(targetType)!;
			}
			return res;
		}
		/// <summary>
		/// Gets an array of all <see cref="Type"/> objects that the <paramref name="sourceType"/> inherits from.
		/// </summary>
		/// <param name="sourceType">The <see cref="Type"/> object to analyze.></param>
		/// <param name="targetTypes">The types to look for.</param>
		/// <returns>array of <see cref="Type"/>s that were found matching as a parent of the <paramref name="sourceType"/>.</returns>
		public static Type[]? GetInheritences(this Type sourceType, params string[]? targetTypes)
		{
			if (sourceType is null)
				return null;
			if (targetTypes is null)
				targetTypes = [];
			Type[] res = [];
			if (targetTypes.Length == 0)
			{
				Type? parentType = sourceType.BaseType;
				while (parentType is not null)
					res = res.Add(parentType.BaseType)!;
			}
			else
				foreach (var targetType in targetTypes)
				{
					var selType = Type.GetType(targetType);
					if (selType is not null && selType.IsAssignableFrom(sourceType))
						res = res.Add(selType)!;
				}
			return res;
		}

	}
}

namespace VGameEssentials.Systems.Collections
{
	/// <summary>
	/// Provides collection modification information.
	/// </summary>
	/// <remarks>
	/// Creates a new instance of the <see cref="CollectionModifiedArgs"/> class.
	/// </remarks>
	/// <param name="actionType">The modification action performed on the collection.</param>
	/// <param name="value">The value that was affected.</param>
	/// <param name="index">The index position that was affected.</param>
	/// <param name="length">The last index in the collection that was or would be affected (Only applicable for insertion, moving, and shifting actions).</param>
	public class CollectionModifiedArgs(CollectionModificationType actionType, object? value, int? index = null, int? length = null) : EventArgs
    {
        /// <summary>
        /// The action performed on the collection.
        /// </summary>
        public readonly CollectionModificationType Action = actionType;
        /// <summary>
        /// The index position that was affected.
        /// </summary>
        public readonly int? Index = index;
        /// <summary>
        /// The last index in the collection that was or would be affected (Only applicable for insertion, moving, and shifting actions).
        /// </summary>
        public readonly int? Length = length;
        /// <summary>
        /// The value being inserted, added, removed, moved, or shifted.
        /// </summary>
        public readonly object? Value = value;
	}
}

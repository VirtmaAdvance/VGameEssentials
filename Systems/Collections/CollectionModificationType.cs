namespace VGameEssentials.Systems.Collections
{
	/// <summary>
	/// Defines the modification types that a collection can perform.
	/// </summary>
	[Flags]
	public enum CollectionModificationType : byte
	{
		/// <summary>
		/// No action was specified.
		/// </summary>
		None,
		/// <summary>
		/// A single item was added to the collection.
		/// </summary>
		Added,
		/// <summary>
		/// Multiple items were added to the collection.
		/// </summary>
		MultiAdd,
		/// <summary>
		/// A single item was removed from the collection.
		/// </summary>
		Removed,
		/// <summary>
		/// Multiple items were removed from the collection.
		/// </summary>
		MultiRemove,
		/// <summary>
		/// The collection was cleared.
		/// </summary>
		Cleared,
		/// <summary>
		/// An item was inserted into the collection.
		/// </summary>
		Inserted,
		/// <summary>
		/// An item or items were moved within the collection.
		/// </summary>
		Moved,
		/// <summary>
		/// An item or items were shifted within the collection.
		/// </summary>
		Shifted,

	}
}

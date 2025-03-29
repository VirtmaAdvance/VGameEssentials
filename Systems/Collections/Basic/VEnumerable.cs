using System.Collections;
using VGameEssentials.Systems.Extensions.Arrays;
using VGameEssentials.Systems.Extensions.Objects;

namespace VGameEssentials.Systems.Collections.Basic
{
	/// <summary>
	/// A base class used to create custom collections with event listeners when the collection is modified.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class VEnumerable<T> : IEnumerable, IEnumerable<T>
	{
		/// <summary>
		/// Invoked if the collection directly changes a value of an existing item within the collection.
		/// </summary>
		public event EventHandler<CollectionModifiedArgs>? Modified;
		/// <summary>
		/// Invoked if the collection adds an item.
		/// </summary>
		public event EventHandler<CollectionModifiedArgs>? Added;
		/// <summary>
		/// Invoked if the collection removes an item.
		/// </summary>
		public event EventHandler<CollectionModifiedArgs>? Removed;
		/// <summary>
		/// Invoked if the collection was cleared.
		/// </summary>
		public event EventHandler<CollectionModifiedArgs>? Cleared;
		/// <summary>
		/// Invoked if the collection inserted an item.
		/// </summary>
		public event EventHandler<CollectionModifiedArgs>? Inserted;

		private T?[] _items = [];
		/// <summary>
		/// The collection of items.
		/// </summary>
		protected T?[] Items
		{
			get => _items;
			set
			{
				if(value is null)
					throw new ArgumentNullException(nameof(value));
				_items = value;
			}
		}
		/// <summary>
		/// Gets the number of items within this collection.
		/// </summary>
		public int Length => Items.Length;
		/// <summary>
		/// Gets or sets the value at the given <paramref name="index"/> position within this collection.
		/// </summary>
		/// <param name="index">The index position to access.</param>
		/// <returns>the <typeparamref name="T"/> located at the given <paramref name="index"/> position, otherwise <see langword="null"/>.</returns>
		public T? this[int index]
		{
			get => IsIndexValid(index) ? Items[index] : default;
			set
			{
				if(index>Length-1)
					Array.Resize(ref _items, Length + (index - (Length - 1)));
				if (index < 0)
					index = 0;
				if (IsIndexValid(index))
				{
					var originalValue = Items[index];
					Items[index] = value;
					if (Modified is not null)
						Modified.Invoke(this, new CollectionModifiedArgs(CollectionModificationType.Modified, originalValue, value, index));
				}
				else
					throw new Exception("An unknown exception has occurred.");
			}
		}


		/// <summary>
		/// Adds the <paramref name="item"/> to the collection.
		/// </summary>
		/// <param name="item">The item to add.</param>
		public void Add(T item)
		{
			Prv_Add(item);
			if (Added is not null)
				Added.Invoke(this, new(CollectionModificationType.Added, null, item));
		}
		private void Prv_Add(T item) => Items = Items.Add(item)!;
		/// <summary>
		/// Adds an array of items to this collection.
		/// </summary>
		/// <param name="items">The variable length of items to add to this collection.</param>
		public void AddRange(params T[] items)
		{
			Items = Items.AddRange(items)!;
			if (Added is not null)
				Added.Invoke(this, new(CollectionModificationType.MultiAdd, null, items));
		}
		/// <summary>
		/// Purges the contents within the collection.
		/// </summary>
		public void Clear()
		{
			Items = [];
			if (Cleared is not null)
				Cleared.Invoke(this, new(CollectionModificationType.Cleared));
		}
		/// <summary>
		/// Determines if the given <paramref name="item"/> exists within this collection.
		/// </summary>
		/// <param name="item">The item to search for.</param>
		/// <returns>a <see cref="bool"/> representation where <see cref="bool">true</see> results in success, otherwise the <paramref name="item"/> was not found within the collection.</returns>
		public bool Contains(T item) => Items.Contains(item);
		/// <summary>
		/// Gets the index position of the first matching item in the collection.
		/// </summary>
		/// <param name="item">The item to look for.</param>
		/// <returns>the index position representing the location within the collection the <paramref name="item"/> is at.</returns>
		public int IndexOf(T? item)
		{
			for (int i = 0; i < Length; i++)
				if (Items[i].IsEqualTo(item))
					return i;
			return -1;
		}
		/// <summary>
		/// Determines if the given <paramref name="index"/> references an acceptable index position for this collection.
		/// </summary>
		/// <param name="index">The index position to validate.</param>
		/// <returns>a <see cref="bool"/> representation where <see cref="bool">true</see> results in success, otherwise <see cref="bool">false</see>.</returns>
		protected bool IsIndexValid(int index) => index > -1 && index < Length;
		/// <summary>
		/// Removes the <paramref name="item"/> from the collection.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		public void Remove(T item)
		{
			Items=Items.Remove(item)!;
			if (Removed is not null)
				Removed.Invoke(this, new(CollectionModificationType.Removed, item));
		}
		/// <summary>
		/// Removes the <paramref name="items"/> from the collection.
		/// </summary>
		/// <param name="items">The items to remove from the collection.</param>
		public void RemoveRange(params T[] items)
		{
			Items=Items.RemoveRange(items)!;
			if (Removed is not null)
				Removed.Invoke(this, new(CollectionModificationType.MultiRemove, items));
		}
		/// <summary>
		/// Removes an item at the given <paramref name="index"/>.
		/// </summary>
		/// <param name="index">The index position of the item to remove.</param>
		public void RemoveAt(int index)
		{
			if(IsIndexValid(index))
			{
				var originalValue = Items[index];
				Items = Items.RemoveAt(index)!;
				if (Removed is not null)
					Removed.Invoke(this, new(CollectionModificationType.Removed, originalValue, null, index));
			}
		}
		/// <summary>
		/// Sorts the collection based on its values.
		/// </summary>
		public void Sort()
		{
			Array.Sort(_items);
			if (Modified is not null)
				Modified.Invoke(this, new(CollectionModificationType.Moved));
		}

		IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
		/// <summary>
		/// Gets the enumerator for this object.
		/// </summary>
		/// <returns></returns>
		public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)Items!).GetEnumerator();
	}
}

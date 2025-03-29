using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGameEssentials.Systems.Extensions.Arrays;
using VGameEssentials.Systems.Extensions.Numbers.Ints;

namespace VGameEssentials.Systems.Collections.Basic
{
	/// <summary>
	/// A base class used to create custom collections with event listeners when the collection is modified.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class VEnumerable<T> : IEnumerable, IEnumerable<T>
	{

		private T[] _items = [];
		/// <summary>
		/// The collection of items.
		/// </summary>
		protected T[] Items
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
				Items = (IsIndexValid(index) || index.GetClosestValue(0, Length - 1) == 0 ? Items.Insert(value, index) : Items.Add(value))!;
			}
		}





		/// <summary>
		/// Adds the <paramref name="item"/> to the collection.
		/// </summary>
		/// <param name="item">The item to add.</param>
		public void Add(T item)
		{
			Prv_Add(item);
		}
		private void Prv_Add(T item) => Items = Items.Add(item)!;
		/// <summary>
		/// Adds an array of items to this collection.
		/// </summary>
		/// <param name="items">The variable length of items to add to this collection.</param>
		public void AddRange(params T[] items)
		{
			Items = Items.AddRange(items)!;
		}
		/// <summary>
		/// Purges the contents within the collection.
		/// </summary>
		public void Clear()
		{
			Items = [];
		}
		/// <summary>
		/// Determines if the given <paramref name="item"/> exists within this collection.
		/// </summary>
		/// <param name="item">The item to search for.</param>
		/// <returns>a <see cref="bool"/> representation where <see cref="bool">true</see> results in success, otherwise the <paramref name="item"/> was not found within the collection.</returns>
		public bool Contains(T item) => Items.Contains(item);
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
		}

		IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
		/// <summary>
		/// Gets the enumerator for this object.
		/// </summary>
		/// <returns></returns>
		public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)Items!).GetEnumerator();
	}
}

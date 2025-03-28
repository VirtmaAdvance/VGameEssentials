using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGameEssentials.Systems.Extensions.Arrays;

namespace VGameEssentials.Systems.Collections.Basic
{
	public class VEnumerable<T> : IEnumerable, IEnumerable<T>
	{

		private T[] _items = [];
		/// <summary>
		/// The collection of items.
		/// </summary>
		public T[] Items
		{
			get => _items;
			set
			{
				if(value is null)
					throw new ArgumentNullException(nameof(value));
				_items = value;
			}
		}

		public int Length => Items.Length;

		public T? this[int index]
		{
			get => IsIndexValid(index) ? Items[index] : default;
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
		/// Determines if the given <paramref name="item"/> exists within this collection.
		/// </summary>
		/// <param name="item">The item to search for.</param>
		/// <returns>a <see cref="bool"/> representation where <see cref="bool">true</see> results in success, otherwise the <paramref name="item"/> was not found within the collection.</returns>
		public bool Contains(T item) => Items.Contains(item);
		/// <summary>
		/// Removes the <paramref name="item"/> from the collection.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		public void Remove(T item)
		{
			Items=Items.Remove(item)!;
		}
		/// <summary>
		/// Purges the contents within the collection.
		/// </summary>
		public void Clear()
		{
			Items = [];
		}
		/// <summary>
		/// Determines if the given <paramref name="index"/> references an acceptable index position for this collection.
		/// </summary>
		/// <param name="index">The index position to validate.</param>
		/// <returns>a <see cref="bool"/> representation where <see cref="bool">true</see> results in success, otherwise <see cref="bool">false</see>.</returns>
		protected bool IsIndexValid(int index) => index > -1 && index < Length;


	}
}

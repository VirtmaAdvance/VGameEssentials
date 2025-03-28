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






		public void Add(T item)
		{
			Prv_Add(item);
		}

		private void Prv_Add(T item) => Items = Items.Add(item)!;

		public void AddRange(params T[] items)
		{
			Items = Items.AddRange(items)!;
		}

		public bool Contains(T item) => Items.Contains(item);

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

		protected bool IsIndexValid(int index) => index > -1 && index < Length;


	}
}

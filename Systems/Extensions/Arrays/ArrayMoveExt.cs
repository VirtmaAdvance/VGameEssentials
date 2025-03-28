using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGameEssentials.Systems.Extensions.Arrays
{
	public static class ArrayMoveExt
	{

		public static void Move<T>(this T?[]? source, int fromIndex, int toIndex)
		{
			if (source is null)
				source = [];
		}

	}
}

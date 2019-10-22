using System;
using System.Collections.Generic;
using System.Linq;

namespace Lazlo.Gocs
{
	internal static class ArrayPool<T>
	{
		private static readonly Dictionary<int, Stack<T[]>> free = new Dictionary<int, Stack<T[]>>();

		private static readonly HashSet<T[]> busy = new HashSet<T[]>(ReferenceEqualityComparer<T[]>.Instance);

		public static T[] New(int length)
		{
			if (!free.TryGetValue(length, out var freeOfLength))
			{
				freeOfLength = new Stack<T[]>();
				free.Add(length, freeOfLength);
			}

			if (freeOfLength.Count == 0)
			{
				freeOfLength.Push(new T[length]);
			}

			var array = freeOfLength.Pop();

			busy.Add(array);

			return array;
		}

		public static void Free(T[] array)
		{
			if (!busy.Contains(array))
			{
				throw new ArgumentException("The array to free is not in use by the pool.", nameof(array));
			}

			for (var i = 0; i < array.Length; i++)
			{
				array[i] = default(T);
			}

			busy.Remove(array);

			free[array.Length].Push(array);
		}
	}

	public static class XArrayPool
	{
		public static T[] ToArrayPooled<T>(this IEnumerable<T> source)
		{
			var array = ArrayPool<T>.New(source.Count());

			var i = 0;

			foreach (var item in source)
			{
				array[i++] = item;
			}

			return array;
		}

		public static void Free<T>(this T[] array)
		{
			ArrayPool<T>.Free(array);
		}
	}
}
using System;
using System.Collections.Generic;

namespace Lazlo.Gocs
{
	internal static class GenericPool<T> where T : class, IPoolable
	{
		private static readonly Stack<T> free = new Stack<T>();

		private static readonly HashSet<T> busy = new HashSet<T>(ReferenceEqualityComparer<T>.Instance);

		public static T New(Func<T> constructor)
		{
			if (free.Count == 0)
			{
				free.Push(constructor());
			}

			var item = free.Pop();

			item.New();

			busy.Add(item);

			return item;
		}

		public static void Free(T item)
		{
			if (!busy.Remove(item))
			{
				throw new ArgumentException("The item to free is not in use by the pool.", nameof(item));
			}

			item.Free();

			free.Push(item);
		}
	}
}
using System;
using System.Collections.Generic;

namespace Lazlo.Gocs
{
	public static class QueuePool<T>
	{
		private static readonly object @lock = new object();
		private static readonly Stack<Queue<T>> free = new Stack<Queue<T>>();
		private static readonly HashSet<Queue<T>> busy = new HashSet<Queue<T>>();

		public static Queue<T> New()
		{
			lock (@lock)
			{
				if (free.Count == 0)
				{
					free.Push(new Queue<T>());
				}

				var queue = free.Pop();

				busy.Add(queue);

				return queue;
			}
		}

		public static void Free(Queue<T> queue)
		{
			lock (@lock)
			{
				if (!busy.Contains(queue))
				{
					throw new ArgumentException("The queue to free is not in use by the pool.", nameof(queue));
				}

				queue.Clear();

				busy.Remove(queue);

				free.Push(queue);
			}
		}
	}

	public static class XQueuePool
	{
		public static Queue<T> ToQueuePooled<T>(this IEnumerable<T> source)
		{
			var queue = QueuePool<T>.New();

			foreach (var item in source)
			{
				queue.Enqueue(item);
			}

			return queue;
		}

		public static void Free<T>(this Queue<T> queue)
		{
			QueuePool<T>.Free(queue);
		}
	}
}
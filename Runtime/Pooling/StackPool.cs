using System;
using System.Collections.Generic;

namespace Lazlo.Gocs
{
	internal static class StackPool<T>
	{
		private static readonly Stack<Stack<T>> free = new Stack<Stack<T>>();

		private static readonly HashSet<Stack<T>> busy = new HashSet<Stack<T>>(ReferenceEqualityComparer<Stack<T>>.Instance);

		public static Stack<T> New()
		{
			if (free.Count == 0)
			{
				free.Push(new Stack<T>());
			}

			var stack = free.Pop();

			busy.Add(stack);

			return stack;
		}

		public static void Free(Stack<T> stack)
		{
			if (!busy.Contains(stack))
			{
				throw new ArgumentException("The stack to free is not in use by the pool.", nameof(stack));
			}

			stack.Clear();

			busy.Remove(stack);

			free.Push(stack);
		}
	}

	public static class XStackPool
	{
		public static Stack<T> ToStackPooled<T>(this IEnumerable<T> source)
		{
			var stack = StackPool<T>.New();

			foreach (var item in source)
			{
				stack.Push(item);
			}

			return stack;
		}

		public static void Free<T>(this Stack<T> stack)
		{
			StackPool<T>.Free(stack);
		}
	}
}
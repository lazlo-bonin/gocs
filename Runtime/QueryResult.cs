using System;
using System.Collections;
using System.Collections.Generic;

namespace Lazlo.Gocs
{
	/// <summary>
	/// Holds the results from a world component query.
	/// Use this in a foreach loop to enumerate over the tuples of components.
	/// </summary>
	/// <remarks>
	/// This enumerable does not allocate memory when enumerating.
	/// However, it is disposed after a single enumeration and cannot be re-enumerated.
	/// </remarks>
	/// <typeparam name="T">The type of results, either a component or a tuple of components.</typeparam>
	public sealed class QueryResult<T> : IEnumerable<T>, IPoolable, IDisposable
	{
		private readonly List<T> list = new List<T>();

		private bool isDisposed = false;

		private QueryResult() { }

		internal void Add(T result)
		{
			list.Add(result);
		}

		internal static QueryResult<T> New()
		{
			return GenericPool<QueryResult<T>>.New(() => new QueryResult<T>());
		}

		public void Dispose()
		{
			GenericPool<QueryResult<T>>.Free(this);
		}

		void IPoolable.New()
		{
			isDisposed = false;
		}

		void IPoolable.Free()
		{
			list.Clear();
			isDisposed = true;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public struct Enumerator : IEnumerator<T>
		{
			private readonly QueryResult<T> parent;

			private int index;

			private T current;

			private bool exceeded;

			public Enumerator(QueryResult<T> parent) : this()
			{
				if (parent.isDisposed)
				{
					throw new NotSupportedException("Query result was disposed.");
				}

				this.parent = parent;
			}

			public void Dispose()
			{
				parent.Dispose();
			}

			public bool MoveNext()
			{
				if (index < parent.list.Count)
				{
					current = parent.list[index];
					index++;
					return true;
				}
				else
				{
					index = parent.list.Count + 1;
					current = default(T);
					exceeded = true;
					return false;
				}
			}

			public T Current
			{
				get
				{
					if (exceeded)
					{
						throw new InvalidOperationException();
					}

					return current;
				}
			}

			object IEnumerator.Current => Current;

			void IEnumerator.Reset()
			{
				index = 0;
				exceeded = false;
			}
		}
	}
}
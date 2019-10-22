using System.Collections;
using System.Collections.Generic;

namespace Lazlo.Gocs
{
	public sealed class SystemComponents<T> : IEnumerable<T>
	{
		private readonly HashSet<T> components = new HashSet<T>();

		public bool Add(IComponent c)
		{
			return Add(c, out var ct);
		}

		public bool Remove(IComponent c)
		{
			return Remove(c, out var ct);
		}

		public bool Add(IComponent c, out T ct)
		{
			return c.gameObject.Has(out ct) && components.Add(ct);
		}

		public bool Remove(IComponent c, out T ct)
		{
			return c.gameObject.Has(out ct) && components.Remove(ct);
		}

		public HashSet<T>.Enumerator GetEnumerator() => components.GetEnumerator();

		IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public sealed class SystemComponents<T1, T2> : IEnumerable<(T1, T2)>
	{
		private readonly HashSet<(T1, T2)> components = new HashSet<(T1, T2)>();

		public bool Add(IComponent c)
		{
			return Add(c, out var c1, out var c2);
		}

		public bool Remove(IComponent c)
		{
			return Remove(c, out var c1, out var c2);
		}

		public bool Add(IComponent c, out T1 c1, out T2 c2)
		{
			return c.gameObject.Has(out c1, out c2) && components.Add((c1, c2));
		}

		public bool Remove(IComponent c, out T1 c1, out T2 c2)
		{
			return c.gameObject.Has(out c1, out c2) && components.Remove((c1, c2));
		}

		public HashSet<(T1, T2)>.Enumerator GetEnumerator() => components.GetEnumerator();

		IEnumerator<(T1, T2)> IEnumerable<(T1, T2)>.GetEnumerator() => GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public sealed class SystemComponents<T1, T2, T3> : IEnumerable<(T1, T2, T3)>
	{
		private readonly HashSet<(T1, T2, T3)> components = new HashSet<(T1, T2, T3)>();

		public bool Add(IComponent c)
		{
			return Add(c, out var c1, out var c2, out var c3);
		}

		public bool Remove(IComponent c)
		{
			return Remove(c, out var c1, out var c2, out var c3);
		}

		public bool Add(IComponent c, out T1 c1, out T2 c2, out T3 c3)
		{
			return c.gameObject.Has(out c1, out c2, out c3) && components.Add((c1, c2, c3));
		}

		public bool Remove(IComponent c, out T1 c1, out T2 c2, out T3 c3)
		{
			return c.gameObject.Has(out c1, out c2, out c3) && components.Remove((c1, c2, c3));
		}

		public HashSet<(T1, T2, T3)>.Enumerator GetEnumerator() => components.GetEnumerator();

		IEnumerator<(T1, T2, T3)> IEnumerable<(T1, T2, T3)>.GetEnumerator() => GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public sealed class SystemComponents<T1, T2, T3, T4> : IEnumerable<(T1, T2, T3, T4)>
	{
		private readonly HashSet<(T1, T2, T3, T4)> components = new HashSet<(T1, T2, T3, T4)>();

		public bool Add(IComponent c)
		{
			return Add(c, out var c1, out var c2, out var c3, out var c4);
		}

		public bool Remove(IComponent c)
		{
			return Remove(c, out var c1, out var c2, out var c3, out var c4);
		}

		public bool Add(IComponent c, out T1 c1, out T2 c2, out T3 c3, out T4 c4)
		{
			return c.gameObject.Has(out c1, out c2, out c3, out c4) && components.Add((c1, c2, c3, c4));
		}

		public bool Remove(IComponent c, out T1 c1, out T2 c2, out T3 c3, out T4 c4)
		{
			return c.gameObject.Has(out c1, out c2, out c3, out c4) && components.Remove((c1, c2, c3, c4));
		}

		public HashSet<(T1, T2, T3, T4)>.Enumerator GetEnumerator() => components.GetEnumerator();

		IEnumerator<(T1, T2, T3, T4)> IEnumerable<(T1, T2, T3, T4)>.GetEnumerator() => GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public sealed class SystemComponents<T1, T2, T3, T4, T5> : IEnumerable<(T1, T2, T3, T4, T5)>
	{
		private readonly HashSet<(T1, T2, T3, T4, T5)> components = new HashSet<(T1, T2, T3, T4, T5)>();

		public bool Add(IComponent c)
		{
			return Add(c, out var c1, out var c2, out var c3, out var c4, out var c5);
		}

		public bool Remove(IComponent c)
		{
			return Remove(c, out var c1, out var c2, out var c3, out var c4, out var c5);
		}

		public bool Add(IComponent c, out T1 c1, out T2 c2, out T3 c3, out T4 c4, out T5 c5)
		{
			return c.gameObject.Has(out c1, out c2, out c3, out c4, out c5) && components.Add((c1, c2, c3, c4, c5));
		}

		public bool Remove(IComponent c, out T1 c1, out T2 c2, out T3 c3, out T4 c4, out T5 c5)
		{
			return c.gameObject.Has(out c1, out c2, out c3, out c4, out c5) && components.Remove((c1, c2, c3, c4, c5));
		}

		public HashSet<(T1, T2, T3, T4, T5)>.Enumerator GetEnumerator() => components.GetEnumerator();

		IEnumerator<(T1, T2, T3, T4, T5)> IEnumerable<(T1, T2, T3, T4, T5)>.GetEnumerator() => GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
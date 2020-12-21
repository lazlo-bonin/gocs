using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lazlo.Gocs
{
	/// <summary>
	/// Holds a high-performance registry of components required by a system.
	/// </summary>
	/// <typeparam name="T">The type of the required component.</typeparam>
	public sealed class SystemComponents<T> : IEnumerable<T>
	{
		private readonly HashSet<T> components = new HashSet<T>();

		/// <summary>
		/// Adds the specified game object to the registry if it contains the required component and if it wasn't already added before.
		/// </summary>
		/// 
		/// <param name="go">The game object to add.</param>
		/// <returns>Whether the game object was added.</returns>
		public bool Add(GameObject go)
		{
			return Add(go, out var ct);
		}

		/// <summary>
		/// Removes the specified game object from the registry if it contains the required component and if it had been added previously.
		/// </summary>
		/// 
		/// <param name="go">The game object to remove.</param>
		/// <returns>Whether the game object was removed.</returns>
		public bool Remove(GameObject go)
		{
			return Remove(go, out var c);
		}
		
		/// <summary>
		/// Adds the specified game object to the registry if it contains the required component and if it wasn't already added before.
		/// </summary>
		/// 
		/// <param name="go">The game object to add.</param>
		/// <param name="c">The returned required component.</param>
		/// <returns>Whether the game object was added.</returns>
		public bool Add(GameObject go, out T c)
		{
			return go.Has(out c) && components.Add(c);
		}
		
		/// <summary>
		/// Removes the specified game object from the registry if it contains the required component and if it had been added previously.
		/// </summary>
		/// 
		/// <param name="go">The game object to remove.</param>
		/// <param name="c">The returned required component.</param>
		/// <returns>Whether the game object was removed.</returns>
		public bool Remove(GameObject go, out T c)
		{
			return go.Has(out c) && components.Remove(c);
		}

		public HashSet<T>.Enumerator GetEnumerator() => components.GetEnumerator();

		IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	/// <summary>
	/// Holds a high-performance registry of components required by a system.
	/// </summary>
	/// 
	/// <typeparam name="T1">The type of the first required component.</typeparam>
	/// <typeparam name="T2">The type of the second required component.</typeparam>
	public sealed class SystemComponents<T1, T2> : IEnumerable<(T1, T2)>
	{
		private readonly HashSet<(T1, T2)> components = new HashSet<(T1, T2)>();
		
		/// <summary>
		/// Adds the specified game object to the registry if it contains the required components and if it wasn't already added before.
		/// </summary>
		/// <param name="go">The game object to add.</param>
		/// <returns>Whether the game object was added.</returns>
		public bool Add(GameObject go)
		{
			return Add(go, out var c1, out var c2);
		}
		
		/// <summary>
		/// Removes the specified game object from the registry if it contains the required components and if it had been added previously.
		/// </summary>
		/// 
		/// <param name="go">The game object to remove.</param>
		/// <returns>Whether the game object was removed.</returns>
		public bool Remove(GameObject go)
		{
			return Remove(go, out var c1, out var c2);
		}

		/// <summary>
		/// Adds the specified game object to the registry if it contains the required components and if it wasn't already added before.
		/// </summary>
		/// 
		/// <param name="go">The game object to add.</param>
		/// <param name="c1">The first required component.</param>
		/// <param name="c2">The second required component.</param>
		/// <returns>Whether the game object was added.</returns>
		public bool Add(GameObject go, out T1 c1, out T2 c2)
		{
			return go.Has(out c1, out c2) && components.Add((c1, c2));
		}
		
		/// <summary>
		/// Removes the specified game object from the registry if it contains the required components and if it had been added previously.
		/// </summary>
		/// 
		/// <param name="go">The game object to remove.</param>
		/// <param name="c1">The first required component.</param>
		/// <param name="c2">The second required component.</param>
		/// <returns>Whether the game object was removed.</returns>
		public bool Remove(GameObject go, out T1 c1, out T2 c2)
		{
			return go.Has(out c1, out c2) && components.Remove((c1, c2));
		}

		public HashSet<(T1, T2)>.Enumerator GetEnumerator() => components.GetEnumerator();

		IEnumerator<(T1, T2)> IEnumerable<(T1, T2)>.GetEnumerator() => GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
	
	/// <summary>
	/// Holds a high-performance registry of components required by a system.
	/// </summary>
	/// 
	/// <typeparam name="T1">The type of the first required component.</typeparam>
	/// <typeparam name="T2">The type of the second required component.</typeparam>
	/// <typeparam name="T3">The type of the third required component.</typeparam>
	public sealed class SystemComponents<T1, T2, T3> : IEnumerable<(T1, T2, T3)>
	{
		private readonly HashSet<(T1, T2, T3)> components = new HashSet<(T1, T2, T3)>();
		
		/// <summary>
		/// Adds the specified game object to the registry if it contains the required components and if it wasn't already added before.
		/// </summary>
		/// 
		/// <param name="go">The game object to add.</param>
		/// <returns>Whether the game object was added.</returns>
		public bool Add(GameObject go)
		{
			return Add(go, out var c1, out var c2, out var c3);
		}
		
		/// <summary>
		/// Removes the specified game object from the registry if it contains the required components and if it had been added previously.
		/// </summary>
		/// 
		/// <param name="go">The game object to remove.</param>
		/// <returns>Whether the game object was removed.</returns>
		public bool Remove(GameObject go)
		{
			return Remove(go, out var c1, out var c2, out var c3);
		}
		
		/// <summary>
		/// Adds the specified game object to the registry if it contains the required components and if it wasn't already added before.
		/// </summary>
		/// 
		/// <param name="go">The game object to add.</param>
		/// <param name="c1">The first required component.</param>
		/// <param name="c2">The second required component.</param>
		/// <param name="c3">The third required component.</param>
		/// <returns>Whether the game object was added.</returns>
		public bool Add(GameObject go, out T1 c1, out T2 c2, out T3 c3)
		{
			return go.Has(out c1, out c2, out c3) && components.Add((c1, c2, c3));
		}
		
		/// <summary>
		/// Removes the specified game object from the registry if it contains the required components and if it had been added previously.
		/// </summary>
		/// 
		/// <param name="go">The game object to remove.</param>
		/// <param name="c1">The first required component.</param>
		/// <param name="c2">The second required component.</param>
		/// <param name="c3">The third required component.</param>
		/// <returns>Whether the game object was removed.</returns>
		public bool Remove(GameObject go, out T1 c1, out T2 c2, out T3 c3)
		{
			return go.Has(out c1, out c2, out c3) && components.Remove((c1, c2, c3));
		}

		public HashSet<(T1, T2, T3)>.Enumerator GetEnumerator() => components.GetEnumerator();

		IEnumerator<(T1, T2, T3)> IEnumerable<(T1, T2, T3)>.GetEnumerator() => GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
	
	/// <summary>
	/// Holds a high-performance registry of components required by a system.
	/// </summary>
	/// 
	/// <typeparam name="T1">The type of the first required component.</typeparam>
	/// <typeparam name="T2">The type of the second required component.</typeparam>
	/// <typeparam name="T3">The type of the third required component.</typeparam>
	/// <typeparam name="T4">The type of the fourth required component.</typeparam>
	public sealed class SystemComponents<T1, T2, T3, T4> : IEnumerable<(T1, T2, T3, T4)>
	{
		private readonly HashSet<(T1, T2, T3, T4)> components = new HashSet<(T1, T2, T3, T4)>();
		
		/// <summary>
		/// Adds the specified game object to the registry if it contains the required components and if it wasn't already added before.
		/// </summary>
		/// 
		/// <param name="go">The game object to add.</param>
		/// <returns>Whether the game object was added.</returns>
		public bool Add(GameObject go)
		{
			return Add(go, out var c1, out var c2, out var c3, out var c4);
		}
		
		/// <summary>
		/// Removes the specified game object from the registry if it contains the required components and if it had been added previously.
		/// </summary>
		/// 
		/// <param name="go">The game object to remove.</param>
		/// <returns>Whether the game object was removed.</returns>
		public bool Remove(GameObject go)
		{
			return Remove(go, out var c1, out var c2, out var c3, out var c4);
		}
		
		/// <summary>
		/// Adds the specified game object to the registry if it contains the required components and if it wasn't already added before.
		/// </summary>
		/// 
		/// <param name="go">The game object to add.</param>
		/// <param name="c1">The first required component.</param>
		/// <param name="c2">The second required component.</param>
		/// <param name="c3">The third required component.</param>
		/// <param name="c4">The fourth required component.</param>
		/// <returns>Whether the game object was added.</returns>
		public bool Add(GameObject go, out T1 c1, out T2 c2, out T3 c3, out T4 c4)
		{
			return go.Has(out c1, out c2, out c3, out c4) && components.Add((c1, c2, c3, c4));
		}
		
		/// <summary>
		/// Removes the specified game object from the registry if it contains the required components and if it had been added previously.
		/// </summary>
		/// 
		/// <param name="go">The game object to remove.</param>
		/// <param name="c1">The first required component.</param>
		/// <param name="c2">The second required component.</param>
		/// <param name="c3">The third required component.</param>
		/// <param name="c4">The fourth required component.</param>
		/// <returns>Whether the game object was removed.</returns>
		public bool Remove(GameObject go, out T1 c1, out T2 c2, out T3 c3, out T4 c4)
		{
			return go.Has(out c1, out c2, out c3, out c4) && components.Remove((c1, c2, c3, c4));
		}

		public HashSet<(T1, T2, T3, T4)>.Enumerator GetEnumerator() => components.GetEnumerator();

		IEnumerator<(T1, T2, T3, T4)> IEnumerable<(T1, T2, T3, T4)>.GetEnumerator() => GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
	
	/// <summary>
	/// Holds a high-performance registry of components required by a system.
	/// </summary>
	/// 
	/// <typeparam name="T1">The type of the first required component.</typeparam>
	/// <typeparam name="T2">The type of the second required component.</typeparam>
	/// <typeparam name="T3">The type of the third required component.</typeparam>
	/// <typeparam name="T4">The type of the fourth required component.</typeparam>
	/// <typeparam name="T5">The type of the fifth required component.</typeparam>
	public sealed class SystemComponents<T1, T2, T3, T4, T5> : IEnumerable<(T1, T2, T3, T4, T5)>
	{
		private readonly HashSet<(T1, T2, T3, T4, T5)> components = new HashSet<(T1, T2, T3, T4, T5)>();
		
		/// <summary>
		/// Adds the specified game object to the registry if it contains the required components and if it wasn't already added before.
		/// </summary>
		/// 
		/// <param name="go">The game object to add.</param>
		/// <returns>Whether the game object was added.</returns>
		public bool Add(GameObject go)
		{
			return Add(go, out var c1, out var c2, out var c3, out var c4, out var c5);
		}
		
		/// <summary>
		/// Removes the specified game object from the registry if it contains the required components and if it had been added previously.
		/// </summary>
		/// 
		/// <param name="go">The game object to remove.</param>
		/// <returns>Whether the game object was removed.</returns>
		public bool Remove(GameObject go)
		{
			return Remove(go, out var c1, out var c2, out var c3, out var c4, out var c5);
		}
		
		/// <summary>
		/// Adds the specified game object to the registry if it contains the required components and if it wasn't already added before.
		/// </summary>
		/// 
		/// <param name="go">The game object to add.</param>
		/// <param name="c1">The first required component.</param>
		/// <param name="c2">The second required component.</param>
		/// <param name="c3">The third required component.</param>
		/// <param name="c4">The fourth required component.</param>
		/// <param name="c5">The fifth required component.</param>
		/// <returns>Whether the game object was added.</returns>
		public bool Add(GameObject go, out T1 c1, out T2 c2, out T3 c3, out T4 c4, out T5 c5)
		{
			return go.Has(out c1, out c2, out c3, out c4, out c5) && components.Add((c1, c2, c3, c4, c5));
		}
		
		/// <summary>
		/// Removes the specified game object from the registry if it contains the required components and if it had been added previously.
		/// </summary>
		/// 
		/// <param name="go">The game object to remove.</param>
		/// <param name="c1">The first required component.</param>
		/// <param name="c2">The second required component.</param>
		/// <param name="c3">The third required component.</param>
		/// <param name="c4">The fourth required component.</param>
		/// <param name="c5">The fifth required component.</param>
		/// <returns>Whether the game object was removed.</returns>
		public bool Remove(GameObject go, out T1 c1, out T2 c2, out T3 c3, out T4 c4, out T5 c5)
		{
			return go.Has(out c1, out c2, out c3, out c4, out c5) && components.Remove((c1, c2, c3, c4, c5));
		}

		public HashSet<(T1, T2, T3, T4, T5)>.Enumerator GetEnumerator() => components.GetEnumerator();

		IEnumerator<(T1, T2, T3, T4, T5)> IEnumerable<(T1, T2, T3, T4, T5)>.GetEnumerator() => GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
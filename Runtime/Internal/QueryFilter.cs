using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lazlo.Gocs
{
	internal sealed class QueryFilter : IPoolable, IDisposable, IEnumerable<GameObject>
	{
		internal readonly HashSet<GameObject> set = new HashSet<GameObject>(FastUnityObjectComparer<GameObject>.Instance);

		internal readonly List<Dictionary<GameObject, object>> maps = new List<Dictionary<GameObject, object>>();

		internal int passes;

		internal int pass;

		private QueryFilter() { }

		public static QueryFilter New(in int passes)
		{
			if (passes < 1)
			{
				throw new ArgumentException("At least 1 pass is required.", nameof(passes));
			}

			var filter = GenericPool<QueryFilter>.New(() => new QueryFilter());

			filter.passes = passes;

			for (var i = filter.maps.Count; i < passes; i++)
			{
				filter.maps.Add(new Dictionary<GameObject, object>(FastUnityObjectComparer<GameObject>.Instance));
			}

			return filter;
		}

		public int Pass<T>(in bool forceNative)
		{
			if (pass >= passes)
			{
				throw new InvalidOperationException("Passes exceeded.");
			}

			Registry<T>.instance.Filter(this, forceNative);

			return pass++;
		}

		internal void Map(in GameObject gameObject, in object component)
		{
			maps[pass].Add(gameObject, component);
		}

		public T Result<T>(in int pass, in GameObject gameObject)
		{
			return (T)maps[pass][gameObject];
		}

		public void Dispose()
		{
			GenericPool<QueryFilter>.Free(this);
		}

		void IPoolable.New()
		{
			pass = 0;
		}

		void IPoolable.Free()
		{
			set.Clear();

			for (var pass = 0; pass < passes; pass++)
			{
				maps[pass].Clear();
			}
		}

		public HashSet<GameObject>.Enumerator GetEnumerator()
		{
			return set.GetEnumerator();
		}

		IEnumerator<GameObject> IEnumerable<GameObject>.GetEnumerator()
		{
			return set.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
using System.Collections.Generic;
using UnityObject = UnityEngine.Object;

namespace Lazlo.Gocs
{
	internal class FastUnityObjectComparer<T> : IEqualityComparer<T> where T : UnityObject
	{
		public static readonly FastUnityObjectComparer<T> Instance = new FastUnityObjectComparer<T>();

		public bool Equals(T x, T y)
		{
			return ReferenceEquals(x, y) || // Compare by reference equality, no native call.
			       x?.GetHashCode() == y?.GetHashCode(); // Compare by instance ID, no native call.
		}

		public int GetHashCode(T obj)
		{
			return obj.GetHashCode();
		}
	}
}
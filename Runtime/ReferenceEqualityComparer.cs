using System;
using System.Collections.Generic;

namespace Lazlo.Gocs
{
	internal class ReferenceEqualityComparer<T> : IEqualityComparer<T>
	{
		public static readonly ReferenceEqualityComparer<T> Instance = new ReferenceEqualityComparer<T>();

		public bool Equals(T x, T y)
		{
			return ReferenceEquals(x, y);
		}

		public int GetHashCode(T obj)
		{
			return obj.GetHashCode();
		}
	}
}
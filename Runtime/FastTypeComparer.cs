using System;
using System.Collections.Generic;

namespace Ludiq.Recs
{
	// Credit: Tor Vestergaard
	public class FastTypeComparer : IEqualityComparer<Type>
	{
		public static readonly FastTypeComparer Instance = new FastTypeComparer();

		public bool Equals(Type x, Type y)
		{
			if (ReferenceEquals(x, y))
			{
				return true; // Oft-used fast path over regular Type.Equals makes this much faster
			}

			return x == y;
		}

		public int GetHashCode(Type obj)
		{
			return obj.GetHashCode();
		}
	}
}
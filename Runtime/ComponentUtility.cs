using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lazlo.Gocs
{
	public static class ComponentUtility
	{
		public static bool Has<T>(this GameObject go, out T component)
		{
			return go.TryGetComponent(out component);
		}

		public static bool Has<T1, T2>(this GameObject go, out T1 component1, out T2 component2)
		{
			component1 = default;
			component2 = default;

			return go.TryGetComponent(out component1) &&
			       go.TryGetComponent(out component2);
		}

		public static bool Has<T1, T2, T3>(this GameObject go, out T1 component1, out T2 component2, out T3 component3)
		{
			component1 = default;
			component2 = default;
			component3 = default;

			return go.TryGetComponent(out component1) &&
			       go.TryGetComponent(out component2) &&
			       go.TryGetComponent(out component3);
		}

		public static bool Has<T1, T2, T3, T4>(this GameObject go, out T1 component1, out T2 component2, out T3 component3, out T4 component4)
		{
			component1 = default;
			component2 = default;
			component3 = default;
			component4 = default;

			return go.TryGetComponent(out component1) &&
			       go.TryGetComponent(out component2) &&
			       go.TryGetComponent(out component3) &&
			       go.TryGetComponent(out component4);
		}

		public static bool Has<T1, T2, T3, T4, T5>(this GameObject go, out T1 component1, out T2 component2, out T3 component3, out T4 component4, out T5 component5)
		{
			component1 = default;
			component2 = default;
			component3 = default;
			component4 = default;
			component5 = default;

			return go.TryGetComponent(out component1) &&
			       go.TryGetComponent(out component2) &&
			       go.TryGetComponent(out component3) &&
			       go.TryGetComponent(out component4) &&
			       go.TryGetComponent(out component5);
		}

		public static T Get<T>(this GameObject go)
		{
			return go.GetComponent<T>();
		}

		public static (T1, T2) Get<T1, T2>(this GameObject go)
		{
			return 
			(
				go.GetComponent<T1>(), 
				go.GetComponent<T2>()
			);
		}

		public static (T1, T2, T3) Get<T1, T2, T3>(this GameObject go)
		{
			return 
			(
				go.GetComponent<T1>(), 
				go.GetComponent<T2>(), 
				go.GetComponent<T3>()
			);
		}

		public static (T1, T2, T3, T4) Get<T1, T2, T3, T4>(this GameObject go)
		{
			return 
			(
				go.GetComponent<T1>(), 
				go.GetComponent<T2>(),
				go.GetComponent<T3>(),
				go.GetComponent<T4>()
			);
		}

		public static (T1, T2, T3, T4, T5) Get<T1, T2, T3, T4, T5>(this GameObject go)
		{
			return 
			(
				go.GetComponent<T1>(), 
				go.GetComponent<T2>(),
				go.GetComponent<T3>(),
				go.GetComponent<T4>(),
				go.GetComponent<T5>()
			);
		}
	}
}
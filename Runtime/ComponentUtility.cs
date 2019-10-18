using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lazlo.Gocs
{
	public static class ComponentUtility
	{
		public static bool Has<T>(this GameObject go, out T component)
			where T : IComponent
		{
			return go.TryGetComponent(out component);
		}

		public static bool Has<T1, T2>(this GameObject go, out T1 component1, out T2 component2)
			where T1 : IComponent
			where T2 : IComponent
		{
			component1 = default;
			component2 = default;

			return go.TryGetComponent(out component1) &&
			       go.TryGetComponent(out component2);
		}

		public static bool Has<T1, T2, T3>(this GameObject go, out T1 component1, out T2 component2, out T3 component3)
			where T1 : IComponent
			where T2 : IComponent
			where T3 : IComponent
		{
			component1 = default;
			component2 = default;
			component3 = default;

			return go.TryGetComponent(out component1) &&
			       go.TryGetComponent(out component2) &&
			       go.TryGetComponent(out component3);
		}

		public static T Get<T>(this GameObject go)
			where T : IComponent
		{
			return go.GetComponent<T>();
		}

		public static (T1, T2) Get<T1, T2>(this GameObject go)
			where T1 : IComponent
			where T2 : IComponent
		{
			return (go.GetComponent<T1>(), go.GetComponent<T2>());
		}

		public static (T1, T2, T3) Get<T1, T2, T3>(this GameObject go)
			where T1 : IComponent
			where T2 : IComponent
			where T3 : IComponent
		{
			var (a, b) = go.Get<IComponent, IComponent>();
			
			return (go.GetComponent<T1>(), go.GetComponent<T2>(), go.GetComponent<T3>());
		}
	}
}
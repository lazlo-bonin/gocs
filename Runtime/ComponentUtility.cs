using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lazlo.Recs
{
	public static class ComponentUtility
	{
		public static bool Has<T>(this GameObject entity, out T component)
			where T : IComponent
		{
			return entity.TryGetComponent(out component);
		}

		public static bool Has<T1, T2>(this GameObject entity, out T1 component1, out T2 component2)
			where T1 : IComponent
			where T2 : IComponent
		{
			component1 = default;
			component2 = default;

			return entity.TryGetComponent(out component1) &&
			       entity.TryGetComponent(out component2);
		}

		public static bool Has<T1, T2, T3>(this GameObject entity, out T1 component1, out T2 component2, out T3 component3)
			where T1 : IComponent
			where T2 : IComponent
			where T3 : IComponent
		{
			component1 = default;
			component2 = default;
			component3 = default;

			return entity.TryGetComponent(out component1) &&
			       entity.TryGetComponent(out component2) &&
			       entity.TryGetComponent(out component3);
		}

		public static T Get<T>(this GameObject entity)
			where T : IComponent
		{
			return entity.GetComponent<T>();
		}

		public static (T1, T2) Get<T1, T2>(this GameObject entity)
			where T1 : IComponent
			where T2 : IComponent
		{
			return (entity.GetComponent<T1>(), entity.GetComponent<T2>());
		}

		public static (T1, T2, T3) Get<T1, T2, T3>(this GameObject entity)
			where T1 : IComponent
			where T2 : IComponent
			where T3 : IComponent
		{
			return (entity.GetComponent<T1>(), entity.GetComponent<T2>(), entity.GetComponent<T3>());
		}
	}
}
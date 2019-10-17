using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lazlo.Recs
{
	public static class World
	{
		#region Systems & Components

		private static readonly List<ISystem> systems = new List<ISystem>();

		private static readonly List<IComponent> components = new List<IComponent>();

		public static void AddSystem(ISystem system)
		{
			if (system == null)
			{
				throw new ArgumentNullException(nameof(system));
			}

			foreach (var component in components)
			{
				system.AddComponent(component);
			}

			systems.Add(system);
		}

		public static void RemoveSystem(ISystem system)
		{
			if (system == null)
			{
				throw new ArgumentNullException(nameof(system));
			}

			foreach (var component in components)
			{
				system.RemoveComponent(component);
			}

			systems.Remove(system);
		}

		public static void AddComponent(IComponent component)
		{
			if (component == null)
			{
				throw new ArgumentNullException(nameof(component));
			}

			components.Add(component);

			AddComponentToQueryCaches(component);

			foreach (var system in systems)
			{
				system.AddComponent(component);
			}
		}

		public static void RemoveComponent(IComponent component)
		{
			if (component == null)
			{
				throw new ArgumentNullException(nameof(component));
			}

			foreach (var system in systems)
			{
				system.RemoveComponent(component);
			}

			RemoveComponentFromQueryCaches(component);

			components.Remove(component);
		}

		#endregion



		#region Queries

		// TODO: Make it fast.

		private static readonly Dictionary<Type, HashSet<IComponent>> componentsByType = new Dictionary<Type, HashSet<IComponent>>(FastTypeComparer.Instance);

		private static readonly Dictionary<Type, HashSet<GameObject>> entitiesByComponentType = new Dictionary<Type, HashSet<GameObject>>(FastTypeComparer.Instance);

		private static void AddComponentToQueryCaches(IComponent component)
		{
			foreach (var componentType in ComponentTypeUtility.GetComponentTypes(component.GetType()))
			{
				if (!componentsByType.TryGetValue(componentType, out var componentsOfType))
				{
					componentsOfType = new HashSet<IComponent>();
					componentsByType.Add(componentType, componentsOfType);
				}

				if (!entitiesByComponentType.TryGetValue(componentType, out var entitiesWithComponentsOfType))
				{
					entitiesWithComponentsOfType = new HashSet<GameObject>();
					entitiesByComponentType.Add(componentType, entitiesWithComponentsOfType);
				}

				componentsOfType.Add(component);
				entitiesWithComponentsOfType.Add(component.entity);
			}
		}

		private static void RemoveComponentFromQueryCaches(IComponent component)
		{
			foreach (var componentType in ComponentTypeUtility.GetComponentTypes(component.GetType()))
			{
				if (componentsByType.TryGetValue(componentType, out var componentsOfType))
				{
					componentsOfType.Remove(component);
				}

				if (entitiesByComponentType.TryGetValue(componentType, out var entitiesWithComponentsOfType))
				{
					entitiesWithComponentsOfType.Remove(component.entity);
				}
			}
		}

		public static IEnumerable<T> Query<T>()
			where T : IComponent
		{
			if (!componentsByType.TryGetValue(typeof(T), out var componentsOfType))
			{
				yield break;
			}

			foreach (var componentOfType in componentsOfType)
			{
				yield return (T)componentOfType;
			}
		}

		public static IEnumerable<(T1, T2)> Query<T1, T2>()
			where T1 : IComponent
			where T2 : IComponent
		{
			if (!entitiesByComponentType.TryGetValue(typeof(T1), out var entitiesWith1))
			{
				yield break;
			}

			if (!entitiesByComponentType.TryGetValue(typeof(T2), out var entitiesWith2))
			{
				yield break;
			}

			// TODO: HashSet pooling
			var entities = new HashSet<GameObject>(entitiesWith1);
			entities.IntersectWith(entitiesWith2);

			foreach (var entity in entities)
			{
				yield return entity.Get<T1, T2>();
			}
		}

		public static IEnumerable<(T1, T2, T3)> Query<T1, T2, T3>()
			where T1 : IComponent
			where T2 : IComponent
			where T3 : IComponent
		{
			if (!entitiesByComponentType.TryGetValue(typeof(T1), out var entitiesWith1))
			{
				yield break;
			}

			if (!entitiesByComponentType.TryGetValue(typeof(T2), out var entitiesWith2))
			{
				yield break;
			}

			if (!entitiesByComponentType.TryGetValue(typeof(T2), out var entitiesWith3))
			{
				yield break;
			}

			// TODO: HashSet pooling
			var entities = new HashSet<GameObject>(entitiesWith1);
			entities.IntersectWith(entitiesWith2);
			entities.IntersectWith(entitiesWith3);

			foreach (var entity in entities)
			{
				yield return entity.Get<T1, T2, T3>();
			}
		}

		#endregion
	}
}
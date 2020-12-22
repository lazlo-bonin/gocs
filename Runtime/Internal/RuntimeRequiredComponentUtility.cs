﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lazlo.Gocs
{
	internal static class RuntimeRequiredComponentUtility
	{
		private static readonly Dictionary<Type, Type[]> componentTypeToRequiredComponentTypes = new Dictionary<Type, Type[]>(ReferenceEqualityComparer<Type>.Instance);

		private static IEnumerable<Type> GetRequiredComponentTypes(in Type componentType)
		{
			if (componentType == null)
			{
				throw new ArgumentNullException(nameof(componentType));
			}

			if (!componentTypeToRequiredComponentTypes.TryGetValue(componentType, out var componentTypes))
			{
				componentTypes = FetchRequiredComponentTypes(componentType).ToArray();
				componentTypeToRequiredComponentTypes.Add(componentType, componentTypes);
			}

			return componentTypes;
		}

		private static IEnumerable<Type> FetchRequiredComponentTypes(Type componentType)
		{
			if (!typeof(Component).IsAssignableFrom(componentType))
			{
				throw new ArgumentException("Component type is not derived from component.", nameof(componentType));
			}

			foreach (var type in ComponentTypeUtility.GetManagedComponentTypes(componentType))
			{
				foreach (var attribute in type.GetCustomAttributes(typeof(RuntimeRequireComponentAttribute), true).Cast<RuntimeRequireComponentAttribute>())
				{
					var requiredComponentType = attribute.componentType;

					if (!typeof(Component).IsAssignableFrom(requiredComponentType))
					{
						Debug.LogWarning($"Required component type '{requiredComponentType}' is not derived from component, ignoring.");
						continue;
					}

					yield return requiredComponentType;
				}
			}
		}

		public static void AddRuntimeRequiredComponents(in Component component)
		{
			if (component == null)
			{
				throw new ArgumentNullException(nameof(component));
			}

			foreach (var requiredComponentType in GetRequiredComponentTypes(component.GetType()))
			{
				component.gameObject.GetOrAddComponent(requiredComponentType);
			}
		}

		public static Component GetOrAddComponent(this GameObject go, in Type componentType)
		{
			if (!go.TryGetComponent(componentType, out var component))
			{
				component = go.AddComponent(componentType);
			}

			return component;
		}

		public static Component GetOrAddComponent(this GameObject go, in Type componentType, in Type defaultComponentType)
		{
			if (!go.TryGetComponent(componentType, out var component))
			{
				component = go.AddComponent(defaultComponentType);
			}

			return component;
		}

		public static T GetOrAddComponent<T>(this GameObject go) where T : Component
		{
			if (!go.TryGetComponent<T>(out var component))
			{
				component = go.AddComponent<T>();
			}

			return component;
		}

		public static TGet GetOrAddComponent<TGet, TAdd>(this GameObject go) where TAdd : Component, TGet
		{
			if (!go.TryGetComponent<TGet>(out var component))
			{
				component = go.AddComponent<TAdd>();
			}

			return component;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lazlo.Gocs
{
	internal static class ComponentTypeUtility
	{
		private static readonly Dictionary<Type, Type[]> typeToComponentTypes = new Dictionary<Type, Type[]>(ReferenceEqualityComparer<Type>.Instance);
		
		public static IEnumerable<Type> GetManagedComponentTypes(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}

			if (!typeToComponentTypes.TryGetValue(type, out var componentTypes))
			{
				componentTypes = FetchManagedComponentTypes(type).ToArray();
				typeToComponentTypes.Add(type, componentTypes);
			}

			return componentTypes;
		}

		public static bool IsManagedComponentType(in Type type)
		{
			return typeof(IComponent).IsAssignableFrom(type);
		}

		public static bool IsNativeComponentType(in Type type)
		{
			return typeof(Component).IsAssignableFrom(type);
		}

		private static IEnumerable<Type> FetchManagedComponentTypes(Type type)
		{
			if (IsManagedComponentType(type))
			{
				yield return type;
			}

			foreach (var interfaceType in type.GetInterfaces())
			{
				if (IsManagedComponentType(interfaceType))
				{
					yield return interfaceType;
				}
			}
		}
	}
}
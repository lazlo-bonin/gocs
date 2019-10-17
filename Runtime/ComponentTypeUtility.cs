using System;
using System.Collections.Generic;
using System.Linq;

namespace Lazlo.Recs
{
	public static class ComponentTypeUtility
	{
		private static readonly Dictionary<Type, Type[]> typeToComponentTypes = new Dictionary<Type, Type[]>(FastTypeComparer.Instance);
		
		public static IEnumerable<Type> GetComponentTypes(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}

			if (!typeToComponentTypes.TryGetValue(type, out var componentTypes))
			{
				componentTypes = FetchComponentTypes(type).ToArray();
				typeToComponentTypes.Add(type, componentTypes);
			}

			return componentTypes;
		}

		private static IEnumerable<Type> FetchComponentTypes(Type type)
		{
			return type.GetInterfaces().Where(interfaceType => typeof(IComponent).IsAssignableFrom(interfaceType));
		}
	}
}
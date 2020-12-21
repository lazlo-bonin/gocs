
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lazlo.Gocs
{
    internal static class Registries
    {
        private static readonly Dictionary<Type, IRegistry> componentTypeToRegistry = new Dictionary<Type, IRegistry>(ReferenceEqualityComparer<Type>.Instance);

        private static IRegistry GetRegistry(in Type componentType)
        {
            if (!componentTypeToRegistry.TryGetValue(componentType, out var registry))
            {
                var registryType = typeof(Registry<>).MakeGenericType(componentType);
                var instanceField = registryType.GetField(nameof(Registry<IComponent>.instance), BindingFlags.Public | BindingFlags.Static);
                registry = (IRegistry)instanceField.GetValue(null);
                componentTypeToRegistry.Add(componentType, registry);
            }
            
            return registry;
        }

        public static IEnumerable<IRegistry> GetRegistries(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            foreach (var componentType in ComponentTypeUtility.GetManagedComponentTypes(component.GetType()))
            {
                yield return GetRegistry(componentType);
            }
        }

        public static void Add(in IComponent component)
        {
            foreach (var registry in GetRegistries(component))
            {
                registry.Add(component);
            }
        }

        public static void Remove(in IComponent component)
        {
            foreach (var registry in GetRegistries(component))
            {
                registry.Remove(component);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Lazlo.Gocs
{
    internal class Registry<TComponent> : IRegistry
    {
        public static readonly Registry<TComponent> instance = new Registry<TComponent>();

        public RegistryMode mode { get; }

        private readonly HashSet<TComponent> components = new HashSet<TComponent>();
        private readonly HashSet<GameObject> gameObjects = new HashSet<GameObject>();
        private readonly Dictionary<GameObject, TComponent> map = new Dictionary<GameObject, TComponent>();

        private Registry()
        {
            mode = typeof(IComponent).IsAssignableFrom(typeof(TComponent)) ? RegistryMode.Managed : RegistryMode.Native;
        }

        public void Add(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            if (!(component is TComponent tComponent))
            {
                throw new InvalidCastException(nameof(component));
            }

            var gameObject = component.gameObject;
            components.Add(tComponent);
            gameObjects.Add(gameObject);
            map.Add(gameObject, tComponent);
        }

        public void Remove(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            if (!(component is TComponent tComponent))
            {
                throw new InvalidCastException(nameof(component));
            }

            var gameObject = component.gameObject;
            components.Remove(tComponent);
            gameObjects.Remove(gameObject);
            map.Remove(gameObject);
        }

        public void Filter(QueryFilter filter, bool forceNative)
        {
            if (forceNative || mode == RegistryMode.Native)
            {
                NativeFilter(filter);
            }
            else
            {
                ManagedFilter(filter);
            }
        }

        private void ManagedFilter(QueryFilter filter)
        {
            if (filter.pass == 0)
            {
                filter.set.UnionWith(gameObjects);

                foreach (var component in components)
                {
                    filter.Map(((IComponent)component).gameObject, component);
                }
            }
            else
            {
                filter.set.IntersectWith(gameObjects);

                foreach (var go in filter.set)
                {
                    filter.Map(go, map[go]);
                }
            }
        }

        private void NativeFilter(QueryFilter filter)
        {
            if (filter.pass == 0)
            {
                IEnumerable<UnityEngine.Object> objects;

                if (mode == RegistryMode.Native)
                {
                    objects = UnityEngine.Object.FindObjectsOfType(typeof(TComponent));
                }
                else
                {
                    objects = UnityEngine.Object.FindObjectsOfType(typeof(Component)).OfType<TComponent>().Cast<UnityEngine.Object>();
                }

                foreach (var obj in objects)
                {
                    if (!(obj is Component component))
                    {
                        continue;
                    }

                    var gameObject = component.gameObject;
                    filter.set.Add(gameObject);
                    filter.Map(gameObject, component);
                }
            }
            else
            {
                filter.set.RemoveWhere(go => !go.TryGetComponent<TComponent>(out var component));

                foreach (var go in filter.set)
                {
                    filter.Map(go, go.GetComponent<TComponent>());
                }
            }
        }
    }
}
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
        private readonly HashSet<GameObject> gameObjects = new HashSet<GameObject>(FastUnityObjectComparer<GameObject>.Instance);
        private readonly Dictionary<GameObject, List<TComponent>> map = new Dictionary<GameObject, List<TComponent>>(FastUnityObjectComparer<GameObject>.Instance);

        private Registry()
        {
	        if (ComponentTypeUtility.IsManagedComponentType(typeof(TComponent)))
	        {
		        mode = RegistryMode.Managed;
	        }
			else
	        {
		        mode = RegistryMode.Native;
	        }
        }

        public void Add(in IComponent component)
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

            if (!map.TryGetValue(gameObject, out var gomap))
            {
	            gomap = ListPool<TComponent>.New();
	            map.Add(gameObject, gomap);
            }

            gomap.Add(tComponent);
        }

        public void Remove(in IComponent component)
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
			
            if (map.TryGetValue(gameObject, out var gomap))
            {
	            if (gomap.Remove(tComponent))
	            {
					if (gomap.Count == 0)
					{
						gomap.Free();
						map.Remove(gameObject);
					}
	            }
            }
        }

        public void Filter(in QueryFilter filter, in bool forceNative)
        {
            if (forceNative || mode == RegistryMode.Native || !World.enableRegistries)
            {
                NativeFilter(filter);
            }
            else
            {
                ManagedFilter(filter);
            }
        }

        private void ManagedFilter(in QueryFilter filter)
        {
            if (filter.pass == 0)
            {
				// UnionWith would box the GameObjects HashSet into an IEnumerable
                foreach (var gameObject in gameObjects)
                {
	                filter.set.Add(gameObject);
                }

                foreach (var component in components)
                {
                    filter.Map(((IComponent)component).gameObject, component);
                }
            }
            else
            {
	            // IntersectWith would box the GameObjects HashSet into an IEnumerable

	            var toRemove = HashSetPool<GameObject>.New();

	            foreach (var gameObject in filter.set)
	            {
		            if (!gameObjects.Contains(gameObject))
		            {
			            toRemove.Add(gameObject);
		            }
	            }

	            foreach (var gameObject in toRemove)
	            {
		            filter.set.Remove(gameObject);
	            }

	            toRemove.Free();

                foreach (var go in filter.set)
                {
	                filter.Map(go, map[go][0]);
                }
            }
        }

        private void NativeFilter(in QueryFilter filter)
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
using UnityEngine;

namespace Lazlo.Recs
{
	public abstract class BaseSystem : MonoBehaviour, ISystem
	{
		protected virtual void Awake()
		{
			// Unused but reserved. Derived components should call this. 
		}

		protected virtual void OnEnable()
		{
			World.AddSystem(this);
		}

		protected virtual void OnDisable()
		{
			World.RemoveSystem(this);
		}

		protected virtual void OnDestroy()
		{
			// Unused but reserved. Derived components should call this. 
		}

		public virtual void AddComponent(IComponent component) { }

		public virtual void RemoveComponent(IComponent component) { }
	}
}
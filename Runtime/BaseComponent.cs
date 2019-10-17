using UnityEngine;

namespace Ludiq.Recs
{
	public abstract class BaseComponent : MonoBehaviour, IComponent
	{
		GameObject IComponent.entity => gameObject;

		protected virtual void Awake()
		{
			RuntimeRequiredComponentUtility.AddRuntimeRequiredComponents(this);
		}

		protected virtual void OnEnable()
		{
			World.AddComponent(this);
		}

		protected virtual void OnDisable()
		{
			World.RemoveComponent(this);
		}

		protected virtual void OnDestroy()
		{
			// Unused but reserved. Derived components should call this. 
		}
	}
}
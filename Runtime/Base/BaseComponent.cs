using UnityEngine;

namespace Lazlo.Gocs
{
	public abstract class BaseComponent : MonoBehaviour, IComponent
	{
		protected virtual void Awake()
		{
			BaseImplementation.ComponentAwake(this);
		}

		protected virtual void OnEnable()
		{
			BaseImplementation.ComponentOnEnable(this);
		}

		protected virtual void OnDisable()
		{
			BaseImplementation.ComponentOnDisable(this);
		}

		protected virtual void OnDestroy()
		{
			BaseImplementation.ComponentOnDestroy(this);
		}
	}
}
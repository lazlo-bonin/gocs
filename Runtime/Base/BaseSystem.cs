using UnityEngine;

namespace Lazlo.Gocs
{
	public abstract class BaseSystem : MonoBehaviour, ISystem
	{
		protected virtual void Awake()
		{
			BaseImplementation.SystemAwake(this);
		}

		protected virtual void OnEnable()
		{
			BaseImplementation.SystemOnEnable(this);
		}

		protected virtual void OnDisable()
		{
			BaseImplementation.SystemOnDisable(this);
		}

		protected virtual void OnDestroy()
		{
			BaseImplementation.SystemOnDestroy(this);
		}
	}
}
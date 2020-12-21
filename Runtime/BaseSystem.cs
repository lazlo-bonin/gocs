using UnityEngine;

namespace Lazlo.Gocs
{
	/// <summary>
	/// The base class from which to derive systems.
	/// </summary>
	/// 
	/// <remarks>
	/// You can also manually implement <see cref="ISystem"/> and
	/// optionally <see cref="IWorldCallbackReceiver"/> if you
	/// cannot derive from this class.
	/// </remarks>
	/// 
	/// <seealso cref="BaseImplementation"/>
	public abstract class BaseSystem : MonoBehaviour, ISystem, IWorldCallbackReceiver
	{
		public virtual void OnCreatedComponent(in IComponent component) { }
		public virtual void OnDestroyedComponent(in IComponent component) { }

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
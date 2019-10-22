using UnityEngine;

namespace Lazlo.Gocs
{
	/// <summary>
	/// The base class from which to derive systems.
	/// </summary>
	/// <remarks>
	/// You can also manually implement <see cref="ISystem"/> and
	/// optionally <see cref="IWorldCallbackReceiver"/> if you
	/// cannot derive from this class.
	/// </remarks>
	/// <seealso cref="BaseImplementation"/>
	public abstract class BaseSystem : MonoBehaviour, ISystem, IWorldCallbackReceiver
	{
		/// <summary>
		/// Called when any new component is created.
		/// Use this method to register the component into <see cref="SystemComponents{T}"/> and / or <see cref="SystemEvents"/>.
		/// </summary>
		/// <param name="component">The component being created.</param>
		public virtual void OnCreatedComponent(IComponent component) { }

		/// <summary>
		/// Called when any existing component is destroyed.
		/// Use this method to unregister the component from <see cref="SystemComponents{T}"/> and / or <see cref="SystemEvents"/>.
		/// </summary>
		/// <param name="component">The component being destroyed.</param>
		public virtual void OnDestroyingComponent(IComponent component) { }

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
using UnityEngine;

namespace Lazlo.Gocs
{
	/// <summary>
	/// The base class from which to derive components.
	/// </summary>
	/// <remarks>
	/// You can also manually implement <see cref="IComponent"/> if you
	/// cannot derive from this class.
	/// </remarks>
	/// <seealso cref="BaseImplementation"/>
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
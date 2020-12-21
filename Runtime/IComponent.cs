using UnityEngine;

namespace Lazlo.Gocs
{
	/// <summary>
	/// Represents a Component interface. 
	/// <para>
	/// Component interfaces are responsible for defining attributes, data and events for use by the <see cref="ISystem"/>s.
	/// </para><para>
	/// Component interfaces should be implemented by one or more component class(es).
	/// </para>
	/// </summary>
	/// 
	/// <seealso cref="BaseComponent"/>
	public interface IComponent
	{
		/// <summary>
		/// The game object that holds the component.
		/// </summary>
		/// 
		/// <remarks>
		/// The game object acts as the equivalent of an ECS entity.
		/// </remarks>
		GameObject gameObject { get; }

		/// <summary>
		/// A shorthand for the transform component on the game object.
		/// </summary>
		Transform transform { get; }
	}
}
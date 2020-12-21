namespace Lazlo.Gocs
{
	/// <summary>
	/// Represents a System interface.
	/// <para>
	/// Systems are responsible for handling common logic and event dispatch on batches of components.
	/// </para><para>
	/// To receive callbacks on component creation and destruction, see <see cref="IWorldCallbackReceiver"/>.
	/// </para>
	/// </summary>
	/// 
	/// <seealso cref="BaseSystem"/>
	public interface ISystem
	{
		/// <summary>
		/// Called when any new component is created.
		/// <para>
		/// Use this method to register the component into <see cref="SystemComponents{T}"/> and / or <see cref="SystemEvents"/>.
		/// </para>
		/// </summary>
		/// <param name="component">The component being created.</param>
		public void OnCreatedComponent(IComponent component);

		/// <summary>
		/// Called when any existing component is destroyed.
		/// <para>
		/// Use this method to unregister the component from <see cref="SystemComponents{T}"/> and / or <see cref="SystemEvents"/>.
		/// </para>
		/// </summary>
		/// <param name="component">The component being destroyed.</param>
		public void OnDestroyingComponent(IComponent component);
	}
}
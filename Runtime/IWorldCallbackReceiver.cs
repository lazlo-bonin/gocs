namespace Lazlo.Gocs
{
	/// <summary>
	/// Provides callbacks on component creation and destruction when added to a system.
	/// </summary>
	public interface IWorldCallbackReceiver
	{
		/// <summary>
		/// Called when any new component is created.
		/// <para>
		/// Use this method to register the component into <see cref="SystemComponents{T}"/> and / or <see cref="SystemEvents"/>.
		/// </para>
		/// </summary>
		/// <param name="component">The component being created.</param>
		void OnCreatedComponent(IComponent component);

		/// <summary>
		/// Called when any existing component is destroyed.
		/// <para>
		/// Use this method to unregister the component from <see cref="SystemComponents{T}"/> and / or <see cref="SystemEvents"/>.
		/// </para>
		/// </summary>
		/// <param name="component">The component being destroyed.</param>
		void OnDestroyedComponent(IComponent component);
	}
}
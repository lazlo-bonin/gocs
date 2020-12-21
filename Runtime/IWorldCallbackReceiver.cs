namespace Lazlo.Gocs
{
	/// <summary>
	/// Provides callbacks on <see cref="IComponent"/> creation and destruction when added to a system.
	/// </summary>
	public interface IWorldCallbackReceiver
	{
		/// <summary>
		/// Called when any new <see cref="IComponent"/> is created.
		/// <para>
		/// Use this method to register the <see cref="IComponent"/> into <see cref="SystemComponents{T}"/> and / or <see cref="SystemEvents"/>.
		/// </para>
		/// </summary>
		/// 
		/// <param name="component">The <see cref="IComponent"/> being created.</param>
		void OnCreatedComponent(in IComponent component);

		/// <summary>
		/// Called when any existing <see cref="IComponent"/> is destroyed.
		/// <para>
		/// Use this method to unregister the <see cref="IComponent"/> from <see cref="SystemComponents{T}"/> and / or <see cref="SystemEvents"/>.
		/// </para>
		/// </summary>
		/// 
		/// <param name="component">The <see cref="IComponent"/> being destroyed.</param>
		void OnDestroyedComponent(in IComponent component);
	}
}
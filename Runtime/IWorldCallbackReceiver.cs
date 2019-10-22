namespace Lazlo.Gocs
{
	public interface IWorldCallbackReceiver
	{
		void OnAddComponent(IComponent component);
		void OnRemoveComponent(IComponent component);
	}
}
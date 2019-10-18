namespace Lazlo.Gocs
{
	public interface ISystem
	{
		void AddComponent(IComponent component);

		void RemoveComponent(IComponent component);
	}
}
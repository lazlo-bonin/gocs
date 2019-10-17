namespace Lazlo.Recs
{
	public interface ISystem
	{
		void AddComponent(IComponent component);

		void RemoveComponent(IComponent component);
	}
}
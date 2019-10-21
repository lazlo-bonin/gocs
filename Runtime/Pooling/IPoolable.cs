namespace Lazlo.Gocs
{
	public interface IPoolable
	{
		void New();
		void Free();
	}
}
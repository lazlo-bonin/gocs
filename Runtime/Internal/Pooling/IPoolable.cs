namespace Lazlo.Gocs
{
	internal interface IPoolable
	{
		void New();
		void Free();
	}
}
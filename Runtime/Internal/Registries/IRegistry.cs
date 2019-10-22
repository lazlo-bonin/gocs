namespace Lazlo.Gocs
{
    internal interface IRegistry
    {
        RegistryMode mode { get; }
        void Add(IComponent component);
        void Remove(IComponent component);
        void Filter(QueryFilter filter, bool forceNative);
    }
}
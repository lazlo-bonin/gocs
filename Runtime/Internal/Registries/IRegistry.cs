namespace Lazlo.Gocs
{
    internal interface IRegistry
    {
        RegistryMode mode { get; }
        void Add(in IComponent component);
        void Remove(in IComponent component);
        void Filter(in QueryFilter filter, in bool forceNative);
    }
}
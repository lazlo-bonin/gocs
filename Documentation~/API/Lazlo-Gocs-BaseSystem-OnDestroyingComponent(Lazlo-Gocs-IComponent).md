#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs').[BaseSystem](./Lazlo-Gocs-BaseSystem.md 'Lazlo.Gocs.BaseSystem')
## BaseSystem.OnDestroyingComponent(Lazlo.Gocs.IComponent) Method
Called when any existing component is destroyed.  
Use this method to unregister the component from [SystemComponents&lt;T&gt;](./Lazlo-Gocs-SystemComponents-T-.md 'Lazlo.Gocs.SystemComponents&lt;T&gt;') and / or [SystemEvents](./Lazlo-Gocs-SystemEvents.md 'Lazlo.Gocs.SystemEvents').  
```C#
public virtual void OnDestroyingComponent(Lazlo.Gocs.IComponent component);
```
#### Parameters
<a name='Lazlo-Gocs-BaseSystem-OnDestroyingComponent(Lazlo-Gocs-IComponent)-component'></a>
`component` [IComponent](./Lazlo-Gocs-IComponent.md 'Lazlo.Gocs.IComponent')  
The component being destroyed.  
  

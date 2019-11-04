#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs')
## BaseSystem Class
The base class from which to derive systems.  
```C#
public abstract class BaseSystem : MonoBehaviour,
ISystem,
IWorldCallbackReceiver
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &gt; [UnityEngine.Object](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Object 'UnityEngine.Object') &gt; [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component') &gt; [UnityEngine.Behaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Behaviour 'UnityEngine.Behaviour') &gt; [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &gt; [BaseSystem](./Lazlo-Gocs-BaseSystem.md 'Lazlo.Gocs.BaseSystem')  

Implements [ISystem](./Lazlo-Gocs-ISystem.md 'Lazlo.Gocs.ISystem'), [IWorldCallbackReceiver](./Lazlo-Gocs-IWorldCallbackReceiver.md 'Lazlo.Gocs.IWorldCallbackReceiver')  
### Remarks
You can also manually implement [ISystem](./Lazlo-Gocs-ISystem.md 'Lazlo.Gocs.ISystem') and  
optionally [IWorldCallbackReceiver](./Lazlo-Gocs-IWorldCallbackReceiver.md 'Lazlo.Gocs.IWorldCallbackReceiver') if you  
cannot derive from this class.  
### Methods
- [OnCreatedComponent(Lazlo.Gocs.IComponent)](./Lazlo-Gocs-BaseSystem-OnCreatedComponent(Lazlo-Gocs-IComponent).md 'Lazlo.Gocs.BaseSystem.OnCreatedComponent(Lazlo.Gocs.IComponent)')
- [OnDestroyingComponent(Lazlo.Gocs.IComponent)](./Lazlo-Gocs-BaseSystem-OnDestroyingComponent(Lazlo-Gocs-IComponent).md 'Lazlo.Gocs.BaseSystem.OnDestroyingComponent(Lazlo.Gocs.IComponent)')

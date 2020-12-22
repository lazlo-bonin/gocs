#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs').[SystemComponents&lt;T&gt;](./Lazlo-Gocs-SystemComponents-T-.md 'Lazlo.Gocs.SystemComponents&lt;T&gt;')
## SystemComponents&lt;T&gt;.Remove(UnityEngine.GameObject, T) Method
Removes the specified game object from the registry if it contains the required component and if it had been added previously.  
```C#
public bool Remove(UnityEngine.GameObject go, out T c);
```
#### Parameters
<a name='Lazlo-Gocs-SystemComponents-T--Remove(UnityEngine-GameObject_T)-go'></a>
`go` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')  
The game object to remove.  
  
<a name='Lazlo-Gocs-SystemComponents-T--Remove(UnityEngine-GameObject_T)-c'></a>
`c` [T](./Lazlo-Gocs-SystemComponents-T-.md#Lazlo-Gocs-SystemComponents-T--T 'Lazlo.Gocs.SystemComponents&lt;T&gt;.T')  
The returned required component.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the game object was removed.  

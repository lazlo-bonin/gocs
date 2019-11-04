#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs').[SystemComponents&lt;T1,T2&gt;](./Lazlo-Gocs-SystemComponents-T1_T2-.md 'Lazlo.Gocs.SystemComponents&lt;T1,T2&gt;')
## SystemComponents&lt;T1,T2&gt;.Add(UnityEngine.GameObject, T1, T2) Method
Adds the specified game object to the registry if it contains the required components and if it wasn't already added before.  
```C#
public bool Add(UnityEngine.GameObject go, out T1 c1, out T2 c2);
```
#### Parameters
<a name='Lazlo-Gocs-SystemComponents-T1_T2--Add(UnityEngine-GameObject_T1_T2)-go'></a>
`go` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')  
The game object to add.  
  
<a name='Lazlo-Gocs-SystemComponents-T1_T2--Add(UnityEngine-GameObject_T1_T2)-c1'></a>
`c1` [T1](./Lazlo-Gocs-SystemComponents-T1_T2-.md#Lazlo-Gocs-SystemComponents-T1_T2--T1 'Lazlo.Gocs.SystemComponents&lt;T1,T2&gt;.T1')  
The first required component.  
  
<a name='Lazlo-Gocs-SystemComponents-T1_T2--Add(UnityEngine-GameObject_T1_T2)-c2'></a>
`c2` [T2](./Lazlo-Gocs-SystemComponents-T1_T2-.md#Lazlo-Gocs-SystemComponents-T1_T2--T2 'Lazlo.Gocs.SystemComponents&lt;T1,T2&gt;.T2')  
The second required component.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the game object was added.  

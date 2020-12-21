#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs').[SystemComponents&lt;T1,T2,T3,T4&gt;](./Lazlo-Gocs-SystemComponents-T1_T2_T3_T4-.md 'Lazlo.Gocs.SystemComponents&lt;T1,T2,T3,T4&gt;')
## SystemComponents&lt;T1,T2,T3,T4&gt;.Remove(UnityEngine.GameObject, T1, T2, T3, T4) Method
Removes the specified game object from the registry if it contains the required components and if it had been added previously.  
```C#
public bool Remove(UnityEngine.GameObject go, out T1 c1, out T2 c2, out T3 c3, out T4 c4);
```
#### Parameters
<a name='Lazlo-Gocs-SystemComponents-T1_T2_T3_T4--Remove(UnityEngine-GameObject_T1_T2_T3_T4)-go'></a>
`go` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')  
The game object to remove.  
  
<a name='Lazlo-Gocs-SystemComponents-T1_T2_T3_T4--Remove(UnityEngine-GameObject_T1_T2_T3_T4)-c1'></a>
`c1` [T1](./Lazlo-Gocs-SystemComponents-T1_T2_T3_T4-.md#Lazlo-Gocs-SystemComponents-T1_T2_T3_T4--T1 'Lazlo.Gocs.SystemComponents&lt;T1,T2,T3,T4&gt;.T1')  
The first required component.  
  
<a name='Lazlo-Gocs-SystemComponents-T1_T2_T3_T4--Remove(UnityEngine-GameObject_T1_T2_T3_T4)-c2'></a>
`c2` [T2](./Lazlo-Gocs-SystemComponents-T1_T2_T3_T4-.md#Lazlo-Gocs-SystemComponents-T1_T2_T3_T4--T2 'Lazlo.Gocs.SystemComponents&lt;T1,T2,T3,T4&gt;.T2')  
The second required component.  
  
<a name='Lazlo-Gocs-SystemComponents-T1_T2_T3_T4--Remove(UnityEngine-GameObject_T1_T2_T3_T4)-c3'></a>
`c3` [T3](./Lazlo-Gocs-SystemComponents-T1_T2_T3_T4-.md#Lazlo-Gocs-SystemComponents-T1_T2_T3_T4--T3 'Lazlo.Gocs.SystemComponents&lt;T1,T2,T3,T4&gt;.T3')  
The third required component.  
  
<a name='Lazlo-Gocs-SystemComponents-T1_T2_T3_T4--Remove(UnityEngine-GameObject_T1_T2_T3_T4)-c4'></a>
`c4` [T4](./Lazlo-Gocs-SystemComponents-T1_T2_T3_T4-.md#Lazlo-Gocs-SystemComponents-T1_T2_T3_T4--T4 'Lazlo.Gocs.SystemComponents&lt;T1,T2,T3,T4&gt;.T4')  
The fourth required component.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the game object was removed.  

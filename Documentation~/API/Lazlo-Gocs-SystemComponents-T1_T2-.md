#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs')
## SystemComponents&lt;T1,T2&gt; Class
Holds a high-performance registry of components required by a system.  
```C#
public sealed class SystemComponents<T1,T2> :
IEnumerable<(T1, T2)>,
IEnumerable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &gt; [SystemComponents&lt;T1,T2&gt;](./Lazlo-Gocs-SystemComponents-T1_T2-.md 'Lazlo.Gocs.SystemComponents&lt;T1,T2&gt;')  

Implements [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.ValueTuple](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')  
#### Type parameters
<a name='Lazlo-Gocs-SystemComponents-T1_T2--T1'></a>
`T1`  
The type of the first required component.  
  
<a name='Lazlo-Gocs-SystemComponents-T1_T2--T2'></a>
`T2`  
The type of the second required component.  
  
### Methods
- [Add(UnityEngine.GameObject)](./Lazlo-Gocs-SystemComponents-T1_T2--Add(UnityEngine-GameObject).md 'Lazlo.Gocs.SystemComponents&lt;T1,T2&gt;.Add(UnityEngine.GameObject)')
- [Add(UnityEngine.GameObject, T1, T2)](./Lazlo-Gocs-SystemComponents-T1_T2--Add(UnityEngine-GameObject_T1_T2).md 'Lazlo.Gocs.SystemComponents&lt;T1,T2&gt;.Add(UnityEngine.GameObject, T1, T2)')
- [Remove(UnityEngine.GameObject)](./Lazlo-Gocs-SystemComponents-T1_T2--Remove(UnityEngine-GameObject).md 'Lazlo.Gocs.SystemComponents&lt;T1,T2&gt;.Remove(UnityEngine.GameObject)')
- [Remove(UnityEngine.GameObject, T1, T2)](./Lazlo-Gocs-SystemComponents-T1_T2--Remove(UnityEngine-GameObject_T1_T2).md 'Lazlo.Gocs.SystemComponents&lt;T1,T2&gt;.Remove(UnityEngine.GameObject, T1, T2)')

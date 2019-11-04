#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs').[SystemComponents&lt;T1,T2,T3,T4,T5&gt;](./Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5-.md 'Lazlo.Gocs.SystemComponents&lt;T1,T2,T3,T4,T5&gt;')
## SystemComponents&lt;T1,T2,T3,T4,T5&gt;.Add(UnityEngine.GameObject, T1, T2, T3, T4, T5) Method
Adds the specified game object to the registry if it contains the required components and if it wasn't already added before.  
```C#
public bool Add(UnityEngine.GameObject go, out T1 c1, out T2 c2, out T3 c3, out T4 c4, out T5 c5);
```
#### Parameters
<a name='Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5--Add(UnityEngine-GameObject_T1_T2_T3_T4_T5)-go'></a>
`go` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')  
The game object to add.  
  
<a name='Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5--Add(UnityEngine-GameObject_T1_T2_T3_T4_T5)-c1'></a>
`c1` [T1](./Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5-.md#Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5--T1 'Lazlo.Gocs.SystemComponents&lt;T1,T2,T3,T4,T5&gt;.T1')  
The first required component.  
  
<a name='Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5--Add(UnityEngine-GameObject_T1_T2_T3_T4_T5)-c2'></a>
`c2` [T2](./Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5-.md#Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5--T2 'Lazlo.Gocs.SystemComponents&lt;T1,T2,T3,T4,T5&gt;.T2')  
The second required component.  
  
<a name='Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5--Add(UnityEngine-GameObject_T1_T2_T3_T4_T5)-c3'></a>
`c3` [T3](./Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5-.md#Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5--T3 'Lazlo.Gocs.SystemComponents&lt;T1,T2,T3,T4,T5&gt;.T3')  
The third required component.  
  
<a name='Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5--Add(UnityEngine-GameObject_T1_T2_T3_T4_T5)-c4'></a>
`c4` [T4](./Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5-.md#Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5--T4 'Lazlo.Gocs.SystemComponents&lt;T1,T2,T3,T4,T5&gt;.T4')  
The fourth required component.  
  
<a name='Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5--Add(UnityEngine-GameObject_T1_T2_T3_T4_T5)-c5'></a>
`c5` [T5](./Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5-.md#Lazlo-Gocs-SystemComponents-T1_T2_T3_T4_T5--T5 'Lazlo.Gocs.SystemComponents&lt;T1,T2,T3,T4,T5&gt;.T5')  
The fifth required component.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the game object was added.  

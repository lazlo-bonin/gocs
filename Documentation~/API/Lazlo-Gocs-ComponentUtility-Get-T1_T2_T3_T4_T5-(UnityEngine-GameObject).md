#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs').[ComponentUtility](./Lazlo-Gocs-ComponentUtility.md 'Lazlo.Gocs.ComponentUtility')
## ComponentUtility.Get&lt;T1,T2,T3,T4,T5&gt;(UnityEngine.GameObject) Method
Gets the specified components from the game object.  
```C#
public static (T1,T2,T3,T4,T5) Get<T1,T2,T3,T4,T5>(this UnityEngine.GameObject go);
```
#### Type parameters
<a name='Lazlo-Gocs-ComponentUtility-Get-T1_T2_T3_T4_T5-(UnityEngine-GameObject)-T1'></a>
`T1`  
The type of the first component.  
  
<a name='Lazlo-Gocs-ComponentUtility-Get-T1_T2_T3_T4_T5-(UnityEngine-GameObject)-T2'></a>
`T2`  
The type of the second component.  
  
<a name='Lazlo-Gocs-ComponentUtility-Get-T1_T2_T3_T4_T5-(UnityEngine-GameObject)-T3'></a>
`T3`  
The type of the third component.  
  
<a name='Lazlo-Gocs-ComponentUtility-Get-T1_T2_T3_T4_T5-(UnityEngine-GameObject)-T4'></a>
`T4`  
The type of the fourth component.  
  
<a name='Lazlo-Gocs-ComponentUtility-Get-T1_T2_T3_T4_T5-(UnityEngine-GameObject)-T5'></a>
`T5`  
The type of the fifth component.  
  
#### Parameters
<a name='Lazlo-Gocs-ComponentUtility-Get-T1_T2_T3_T4_T5-(UnityEngine-GameObject)-go'></a>
`go` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')  
The game object.  
  
#### Returns
[System.ValueTuple](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
The components. Each component can be null if not contained in the game object.  

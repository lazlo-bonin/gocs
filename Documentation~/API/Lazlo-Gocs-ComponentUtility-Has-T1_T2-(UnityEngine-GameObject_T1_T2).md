#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs').[ComponentUtility](./Lazlo-Gocs-ComponentUtility.md 'Lazlo.Gocs.ComponentUtility')
## ComponentUtility.Has&lt;T1,T2&gt;(UnityEngine.GameObject, T1, T2) Method
Checks the game object for the specified components.  
```C#
public static bool Has<T1,T2>(this UnityEngine.GameObject go, out T1 component1, out T2 component2);
```
#### Type parameters
<a name='Lazlo-Gocs-ComponentUtility-Has-T1_T2-(UnityEngine-GameObject_T1_T2)-T1'></a>
`T1`  
The type of the first component.  
  
<a name='Lazlo-Gocs-ComponentUtility-Has-T1_T2-(UnityEngine-GameObject_T1_T2)-T2'></a>
`T2`  
The type of the second component.  
  
#### Parameters
<a name='Lazlo-Gocs-ComponentUtility-Has-T1_T2-(UnityEngine-GameObject_T1_T2)-go'></a>
`go` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')  
The game object.  
  
<a name='Lazlo-Gocs-ComponentUtility-Has-T1_T2-(UnityEngine-GameObject_T1_T2)-component1'></a>
`component1` [T1](#Lazlo-Gocs-ComponentUtility-Has-T1_T2-(UnityEngine-GameObject_T1_T2)-T1 'Lazlo.Gocs.ComponentUtility.Has&lt;T1,T2&gt;(UnityEngine.GameObject, T1, T2).T1')  
The first returned component.  
  
<a name='Lazlo-Gocs-ComponentUtility-Has-T1_T2-(UnityEngine-GameObject_T1_T2)-component2'></a>
`component2` [T2](#Lazlo-Gocs-ComponentUtility-Has-T1_T2-(UnityEngine-GameObject_T1_T2)-T2 'Lazlo.Gocs.ComponentUtility.Has&lt;T1,T2&gt;(UnityEngine.GameObject, T1, T2).T2')  
The second returned component.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the game object contains all specified component types.  

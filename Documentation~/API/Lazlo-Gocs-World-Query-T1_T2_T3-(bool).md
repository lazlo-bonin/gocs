#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs').[World](./Lazlo-Gocs-World.md 'Lazlo.Gocs.World')
## World.Query&lt;T1,T2,T3&gt;(bool) Method
Finds all game objects that contain all the specified components.  
```C#
public static Lazlo.Gocs.QueryResult<(T1,T2,T3)> Query<T1,T2,T3>(bool forceNative=false);
```
#### Type parameters
<a name='Lazlo-Gocs-World-Query-T1_T2_T3-(bool)-T1'></a>
`T1`  
The type of the first component.  
  
<a name='Lazlo-Gocs-World-Query-T1_T2_T3-(bool)-T2'></a>
`T2`  
The type of the second component.  
  
<a name='Lazlo-Gocs-World-Query-T1_T2_T3-(bool)-T3'></a>
`T3`  
The type of the third component.  
  
#### Parameters
<a name='Lazlo-Gocs-World-Query-T1_T2_T3-(bool)-forceNative'></a>
`forceNative` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether a native query should be forced. Enable when querying in edit-mode.  
  
#### Returns
[Lazlo.Gocs.QueryResult&lt;](./Lazlo-Gocs-QueryResult-T-.md 'Lazlo.Gocs.QueryResult&lt;T&gt;')[System.ValueTuple](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[&gt;](./Lazlo-Gocs-QueryResult-T-.md 'Lazlo.Gocs.QueryResult&lt;T&gt;')  
The tuples of components per game object.  

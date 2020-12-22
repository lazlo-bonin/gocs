#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs').[World](./Lazlo-Gocs-World.md 'Lazlo.Gocs.World')
## World.Query&lt;T&gt;(bool) Method
Finds all game objects that contain the specified component.  
```C#
public static Lazlo.Gocs.QueryResult<T> Query<T>(bool forceNative=false);
```
#### Type parameters
<a name='Lazlo-Gocs-World-Query-T-(bool)-T'></a>
`T`  
The type of the component.  
  
#### Parameters
<a name='Lazlo-Gocs-World-Query-T-(bool)-forceNative'></a>
`forceNative` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether a native query should be forced. Enable when querying in edit-mode.  
  
#### Returns
[Lazlo.Gocs.QueryResult&lt;](./Lazlo-Gocs-QueryResult-T-.md 'Lazlo.Gocs.QueryResult&lt;T&gt;')[T](#Lazlo-Gocs-World-Query-T-(bool)-T 'Lazlo.Gocs.World.Query&lt;T&gt;(bool).T')[&gt;](./Lazlo-Gocs-QueryResult-T-.md 'Lazlo.Gocs.QueryResult&lt;T&gt;')  
The components per game object.  

#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs')
## QueryResult&lt;T&gt; Class
Holds the results from a world component query.  
Use this in a foreach loop to enumerate over the tuples of components.  
```C#
public sealed class QueryResult<T> :
IEnumerable<T>,
IEnumerable,
IPoolable,
IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &gt; [QueryResult&lt;T&gt;](./Lazlo-Gocs-QueryResult-T-.md 'Lazlo.Gocs.QueryResult&lt;T&gt;')  

Implements [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](#Lazlo-Gocs-QueryResult-T--T 'Lazlo.Gocs.QueryResult&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable'), [Lazlo.Gocs.IPoolable](https://docs.microsoft.com/en-us/dotnet/api/Lazlo.Gocs.IPoolable 'Lazlo.Gocs.IPoolable'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='Lazlo-Gocs-QueryResult-T--T'></a>
`T`  
The type of results, either a component or a tuple of components.  
  
### Remarks
This enumerable does not allocate memory when enumerating.  
However, it is disposed after a single enumeration and cannot be re-enumerated.  

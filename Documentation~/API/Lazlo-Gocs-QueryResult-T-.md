#### [API](./API.md 'API')
### [Lazlo.Gocs](./API.md#Lazlo-Gocs 'Lazlo.Gocs')
## QueryResult&lt;T&gt; `type`
Holds the results from a world component query.  
Use this in a ```foreach```
merate over the tuples of components.
### Remarks
This enumerable does not allocate memory when enumerating.  
However, it is disposed after a single enumeration and cannot be re-enumerated.
### Example
This enumerable does not allocate memory when enumerating.  
However, it is disposed after a single enumeration and cannot be re-enumerated.
### Type parameters

<a name='Lazlo-Gocs-QueryResult-T--T'></a>
`T`

The type of results, either a component or a tuple of components.

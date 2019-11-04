#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs').[World](./Lazlo-Gocs-World.md 'Lazlo.Gocs.World')
## World.enableRegistries Property
Whether cached registries should be used for managed components.  
Disable to improve initialization and destruction speed of components.  
However, when disabled, managed queries will no longer be available  
and [SystemComponents&lt;T&gt;](./Lazlo-Gocs-SystemComponents-T-.md 'Lazlo.Gocs.SystemComponents&lt;T&gt;') should be used instead.  
```C#
public static bool enableRegistries { get; set; }
```
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  

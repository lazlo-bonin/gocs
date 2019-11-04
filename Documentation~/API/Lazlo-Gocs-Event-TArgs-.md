#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs')
## Event&lt;TArgs&gt; Class
Represents an event with arguments.  
Events support assigning handlers and invoking from anywhere.  
```C#
public sealed class Event<TArgs>
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &gt; [Event&lt;TArgs&gt;](./Lazlo-Gocs-Event-TArgs-.md 'Lazlo.Gocs.Event&lt;TArgs&gt;')  
#### Type parameters
<a name='Lazlo-Gocs-Event-TArgs--TArgs'></a>
`TArgs`  
The type of argument.  
  
### Remarks
Use an arguments struct or class if you need to pass multiple arguments.  
### Constructors
- [Event()](./Lazlo-Gocs-Event-TArgs--Event().md 'Lazlo.Gocs.Event&lt;TArgs&gt;.Event()')
- [Event(System.Action&lt;TArgs&gt;)](./Lazlo-Gocs-Event-TArgs--Event(System-Action-TArgs-).md 'Lazlo.Gocs.Event&lt;TArgs&gt;.Event(System.Action&lt;TArgs&gt;)')
### Methods
- [AddHandler(System.Action&lt;TArgs&gt;)](./Lazlo-Gocs-Event-TArgs--AddHandler(System-Action-TArgs-).md 'Lazlo.Gocs.Event&lt;TArgs&gt;.AddHandler(System.Action&lt;TArgs&gt;)')
- [Invoke(TArgs)](./Lazlo-Gocs-Event-TArgs--Invoke(TArgs).md 'Lazlo.Gocs.Event&lt;TArgs&gt;.Invoke(TArgs)')
- [RemoveHandler(System.Action&lt;TArgs&gt;)](./Lazlo-Gocs-Event-TArgs--RemoveHandler(System-Action-TArgs-).md 'Lazlo.Gocs.Event&lt;TArgs&gt;.RemoveHandler(System.Action&lt;TArgs&gt;)')

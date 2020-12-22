#### [GoCS](./index.md 'index')
### [Lazlo.Gocs](./Lazlo-Gocs.md 'Lazlo.Gocs').[SystemEvents](./Lazlo-Gocs-SystemEvents.md 'Lazlo.Gocs.SystemEvents')
## SystemEvents.this[Lazlo.Gocs.Event] Property
Adds or removes a system event handler for the specified event.  
In [OnCreatedComponent(Lazlo.Gocs.IComponent)](./Lazlo-Gocs-IWorldCallbackReceiver-OnCreatedComponent(Lazlo-Gocs-IComponent).md 'Lazlo.Gocs.IWorldCallbackReceiver.OnCreatedComponent(Lazlo.Gocs.IComponent)'), pass a handler to add it to the event.  
In [OnDestroyingComponent(Lazlo.Gocs.IComponent)](./Lazlo-Gocs-IWorldCallbackReceiver-OnDestroyingComponent(Lazlo-Gocs-IComponent).md 'Lazlo.Gocs.IWorldCallbackReceiver.OnDestroyingComponent(Lazlo.Gocs.IComponent)'), pass null to remove the handler from the event.  
```C#
public System.Action this[Lazlo.Gocs.Event @event] { get; set; }
```
#### Parameters
<a name='Lazlo-Gocs-SystemEvents-this-Lazlo-Gocs-Event--event'></a>
`event` [Event](./Lazlo-Gocs-Event.md 'Lazlo.Gocs.Event')  
The event on which to add or remove the handler.  
  
#### Returns
[System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')  
### Remarks
System events can only add one handler per event.  

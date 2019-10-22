#### [API](./API.md 'API')
### [Lazlo.Gocs](./API.md#Lazlo-Gocs 'Lazlo.Gocs').[SystemEvents](./Lazlo-Gocs-SystemEvents.md 'Lazlo.Gocs.SystemEvents')
## this[Lazlo.Gocs.Event] `index`
Adds or removes a system event handler for the specified event.  
In [OnCreatedComponent(Lazlo.Gocs.IComponent)](./Lazlo-Gocs-IWorldCallbackReceiver-OnCreatedComponent(Lazlo-Gocs-IComponent).md 'Lazlo.Gocs.IWorldCallbackReceiver.OnCreatedComponent(Lazlo.Gocs.IComponent)'), pass a handler to add it to the event.  
In [OnDestroyingComponent(Lazlo.Gocs.IComponent)](./Lazlo-Gocs-IWorldCallbackReceiver-OnDestroyingComponent(Lazlo-Gocs-IComponent).md 'Lazlo.Gocs.IWorldCallbackReceiver.OnDestroyingComponent(Lazlo.Gocs.IComponent)'), pass null to remove the handler from the event.
### Remarks
System events can only add one handler per event.
### Example
System events can only add one handler per event.
### Parameters

<a name='Lazlo-Gocs-SystemEvents-Item(Lazlo-Gocs-Event)-event'></a>
`event`

The event on which to add or remove the handler.
### Returns
The event handler.

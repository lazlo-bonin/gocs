#### [GoCS](./GoCS.md 'GoCS')
### [Lazlo.Gocs](./GoCS.md#Lazlo-Gocs 'Lazlo.Gocs').[SystemEvents&lt;TArgs&gt;](./Lazlo-Gocs-SystemEvents-TArgs-.md 'Lazlo.Gocs.SystemEvents&lt;TArgs&gt;')
## this[Lazlo.Gocs.Event&lt;TArgs&gt;] `index`
Adds or removes a system event handler for the specified event.  
In [OnCreatedComponent(Lazlo.Gocs.IComponent)](./Lazlo-Gocs-IWorldCallbackReceiver-OnCreatedComponent(Lazlo-Gocs-IComponent).md 'Lazlo.Gocs.IWorldCallbackReceiver.OnCreatedComponent(Lazlo.Gocs.IComponent)'), pass a handler to add it to the event.  
In [OnDestroyingComponent(Lazlo.Gocs.IComponent)](./Lazlo-Gocs-IWorldCallbackReceiver-OnDestroyingComponent(Lazlo-Gocs-IComponent).md 'Lazlo.Gocs.IWorldCallbackReceiver.OnDestroyingComponent(Lazlo.Gocs.IComponent)'), pass null to remove the handler from the event.
### Remarks
System events can only add one handler per event.
### Example
System events can only add one handler per event.
### Parameters

<a name='Lazlo-Gocs-SystemEvents-TArgs--Item(Lazlo-Gocs-Event-TArgs-)-event'></a>
`event`

The event on which to add or remove the handler.
### Returns
The event handler.

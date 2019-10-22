# GameObject Component System (GoCS) for Unity

💡 GoCS (pronounced ***go-cee-ess***) is a design pattern for Unity. It's inspired by entity component system (ECS), but it works with the existing Unity GameObject + Component architecture, hence the name. It's also more flexible and less strict than ECS. As such, it's easy to get started using the concepts and API you're already familiar with. 

🏁 The goal of GoCS is to help you write code that is readable, reusable and maintanable. It elegantly scales to any project size, from small to big. If you ever found yourself asking "where should I put this code?", then GoCS is here to help.

🔀 To be clear, GoCS is entirely unrelated to Unity's new [data oriented tech stack (DOTS)](https://unity.com/dots).

🎓 Before you continue, if you're a bit confused with acronyms and concepts like ECS, OOP, IOC or DOTS, you should start with this basic introduction: [Intro: OOP vs ECS in Unity](Documentation~/Manual/Intro.md)

# Why GoCS?

GoCS helps solve some common headaches when developing Unity projects:

- You use OOP, but your component inheritance hierarchy quickly becomes messy
- You use ECS, but you are constantly writing boilerplate code for simple tasks
- You need an event system, but you're unsure how to implement them properly

In tech lingo, GoCS excels at combining encapsulation, composition and inversion of control.

|**Benefit**|**OOP**|**ECS**|**GoCS**|
|---|---|---|---|
|Encapsulation|✅|⛔|✅|
|Scalability|⛔ (Inheritance)|✅ (Composition)|✅ (Both)|
|Inversion of Control|⛔|⛔|✅|
|High Performance|⛔|✅ (DOTS)|⛔|

GoCS is **not** for you if you need the high performance benefits of multi-threading, burst compiling, and memory layouting. For those case, you should use [DOTS](https://unity.com/dots).

# Getting Started

GoCS is a very lightweight framework imported from the Unity Package Manager.

### Requirements

GoCS requires **Unity 2018.4** **or newer**.

### Installing

To import GoCS, open `Packages/manifest.json` and add this line under `dependencies`:

```json
"dev.lazlo.gocs": "https://github.com/lazlo-bonin/gocs.git"
```

### Updating

To update GoCS, open `Packages/manifest.json` and **remove** the `dev.lazlo.gocs` entry under `lock` at the end of the file.

### Namespace

All the GoCS API is under the `Lazlo.Gocs` namespace:

```csharp
using Lazlo.Gocs;
```

### License

GoCS is shared under the **MIT License**. This means you're free to use and redistribute it in your games and other projects, even commercially. For the full license, see [LICENSE.md](LICENSE.md).

# GoCS in a nutshell

GoCS is designed to be simple to implement. Once you wrap your head around the core concepts below, you should be able to start using it with only the basics of C# and Unity. 

GoCS is **similar** to traditional ECS: it's organized as **E**ntities, **C**omponents and **S**ystems.

|**Concept**|**Purpose**|**Related API**|
|---|---|---|
|⛓ Entities|Empty shells that link Components together|`GameObject`
|🧩 Components|Define data for runtime and authoring for the editor|`IComponent` + `BaseComponent`
|⚙️ Systems|Perform common logic on batches of components|`BaseSystem`

GoCS is **different** from traditional ECS in two ways:

1. Components are separated in two layers: the **Interface** and the **Class(es)**. Systems only operate on component interfaces. But component classes can add extra logic, data, attributes or even inheritance and couplings if they need to. (Don't worry if that sounds abstract for now, it'll become clearer with examples!)
2. Systems are in charge of event dispatch. In other words, they decide when to send events back to the components. This is what's called **"inversion of control"**: your components don't need to handle their own event *conditions*, they only need to handle their event *reactions*.

# Example

Let's say we have a first person game where the player can interact with objects in the world.

We want to use GoCS to create a setup where all the code to hover and click objects is handled by a common System, so that our Components only need to implement the reactions to those events.

## Step 1: Create the Component Interface

Let's start by creating a component interface that defines interactable objects. 

The component interface is responsible for declaring:

- 🎛 **Attributes:** Immutable (read-only) properties needed by the system.
- 📦 **Data:** Mutable (read+write) properties needed by the system.
- ⚡️ **Events:** Callbacks that the system can trigger or register.

```csharp
// Component Interfaces must implement the IComponent interface
public interface IInteractable : IComponent
{
    // Attributes 
    // (immutable, so only { get; })
    float range { get; }

    // Data 
    // (mutable, so both { get; set; })
    bool isHovered { get; set; }
    bool isPressed { get; set; }

    // Events 
    // (only { get; })
    // ("Event" is a minimal event wrapper class included in the GoCS API)
    Event onHoverEnter { get; }
    Event onHoverExit { get; }
    Event onPress { get; }
    Event onRelease { get; }
}
```

## Step 2: Create the Component Class(es)

The component class is responsible for providing attribute values and handling events.

In GoCS, you can define more than one component class per component interface. That's very powerful, because they will all reuse the same logic from the system without having to resort to inheritance. Therefore, each of these classes stays simple and focused on a single responsibility. 

To demonstrate that, we'll create two different interactable classes from the same interactable interface.

### 2.1. Grabbable

The grabbable component allows the player to move an object around by clicking and holding it. It does so by simply changing the object's transform parent to the main camera.

```csharp
// Component Classes are derived from the BaseComponent class
// They must also implement their matching Component Interface
public class Grabbable : BaseComponent, IInteractable
{
    // Attributes
    // (Tip: use [SerializeField] to expose the range field to the inspector
    // while also implementing the interface's range property.)
    [SerializeField] 
    private float _range = 5;
    public float range 
    {
        get => _range;
        set => _range = value;
    }
    
    // Data
    public bool isHovered { get; set; }
    public bool isPressed { get; set; }

    // Events
    public Event onHoverEnter { get; private set; }
    public Event onHoverExit { get; private set; }
    public Event onPress { get; private set; }
    public Event onRelease { get; private set; }

    // Initialization
    protected override void Awake()
    {
        base.Awake();
        
        // Create events and link them to our handlers
        onPress = new Event(Grab);
        onRelease = new Event(LetGo);
    }

    // Extra Logic

    private void Grab()
    {
        transform.parent = Camera.main.transform;
    }

    private void LetGo()
    {
        transform.parent = null;
    }
}
```

### 2.2. Highlightable

The highlightable component changes the object's color when it gets hovered, and sets it back to its normal color afterwards. 

This component makes use of GoCS' ability to add extra attributes, data and couplings to  component classes when you need to.

```csharp
[RequireComponent(typeof(Renderer))]
public class Highlightable : BaseComponent, IInteractable
{
    // Attributes
    [SerializeField]
    private float _range = 5;
    public float range 
    {
        get => _range;
        set => _range = value;
    }
    
    // Data
    public bool isHovered { get; set; }
    public bool isPressed { get; set; }

    // Events
    public Event onHoverEnter { get; private set; }
    public Event onHoverExit { get; private set; }
    public Event onPress { get; private set; }
    public Event onRelease { get; private set; }

    // Extra Attributes
    [SerializeField]
    private Color _color = Color.yellow;
    public Color color 
    {
        get => _color;
        set => _color = value;
    }

    // Extra Data
    private Color normalColor;

    // Extra Coupling
    private Renderer renderer;

    // Initialization
    protected override void Awake()
    {
        base.Awake();
        renderer = GetComponent<Renderer>();
        onHoverEnter = new Event(Highlight);
        onHoverExit = new Event(ResetColor);
    }
    
    // Extra Logic

    private void Highlight()
    {
        normalColor = renderer.material.color;
        renderer.material.color = color;
    }

    private void ResetColor()
    {
        renderer.material.color = normalColor;
    }
}
```

## Step 3: Create the System

The system is a class responsible for implementing the reusable logic and for triggering events.

Here, we'll create a basic system that uses a raycast to find the object below the player's cursor at the center of the screen. 

It stores and compares the currently hovered and pressed objects across frames to determine when they change and trigger the related events accordingly.

```csharp
// Systems are derived from the BaseSystem class
public class InteractionSystem : BaseSystem
{
    private IInteractable hovered;
    private IInteractable pressed;

    private void Update()
    {
        if (pressed == null)
        {
            var camera = Camera.main;
            var ray = new Ray(camera.transform.position, camera.transform.forward);

            IInteractable interactable = null;

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, (LayerMask)~0))
            {
                interactable = hit.collider.gameObject?.GetComponentInParent<IInteractable>();

                if (interactable != null && hit.distance > interactable.range)
                {
                    interactable = null;
                }
            }

            if (interactable != hovered)
            {
                if (hovered != null)
                {
                    hovered.onHoverExit?.Invoke();
                    hovered.isHovered = false;
                }

                hovered = interactable;

                if (hovered != null)
                {
                    hovered.onHoverEnter?.Invoke();
                    hovered.isHovered = true;
                }
            }

            if (hovered != null && Input.GetMouseButtonDown(0))
            {
                pressed = hovered;
                pressed.onPress?.Invoke();
                pressed.isPressed = true;
            }
        }

        if (pressed != null && Input.GetMouseButtonUp(0))
        {
            pressed.onRelease?.Invoke();
            pressed.isPressed = false;
            pressed = null;
        }
    }
}
```

## 4. (Optional) Base Component Class

Because GoCS allows inheritance in component classes, you can reduce the amount of boilerplate even further.

For example, you could create a `BaseInteractable` class from which `Grabbable` and `Highlightable` inherit.

```csharp
// BaseInteractable.cs

public abstract class BaseInteractable : BaseComponent, IInteractable
{
    protected override void Awake()
    {
        base.Awake();
        onHoverEnter = new Event(OnHoverEnter);
        onHoverExit = new Event(OnHoverExit);
        onPress = new Event(OnPress);
        onRelease = new Event(OnRelease);
    }

    // Attributes
    [SerializeField]
    private float _range = 5;
    public float range 
    {
        get => _range;
        set => _range = value;
    }

    // Data
    public bool isHovered { get; set; }
    public bool isPressed { get; set; }

    // Events
    public Event onHoverEnter { get; private set; }
    public Event onHoverExit { get; private set; }
    public Event onPress { get; private set; }
    public Event onRelease { get; private set; }

    // Event Handlers
    protected virtual void OnHoverEnter() { }
    protected virtual void OnHoverExit() { }
    protected virtual void OnPress() { }
    protected virtual void OnRelease() { }
}
```

Then, the derived classes become extremely simple and eloquent, which is the the ultimate goal of GoCS! 

For example, `Grabbable` now only needs a dozen lines of code:

```csharp
public class Grabbable : BaseInteractable
{
    protected override void OnPress()
    {
        transform.parent = Camera.main.transform;
    }

    protected override void OnRelease()
    {
        transform.parent = null;
    }
}
``` 

Neat! ✨

---

# Advanced Use

## Component Queries

In ECS patterns, you'll typically want systems to operate on GameObjects that share a set of components. 

GoCS provides helpers to make that easy. These helpers use `out` parameters and the [tuple deconstruction syntax](https://docs.microsoft.com/en-us/dotnet/csharp/deconstruct) to keep the code readable.

For the following examples, we'll pretend we want a health regeneration system that slowly regens the health of game objects that have both `IHealth` and `IRegenable` components attached.

On individual GameObjects, you an use the `Has` and `Get` to fetch sets of components.

### GameObject.Has

`Has` will only return true if all the components are found on the given object:

```csharp
if (gameObject.Has(out IHealth health, out IRegenable regenable))
{
    health.value += regenable.healthPerSecond * Time.deltaTime;
}
```

### GameObject.Get
`Get` will always return a tuple of components, but some of them may be null if they are not on the object. Only use it if you know for certain that all components are present.

```csharp
var (health, regenable) = gameObject.Get<IHealth, IRegenable>();

if (health != null && regenable != null)
{
    health.value += regenable.healthPerSecond * Time.deltaTime;
}
```

### World.Query

Typically, systems will want to run a `foreach` loop on all game objects that share a set of components. To do that, you can use `World.Query`. Unlike `FindObjectsOfType`, this method is optimized for speed and allocates zero byte of memory.

```csharp
class HealthRegenSystem : BaseSystem
{
    void Update()
    {
        foreach (var (health, regenable) in World.Query<IHealth, IRegenable>())
        {
            health.value += regenable.healthPerSecond * Time.deltaTime;
        }
    }
}
```

If you need to use a world query in the while in edit-mode, you must pass `true` to the `forceNative` argument of the `World.Query` method. This will make it revert to the slower `FindObjectsOfType` in the background, which is required because the components are only properly cached during play mode.

For example, if we wanted to draw a gizmo for the range of each of our interactables, we could add this code to the interaction system:

```csharp
class InteractionSystem : BaseSystem
{
    // (Previous code...)

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        foreach (var interactable in World.Query<IInteractable>(forceNative: true))
        {
            Gizmos.DrawWireSphere(interactable.transform.position, interactable.range);
        }
    }
}
```

### SystemComponents

For even better performance, you can use the `SystemComponents` helper generic class.

This class will keep a extremely fast and lean registry of components, but you must add and remove components to it manually.

GoCS makes this easy with the `OnCreatedComponent` and `OnDestroyingComponent` callbacks in `BaseSystem`. Let's rewrite our health regen system with this approach:

```csharp
class HealthRegenSystem : BaseSystem
{
    // Declare and initialize the SystemComponents helper
   SystemComponents<IHealth, IRegenable> components = new SystemComponents<IHealth, IRegenable>();
    
    // OnCreatedComponent is sent to all systems when a new component is created
    public override void OnCreatedComponent(IComponent component)
    {
        // Add the component to our SystemComponents
        // (The API takes care of making sure it has the right components for us)
        components.Add(component);
    }
    
    // OnDestroyingComponent is sent to all systems before an existing component is destroyed
    public override void OnDestroyingComponent(IComponent component)
    {
        // Remove the component from our SystemComponents
        components.Remove(component);
    }
        
    void Update()
    {
        // Enumerate over the SystemComponents instead of using World.Query
        foreach (var (health, regenable) in components)
        {
            health.value += regenable.healthPerSecond * Time.deltaTime;
        }
    }
}
```

You can also use multiple SystemComponents in a single system if you need to.

### Performance Comparison

GoCS includes a benchmark of the different query methods in the samples. This benchmark tests a two-component query over **10,000 game objects** at every frame.

|Method|API|Time (lower is better)|Allocation (lower is better)|
|---|---|---|---|
|Native Query|`World.Query(true)`|🛑 36.28ms|🔴 195.2 KB
|Managed Query|`World.Query()`|⚠️ 13.58ms|❇️ 0 byte
|System Query|`SystemComponents`|✅ 0.16ms|❇️ 0 byte

Obviously, using system components is the fastest alternative, clocking in at almost 200x faster than Unity's `FindObjectsOfType`.

---

## Component Requirements

Sometimes, components only make sense when coupled with other components.

For example, an `IRegenable` component might always require a `IHealth` component.

There are a few ways you can go about this.

The most simple is to require a component to appear with another with Unity's built-in `[RequireComponent]` attribute:

```csharp
[RequireComponent(typeof(IHealth))]
interface IRegenable : IComponent { }
```

This will force the component to be added while in the editor. But if you don't need to configure any property on the required component, you might not want to pollute your game objects while authoring in the editor. This is often the case when using GoCS event proxies (see section below). In those cases, you can use GoCS' custom `[RuntimeRequireComponent]` attribute:

```csharp
[RuntimeRequireComponent(typeof(CollisionEventProxy))]
interface IDestructible : IComponent { }
```

Finally, if you don't want to (or can't) specify dependencies on the components themselves, you can require components directly from the system, during the `OnCreatedComponent ` phase. For example, if `IDestructible` components always need a matching `CollisionEventProxy` component, you could do so using the `GetOrAddComponent` helper:

```csharp
class ZoneSystem : BaseSystem
{
    public override void OnCreatedComponent(IComponent component)
    {
        if (component is IDestructible destructible)
        {
            destructible.gameObject.GetOrAddComponent<CollisionProxy>();
        }
    }
}
```

---

## Event Arguments

If you need to pass in arguments to GoCS events, you can use the generic version of Event.

For example, if you need an damage event that passes the amount of damage, you could write:

```csharp
interface IDamageable : IComponent
{
    Event<int> onDamage { get; }
}
```

Your handlers signatures would then need to take that parameter:

```csharp
class Damageable : IDamageable
{
    public Event<int> onDamage { get; private set; }

    public float health { get; set; } = 100;

    protected override void Awake()
    {
        base.Awake();
        onDamage = new Event(OnDamage);
    }

    private void OnDamage(int damage)
    {
        health -= damage;
    }
}
```

And when invoking the event, you'll need to pass the damage argument:

```csharp
damageable.onDamage.Invoke(5);
```

If you need more than one event argument, you can create an arguments struct (or class).

For example, if you wanted to add an elemental type to your damage event, you could write:

```csharp
enum Element
{
    Fire,
    Water,
    Wind,
    Earth
}

struct DamageEventArgs
{
    public int amount { get; }
    public Element element { get; }

    public DamageEventArgs(int amount, Element element)
    {
        this.amount = amount;
        this.element = element;
    }
}

interface IDamageable : IComponent
{
    Event<DamageEventArgs> onDamage { get; }
}
```

---

## Event Handlers

Events can have zero, one or multiple handlers.

Unlike C# events, GoCS events can be triggered from outside their parent class. This is the trick that lets systems manage the event dispatch.

There are two styles you can use to declare events. These two styles are functionally identical. It's just a matter of preference!

On one hand, you can make the event property `{ get; private set; }` and use the constructor that specifies the handler in `Awake`. For example:

```csharp
class Destructible : BaseComponent
{
    public Event onDestroy { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        onDestroy = new Event(OnDestroyHandler);
    }
    
    private void OnDestroyHandler()
    {
        // ...
    }
}
```

Or, if you prefer, you can make the event propery `{ get; }` only and initialize it inline, then use the `AddHandler` method in `Awake`:

```csharp
class Destructible : BaseComponent
{
    public Event onDestroy { get; } = new Event();
    
    protected override void Awake()
    {
        base.Awake();
        onDestroy.AddHandler(OnDestroyHandler);
    }
    
    private void OnDestroyHandler()
    {
        // ...
    }
}
```

### Null Events

By convention, GoCS allows event properties to stay null (uninitialized) if your doesn't need them. To avoid errors, your systems should therefore always use the null-coalesce operator `?.` before invoking events:

```csharp
destructible.onDestroy?.Invoke();
```

### C# 8

Whenever Unity will start supporting C# 8 (currently [planned for the 2020 cycle](https://forum.unity.com/threads/unity-c-8-support.663757/#post-5056769)), you'll be able to use the new [default interface implementations](https://devblogs.microsoft.com/dotnet/default-implementations-in-interfaces/) feature to further reduce the amount of boilerplate for events.

Indeed, the component interface will be able to define a null getter for events by default, meaning they assume their implementation don't care about the event unless they specifically override them.

For example:

```csharp
interface IInteractable : IComponent
{
    // Default interface implementation (no event handling)
    Event onHoverEnter => null;
    Event onHoverExit => null;
    Event onPress => null;
    Event onRelease => null;
}

class Grabbable : BaseComponent, IInteractable
{
    public Event onPress { get; } = new Event();
    public Event onRelease { get; } = new Event();
    // No need to implement onHoverEnter and onHoverExit!
}
```

---

## Event Proxies & System Events

Unity's event system is limited because it does not allow external objects to add event handlers.

For example, you cannot listen to a collider's `OnCollisionEnter` event unless you create a MonoBehaviour script on the *same* GameObject.

This is problematic for GoCS, because your Systems don't live on the same GameObject as your Components, and yet they are reponsible for event dispatch!

To fix that issue, GoCS introduces something called event **proxies**. Proxies are small components packaged with GoCS that just forward the built-in Unity messages like  `OnCollisionEnter`, `OnTriggerEnter`, `OnTransformParentChanged`, etc. to normal GoCS events that we can then use in our systems.

For example, here is how the collision proxy is implemented behind the scenes:

```csharp
public sealed class CollisionProxy : BaseComponent
{
    public Event<Collision> onEnter { get; } = new Event<Collision>();
    public Event<Collision> onStay { get; } = new Event<Collision>();
    public Event<Collision> onExit { get; } = new Event<Collision>();

    private void OnCollisionEnter(Collision collision)
    {
        onEnter.Invoke(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        onStay.Invoke(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        onExit.Invoke(collision);
    }
}
```

Let's say you wanted to implement a procedural destruction system with GoCS. When objects with the `IDestructible` component collide with enough force, then the `DestructionSystem` system should break them to pieces and send back an `onDestroy` event. We'll need to to use `CollisionProxy` for that purpose. 

First, your component must require the proxy:

```csharp
[RuntimeRequireComponent(typeof(CollisionProxy))]
interface IDestructible : IComponent
{
    float requiredForce { get; }
    Event onDestroy { get; }
}
```

Then, your system must add and remove listeners to the collision events in its `OnCreatedComponent` and `OnDestroyingComponent` phases. 

To do that, you must use a `SystemEvents` helper.

```csharp
class DestructionSystem : BaseSystem
{   
    // Helper class to assign event handlers
    SystemEvents<Collision> collisionEvents = new SystemEvents<Collision>();

    public override void OnCreatedComponent(IComponent c)
    {
        if (c.gameObject.Has(out IDestructible destructible, out CollisionProxy collidable))
        {
            // Add the system event handler on the proxy
            collisionEvents[collidable.onEnter] = collision => OnCollision(destructible, collision);
        }
    }

    public override void OnDestroyingComponent(IComponent c)
    {
        if (c.gameObject.Has(out IDestructible destructible, out CollisionProxy collidable))
        {
            // Remove the system event handler from the proxy
            collisionEvents[collidable.onEnter] = null;
        }
    }

    void OnCollision(IDestructible destructible, Collision collision)
    {
        // Do the condition check and send back the event to the component
        if (collision.impulse.magnitude >= destructible.requiredForce)
        {
            destructible.onDestroy?.Invoke();
            // Here you could also add common code for destruction VFX...
        }
    }
}
```

### SystemComponents Shorthands

You'll often also want to use a `SystemComponents` for performance at the same time as registering `SystemEvents`. Because this is a very common pattern with GoCS, there are overloads that combine `Add` and `Has` in one call for convenience.

For example, if you also had:

```csharp
SystemComponents<IDestructible, ICollisionProxy> components = // ...
```

Then you could rewrite:

```csharp
public override void OnCreatedComponent(IComponent c)
{
    components.Add(c.gameObject);
    
    if (c.gameObject.Has(out IDestructible destructible, out CollisionProxy collidable))
    {
        collisionEvents[collidable.onEnter] = collision => OnCollision(destructible, collision);
    }
}
```

To the single-line:

```csharp
public override void OnCreatedComponent(IComponent c)
{
    if (components.Add(c.gameObject, out IDestructible destructible, out CollisionProxy collidable))
    {
        collisionEvents[collidable.onEnter] = collision => OnCollision(destructible, collision);
    }
}
```

Thanks to these helpers, our system code stays very readable:

```csharp
class DestructionSystem : BaseSystem
{
    SystemComponents<IDestructible, ICollisionProxy> components = new SystemComponents<IDestructible, ICollisionProxy>();
    
    SystemEvents<Collision> collisionEvents = new SystemEvents<Collision>();

    public override void OnCreatedComponent(IComponent c)
    {
        if (components.Add(c.gameObject, out IDestructible destructible, out CollisionProxy collidable))
        {
            collisionEvents[collidable.onEnter] = collision => OnCollision(destructible, collision);
        }
    }

    public override void OnDestroyingComponent(IComponent c)
    {
        if (components.Remove(c.gameObject, out IDestructible destructible, out CollisionProxy collidable))
        {
            collisionEvents[collidable.onEnter] = null;
        }
    }

    void OnCollision(IDestructible destructible, Collision collision)
    {
        if (collision.impulse.magnitude >= destructible.requiredForce)
        {
            destructible.onDestroy?.Invoke();
        }
    }
}
```

---

## Custom Base Classes

GoCS come packaged with `BaseComponent` and `BaseSystem` base classes to get you started quickly.

Both of these classes are derived from `MonoBehaviour`.

However, if you need your components or systems to derive from other root classes, you don't have to use those provided by GoCS. You only have to implement the `IComponent` and `ISystem` interfaces. The API provides a `BaseImplementation` static helper class that makes this process easy and future-proof.

### Custom Base Component

Let's say you are making an online game with UNET and thus need to use `NetworkBehaviour` instead of MonoBehaviour as your base component type.

To make it GoCS-compatible, you could create your own `BaseNetworkComponent` class:

```csharp
// Derive from NetworkBehaviour and implement IComponent
public abstract class BaseNetworkComponent : NetworkBehaviour, IComponent
{
    // Forward to BaseImplementation

    protected virtual void Awake()
    {
        BaseImplementation.ComponentAwake(this);
    }

    protected virtual void OnEnable()
    {
        BaseImplementation.ComponentOnEnable(this);
    }

    protected virtual void OnDisable()
    {
        BaseImplementation.ComponentOnDisable(this);
    }

    protected virtual void OnDestroy()
    {
        BaseImplementation.ComponentOnDestroy(this);
    }
}
```

### Custom Base System

Systems follow the same principle: you can implement your own `ISystem` via `BaseImplementation` helpers.

However, if you want to receive the `OnCreatedComponent` and `OnDestroyingComponent` callbacks, you also need to implement the `IWorldCallbackReceiver` class. This interface is optional in case you don't need those callbacks in your system and want minimize its initialization cost. `BaseSystem` always implements `IWorldCallbackReceiver`.

Finally, systems also don't theoretically need to inherit from `MonoBehaviour` or even `UnityEngine.Object`. They could live in singletons, scriptable objects, or any other kind of class you have in your architecture. As long as you call Awake + OnEnable when the system "starts" and OnDisable + OnDestroy when the system "stops", everything should work.

```csharp
// Implement ISystem as a non-UnityEngine.Object class.
public abstract class MyBaseSystem: ISystem, IWorldCallbackReceiver
{
    // (Required) Forward lifecycle events to BaseImplementation:

    public void Start()
    {
        BaseImplementation.SystemAwake(this);
        BaseImplementation.SystemOnEnable(this);
    }

    public void Stop()
    {
        BaseImplementation.SystemOnDisable(this);
        BaseImplementation.SystemOnDestroy(this);
    }
    
    // (Optional) Implement IWorldCallbackReceiver:
    public virtual void OnCreatedComponent(IComponent component) { }
    public virtual void OnDestroyingComponent(IComponent component) { }
}
```

---

## Mixing GoCS with OOP

It's perfectly fine to mix GoCS with OOP. In fact, that's one of its main benefits! You should think of GoCS as just another tool in your development toolbox, not as a pattern you *have* to use everywhere.

For example, if you have a player controller class that works well as a self-contained, encapsulated object, then you should keep it that way. No need to split it into entities, components and systems unless it makes sense to you. As the saying goes, *if it ain't broke, don't fix it*.

Likewise, if you use an entire other architectural pattern for other parts of your codebase, for example model-view-component (MVC) for your GUI code, you don't need to convert that. GoCS can happily coexist in parallel of all your existing codebase.

GoCS is also designed to let you progressively add it to an existing OOP architecture.

There's no downside and very minimal overhead to having every component in your project derive from BaseComponent, even if you don't use Systems with them. But if for whatever reason you don't want all your components to derive from IComponent, you could create a more flexible base component class that will only use GoCS on derived classes that implement IComponent. This way, you can reuse it as a common base for classes that are GoCS-aware and classes that aren't. For example:

```csharp
// Don't implement IComponent yet, let the derived classes do that.
public abstract class MyBaseComponent: MonoBehaviour
{
    // Forward to BaseImplementation if this is a GoCS component.

    protected virtual void Awake()
    {
        if (this is IComponent component)
        {
            BaseImplementation.ComponentAwake(this);
        }
    }

    protected virtual void OnEnable()
    {
        if (this is IComponent component)
        {
            BaseImplementation.ComponentOnEnable(this);
        }
    }

    protected virtual void OnDisable()
    {
        if (this is IComponent component)
        {
            BaseImplementation.ComponentOnDisable(this);
        }
    }

    protected virtual void OnDestroy()
    {
        if (this is IComponent component)
        {
            BaseImplementation.ComponentOnDestroy(this);
        }
    }
}
```

You can then start adding GoCS at any level in your inheritance hierarchy.

Let's say you have the following inheritance hierarchy:

```csharp
public class Character : MyBaseComponent { }
  public class Player : Character { }
  public class NPC : Character { }
```

Later on in your development process, you realize that NPCs should be interactable to start a conversation. But you don't want player characters to be interactable, because that wouldn't make sense. Instead of rearchitecting your existing classes (that work just fine as is!), you can tackle on GoCS by simply adding component interfaces like IInteractable lower in the chain:

```csharp
public class Character : MyBaseComponent { }
  public class Player : Character { }
  public class NPC : Character, IInteractable { } // Minor change, big benefits!
```

All NPC would have to implement is the members needed by the IInteractable component interface, for example its interaction range and events. With minimal changes to your existing code, you now benefit from the full `InteractionSystem` we created earlier.

---

## More Examples

The GoCS package comes bundled with optional commented examples.

If you're using Unity 2019 or newer, you can import them in your project directly from the Package Manager 2.0 interface. 

If you're on Unity 2018, you can find them under the `Samples~/` directory of the package and copy them to your project manually.

## Forking & Contributing

See: [CONTRIBUTING.md](./CONTRIBUTING.md)

## API Reference

See: [API Reference](./Documentation~/API/API.md)

## Development Status

GoCS is not yet guaranteed to be production ready. There may be breaking API changes in the future. In that case, since GoCS uses [Semantic Versioning](https://semver.org), a new major version number will be used. 

I'm open to suggestions and appreciate bug reports. If you have any, just create a new issue on Github!

## Special Thanks

- Alvaro Salvagno for early feedback and testing
- Tor Vesteergard for various optimization tips
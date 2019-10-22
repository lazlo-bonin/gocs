# Intro: OOP vs ECS in Unity

> *Feel free to skip ahead if you're already familiar with those things! I just want to give a quick refresher over these notions and explain how they apply to Unity.*

## OOP

**Object Oriented Programming (OOP)** is the most widespread philosophy when it comes to software architecture. It's popular because it proposes a metaphor that's intuitive to the human brain: an object is something (*a cat*) that has properties (*a color*) and behaviours (*meowing*). 

In other words, in OOP, you define objects through **classes**, which combine **both**:

- **Data** 
(variables/fields/properties/state)
- **Logic** 
(methods/functions/events)

Another core staple of OOP is **inheritance** (and polymorphism). In a nutshell, this means classes can derive from other classes to modify or extend their functionality. For example, the cat class could extend the feline base class, which in turn extends the animal base class. This inheritance is what lets you reuse code in OOP.

## ECS

**Entity Component System (ECS)** is a newer and increasingly popular software architecture philosophy that essentially does three things differently:

1. Split classes into 3 "archetypes" (hence the name!)
    - **Entities**
    - **Components**
    - **Systems**
2. **Decouple** the data from the logic:
    1. **Data** ⇒ goes into Components
    2. **Logic** ⇒ goes in Systems
3. Prefer **composition over inheritance**:

    Entities are just empty shells. They cannot be derived or inherited. Instead, you attach components to them to define what they are and what they do.

## Comparison

|**Comparison**|**OOP**|**ECS**|
|-|-|-|
|🎛 Data is defined in...|Object|Component|
|⚙ Logic is defined in...|Object|System|
|♻ Code is reused via...|Inheritance (Polymorphism)|Composition (Entities)|

## Why is ECS good for games?

That's obviously a *very simplified* summary, but hopefully it gets the general idea across. The next question is then of course: what are the benefits of OOP vs ECS in a game development context? Robbin Marcus explained it very eloquently in his [blog](http://robbinmarcus.blogspot.com/2016/07/the-next-step-in-entity-component.html), so I'll just quote him:

> The main reason to use OOP for games, was that the concept is easy to grasp. You create a hierarchy for all objects, and code reuse is introduced by polymorphism. In the diagram below you can see an example of OOP used in a game engine.

![OOP Diagram](http://www.gamedev.net/uploads/monthly_04_2013/ccs-191538-0-23879000-1364824618.png)

> It's clear to see that the EvilTree can't fit in the hierarchy, because it would require inheritance from both static and dynamic entities.

> The entity component system is designed to solve the problem stated above. The structure above would look as follows in an ECS:

![ECS Diagram](https://www.gamedev.net/uploads/monthly_04_2013/ccs-191538-0-49103500-1364824907.png)

> Where you can see that all the objects are derived from different components. The components can be reused for any object, this makes it easy to add new entities.

---

# "Impure" ECS in Unity: the architecture today

Seeing those diagrams, you might think that Unity already uses ECS... and you'd be right! 

*Kind of.*

Indeed, since its beginnings, Unity has chosen to adopt a design that's conceptually *close* to ECS because of how flexible and intuitive it is. To quote [Lucas Meijer](https://blogs.unity3d.com/2019/03/08/on-dots-entity-component-system/), tech director at Unity:

> Unity has always been centered around the concepts of components. You add a Rigidbody component to a GameObject and it will start falling. You add a Light component to a GameObject and it will start emitting light. Add an AudioEmitter component and the GameObject will start producing sound. It’s a very natural concept for programmers and non-programmers alike, and easy to build intuitive UIs for. I’m actually quite amazed at how well this concept has aged. So well that we want to keep it.

In that terminology, we could say that:

- Entity = GameObject (an empty shell that can host multiple components)
- Components = literally the components of the GameObject

Let's call this design **"impure" ECS** for the purpose of this writeup.

Why is it *impure*?

Because unlike a pure ECS architecture, defining data is not the component's *only* job, which breaks the pure data principle. Indeed, drawing inspiration from the OOP philosophy, Unity allows components to define methods and handle events. Therefore, components bundle their own logic, which is contrary to the ECS definition of a component. 

For example, the rigidbody component has an `AddForce()` method and handles an `OnCollisionEnter()` event. While convenient, these helpers imply that components are no longer pure data, which is a requirement for "pure" ECS... and the performance benefits that come from it. More on that later.

In the mean time, what about that last S? Where are the Systems? 

In all the examples above, the components themselves don't handle all their logic internally. For example, the physics calculations are *not* done inside the Rigidbody class; the light rendering operations are *not* done within on the Light class; and the sound output is *not* managed inside the AudioEmitter class.

Instead, the logic happens inside the engine's systems in the background. Those systems are essentially classes that process a bunch of related components at once in a big `foreach` loop (more on that later!). Even though we don't see or access those systems directly in our C# code, you can think of Unity as having hidden classes like PhysicsSystem, RenderingSystem and AudioSystem to respectively handle the logic of the components above. 

These systems do all the heavy lifting: physics calculations, collision detection, light projection, shading, mixing, etc. Then, they modify the data on the components if they need to (for example, the physics system changes the rigidbody's position based on the gravity). 

Finally, these systems send back events (or "callbacks") like `OnCollisionEnter()`. This pattern is called *inversion of control*: the system manages the control flow, and only notifies the component when something relevant happens. The component is thus no longer responsible for checking its own events conditions, which greatly reduces its complexity.

---

# OOP in Unity: where it gets messy

As we saw, built-in Unity components like Light and Collider are *mostly* similar to ECS with light touches of OOP added for convenience and ease of use.

These built-in components use inheritance, but minimally. For example, Light is the base class for PointLight and DirectionalLight, and Collider is the base class for BoxCollider and SphereCollider.

But Unity also lets us define our own components in C# by extending `MonoBehaviour`. And that's when things tend to get out of hands.

Because C# is a language is designed with an OOP philosophy (classes, interfaces, polymorphism, etc.) and because OOP is so popular in computer science, developers coming from various backgrounds instinctively try to structure their whole Unity project with elaborate hierarchies of inherited classes. 

They end up with classes that can be dozens of layers deep, like:

```
class Player : ControllableCharacter : Character : Actor : (etc.) : MonoBehaviour
```

Some community help resources like the Unity Forums, Unity Answers, Reddit and StackOverflow are even encouraging others devs to structure their code in that way, because they feel like it helps organize the components and keep the code "clean". 

They're partly right, but also very wrong. 

As we saw above, yes, inheritance can help you share and reuse code. For example, thanks to inheritance, a Player class and a NPC class could share some methods and variables because they both inherit a Character base class.

But, like we also saw earlier, it's very hard to maintain a hierarchy that keeps making sense as your projet grows. This is why you might have heard that OOP is not **scalable**. The bigger your project, the higher the chance that you'll run into incompatibilities in your hierarchy. You'll want one class to inherit from multiple classes, which is forbidden in C#: that's called [the diamond problem](https://en.wikipedia.org/wiki/Multiple_inheritance#The_diamond_problem). 

When this happens, the general solution is to favor **composition over inheritance**. And how do you *comp*ose behaviour? With *comp*onents. So we're back to ECS!

To recap, Unity currently uses a hybrid approach that is mostly ECS, with bits of OOP. In the future, their plan is to get rid of the OOP part entirely and go "pure" ECS...

# "Pure" ECS in Unity: the DOTS Future

If Unity has always been designed using a mentality that is similar **to ECS, then why did it only become such a buzzword recently?

You probably also heard about something called the **Data-Oriented Tech Stack (DOTS)**. DOTS is Unity's attempt at rewriting almost the entire engine to reap the performance benefits of modern multi-threading. In order to do that, everything has to be re-implemented using "**pure" ECS**: components must no longer contain *any* logic, *only* data. 

So when you hear the acronym "ECS" in relation with Unity nowadays, it usually refers to that DOTS-compatible, "pure" version of ECS. You might even have heard these two acronyms being used interchangeably! If we're being pedantic, DOTS and ECS are *technically* separate things, but they're really two sides of the same coin. To quote Wikipedia:

*Data-oriented design is a program optimization approach [...] used in video game development. [...] Common ECS approaches are highly compatible and often combined with data-oriented design techniques.*

Indeed, the appeal of DOTS and pure ECS is essentially performance. The speed and memory benefits of DOTS are outstanding, allowing you to manage tens of thousands of entities in your scene at butter smooth frame rates. This is what the fancy new Unity demos like [Megacity](https://unity.com/megacity) are all about.

The downside of pure ECS however is that it's (arguably) much harder to code with it. It's often criticized for being overly boilerplate and complicated to setup, and while Unity is continuously making improvements to their ECS API, the core issue remains that ECS requires a very different, data-oriented thinking that limits the programmer's options when designing game logic.

Again, components can no longer contain methods or events, *only* data. For example, this means you have to say goodbye to helpers like `AddForce()` and event callbacks like `OnCollisionEnter()`. Instead, you'd have to code a separate system that loops over entities with rigidbody components, sets a force flag, forwards it to the core physics handling system to be applied, and receives events... *somehow* (at the moment, event handling is not very clear in the current design for ECS). This overhead can quickly turn a simple operation that took a few lines of code into hundreds of lines spread over multiple files. 

---

At this point, as a developer, you should ask yourself whether the added complexity is worth the performance benefit. Personally, I don't care much about the performance benefits of DOTS — my games don't have tens of thousands of entities, and they run perfectly fine on all my target devices. What I *do* care about is how easily I can develop more features and how manageable and clean my code stays along the way. If you're in a similar situation, then GoCS is probably for you.
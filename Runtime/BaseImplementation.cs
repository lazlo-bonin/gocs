using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Lazlo.Gocs
{
	/// <summary>
	/// Provides helpers to implement lifecycle events on <see cref="IComponent"/>s and <see cref="ISystem"/>s.
	/// <para> Use this class when creating custom base classes from interfaces to ensure future-proofing.</para> 
	/// </summary>
	public static class BaseImplementation
	{
		#region Component

		/// <summary>
		/// Call this during the component's Awake callback.
		/// </summary>
		/// <param name="component">The component.</param>
		public static void ComponentAwake(in IComponent component)
		{
			if (component is Component concreteComponent)
			{
				RuntimeRequiredComponentUtility.AddRuntimeRequiredComponents(concreteComponent);
			}

			World.AddComponent(component);
		}
		
		/// <summary>
		/// Call this during the component's OnEnable callback.
		/// </summary>
		/// <param name="component">The component.</param>
		public static void ComponentOnEnable(in IComponent component)
		{
			// Currently unused but reserved.
		}
		
		/// <summary>
		/// Call this during the component's OnDisable callback.
		/// </summary>
		/// <param name="component">The component.</param>
		public static void ComponentOnDisable(in IComponent component)
		{
			// Currently unused but reserved.
		}
		
		/// <summary>
		/// Call this during the component's OnDestroy callback.
		/// </summary>
		/// <param name="component">The component.</param>
		public static void ComponentOnDestroy(in IComponent component)
		{
			World.RemoveComponent(component);
		}

		#endregion



		#region System
		
		/// <summary>
		/// Call this during the system's Awake callback.
		/// </summary>
		/// <param name="system">The system.</param>
		public static void SystemAwake(in ISystem system)
		{
			if (system is Component concreteComponent)
			{
				RuntimeRequiredComponentUtility.AddRuntimeRequiredComponents(concreteComponent);
			}

			World.AddSystem(system);
		}
		
		/// <summary>
		/// Call this during the system's OnEnable callback.
		/// </summary>
		/// <param name="system">The system.</param>
		public static void SystemOnEnable(in ISystem system)
		{
			// Currently unused but reserved.
		}
		
		/// <summary>
		/// Call this during the system's OnDisable callback.
		/// </summary>
		/// <param name="system">The system.</param>
		public static void SystemOnDisable(in ISystem system)
		{
			// Currently unused but reserved.
		}
		
		/// <summary>
		/// Call this during the system's OnDestroy callback.
		/// </summary>
		/// <param name="system">The system.</param>
		public static void SystemOnDestroy(in ISystem system)
		{
			World.RemoveSystem(system);
		}

		#endregion
	}
}
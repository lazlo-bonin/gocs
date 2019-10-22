using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Lazlo.Gocs
{
	/// <summary>
	/// Provides helpers to implement lifecycle events on components and systems.
	/// Use this class when creating custom base classes from interfaces to ensure future-proofing.
	/// </summary>
	/// <seealso cref="IComponent"/>
	/// <seealso cref="ISystem"/>
	public static class BaseImplementation
	{
		#region Component

		public static void ComponentAwake(IComponent component)
		{
			if (component is Component concreteComponent)
			{
				RuntimeRequiredComponentUtility.AddRuntimeRequiredComponents(concreteComponent);
			}

			World.AddComponent(component);
		}

		public static void ComponentOnEnable(IComponent component)
		{
			// Currently unused but reserved.
		}

		public static void ComponentOnDisable(IComponent component)
		{
			// Currently unused but reserved.
		}

		public static void ComponentOnDestroy(IComponent component)
		{
			World.RemoveComponent(component);
		}

		#endregion



		#region System

		public static void SystemAwake(ISystem system)
		{
			if (system is Component concreteComponent)
			{
				RuntimeRequiredComponentUtility.AddRuntimeRequiredComponents(concreteComponent);
			}

			World.AddSystem(system);
		}

		public static void SystemOnEnable(ISystem system)
		{
			// Currently unused but reserved.
		}

		public static void SystemOnDisable(ISystem system)
		{
			// Currently unused but reserved.
		}

		public static void SystemOnDestroy(ISystem system)
		{
			World.RemoveSystem(system);
		}

		#endregion
	}
}
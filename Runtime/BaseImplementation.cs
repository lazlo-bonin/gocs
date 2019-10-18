using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Lazlo.Gocs
{
	public static class BaseImplementation
	{
		#region Component

		public static void ComponentAwake(IComponent component)
		{
			if (component is Component concreteComponent)
			{
				RuntimeRequiredComponentUtility.AddRuntimeRequiredComponents(concreteComponent);
			}
		}

		public static void ComponentOnEnable(IComponent component)
		{
			World.AddComponent(component);
		}

		public static void ComponentOnDisable(IComponent component)
		{
			World.RemoveComponent(component);
		}

		public static void ComponentOnDestroy(IComponent component)
		{
			// Currently unused but reserved.
		}

		#endregion



		#region System

		public static void SystemAwake(ISystem system)
		{
			if (system is Component concreteComponent)
			{
				RuntimeRequiredComponentUtility.AddRuntimeRequiredComponents(concreteComponent);
			}
		}

		public static void SystemOnEnable(ISystem system)
		{
			World.AddSystem(system);
		}

		public static void SystemOnDisable(ISystem system)
		{
			World.RemoveSystem(system);
		}

		public static void SystemOnDestroy(ISystem system)
		{
			// Currently unused but reserved.
		}

		#endregion
	}
}
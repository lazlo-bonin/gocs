using UnityEngine;

namespace Lazlo.Gocs.Examples.Zones
{
	[RuntimeRequireComponent(typeof(TriggerProxy))]
	public interface IZone : IComponent
	{
		// Attributes
		string requiredTag { get; }

		// Events
		Event<GameObject> onEnter { get; }
		Event<GameObject> onExit { get; }
	}
}
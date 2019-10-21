using UnityEngine;

namespace Lazlo.Gocs.Examples.Zones
{
	public sealed class ZoneSystem : BaseSystem, ISystemWatch<IZone, ITriggerEventProxy>
	{
		private readonly SystemEvents<Collider> enterEvents = new SystemEvents<Collider>();

		private readonly SystemEvents<Collider> exitEvents = new SystemEvents<Collider>();

		public override void AddComponent(IZone zone, ITriggerEventProxy trigger)
		{
			enterEvents[trigger.onTriggerEnter] = other => OnZoneTriggerEnter(zone, other);
			enterEvents[trigger.onTriggerExit] = other => OnZoneTriggerExit(zone, other);
		}

		public override void RemoveComponent(IZone zone, ITriggerEventProxy trigger)
		{
			enterEvents[trigger.onTriggerEnter] = null;
			enterEvents[trigger.onTriggerExit] = null;
		}

		private void OnZoneTriggerEnter(IZone zone, Collider other)
		{
			if (other.CompareTag(zone.requiredTag))
			{
				zone.onEnter?.Invoke(other.gameObject);
			}
		}

		private void OnZoneTriggerExit(IZone zone, Collider other)
		{
			if (other.CompareTag(zone.requiredTag))
			{
				zone.onExit?.Invoke(other.gameObject);
			}
		}
	}
}
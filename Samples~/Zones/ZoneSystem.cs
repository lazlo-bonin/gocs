using UnityEngine;

namespace Lazlo.Gocs.Examples.Zones
{
	public sealed class ZoneSystem : BaseSystem
	{
		private readonly SystemEvents<Collider> enterEvents = new SystemEvents<Collider>();

		private readonly SystemEvents<Collider> exitEvents = new SystemEvents<Collider>();

		public override void AddComponent(IComponent component)
		{
			if (component is IZone zone)
			{
				var trigger = zone.gameObject.GetOrAddComponent<TriggerEventProxy>();

				enterEvents[trigger.onTriggerEnter] = other => OnZoneTriggerEnter(zone, other);
				enterEvents[trigger.onTriggerExit] = other => OnZoneTriggerExit(zone, other);
			}
		}

		public override void RemoveComponent(IComponent component)
		{
			if (component.gameObject.Has(out IZone zone, out ITriggerEventProxy trigger))
			{
				enterEvents[trigger.onTriggerEnter] = null;
				enterEvents[trigger.onTriggerExit] = null;
			}
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
using UnityEngine;

namespace Lazlo.Gocs.Examples.Zones
{
	public sealed class ZoneSystem : BaseSystem
	{
		private readonly SystemComponents<IZone, ITriggerEventProxy> components = new SystemComponents<IZone, ITriggerEventProxy>();

		private readonly SystemEvents<Collider> enterEvents = new SystemEvents<Collider>();

		private readonly SystemEvents<Collider> exitEvents = new SystemEvents<Collider>();

		public override void OnAddComponent(IComponent component)
		{
			if (components.Add(component, out var zone, out var trigger))
			{
				enterEvents[trigger.onTriggerEnter] = other => OnZoneTriggerEnter(zone, other);
				exitEvents[trigger.onTriggerExit] = other => OnZoneTriggerExit(zone, other);
			}
		}

		public override void OnRemoveComponent(IComponent component)
		{
			if (components.Remove(component, out var zone, out var trigger))
			{
				enterEvents[trigger.onTriggerEnter] = null;
				exitEvents[trigger.onTriggerExit] = null;
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
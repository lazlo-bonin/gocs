using UnityEngine;

namespace Lazlo.Gocs.Examples.Zones
{
	public sealed class ZoneSystem : BaseSystem
	{
		private readonly SystemComponents<IZone, TriggerProxy> components = new SystemComponents<IZone, TriggerProxy>();

		private readonly SystemEvents<Collider> enterEvents = new SystemEvents<Collider>();

		private readonly SystemEvents<Collider> exitEvents = new SystemEvents<Collider>();

		public override void OnAddComponent(IComponent component)
		{
			if (components.Add(component, out var zone, out var trigger))
			{
				enterEvents[trigger.onEnter] = other => OnZoneTriggerEnter(zone, other);
				exitEvents[trigger.onExit] = other => OnZoneTriggerExit(zone, other);
			}
		}

		public override void OnRemoveComponent(IComponent component)
		{
			if (components.Remove(component, out var zone, out var trigger))
			{
				enterEvents[trigger.onEnter] = null;
				exitEvents[trigger.onExit] = null;
			}
		}

		private void OnZoneTriggerEnter(IZone zone, Collider other)
		{
			if (string.IsNullOrEmpty(zone.requiredTag) || other.CompareTag(zone.requiredTag))
			{
				zone.onEnter?.Invoke(other.gameObject);
			}
		}

		private void OnZoneTriggerExit(IZone zone, Collider other)
		{
			if (string.IsNullOrEmpty(zone.requiredTag) || other.CompareTag(zone.requiredTag))
			{
				zone.onExit?.Invoke(other.gameObject);
			}
		}
	}
}
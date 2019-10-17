using UnityEngine;

namespace Lazlo.Recs.Examples.Zones
{
	public sealed class ZoneSystem : BaseSystem
	{
		private readonly SystemEvents<Collider> triggerEnterHandlers = new SystemEvents<Collider>();

		private readonly SystemEvents<Collider> triggerExitHandlers = new SystemEvents<Collider>();

		public override void AddComponent(IComponent component)
		{
			if (component is IZone zone)
			{
				var trigger = zone.entity.GetOrAddComponent<TriggerEventProxy>();

				trigger.onTriggerEnter?.AddHandler(triggerEnterHandlers, other => OnZoneTriggerEnter(zone, other));
				trigger.onTriggerExit?.AddHandler(triggerExitHandlers, other => OnZoneTriggerExit(zone, other));
			}
		}

		public override void RemoveComponent(IComponent component)
		{
			if (component.entity.Has(out IZone zone, out ITriggerEventProxy trigger))
			{
				trigger.onTriggerEnter?.RemoveHandler(triggerEnterHandlers);
				trigger.onTriggerExit?.RemoveHandler(triggerExitHandlers);
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
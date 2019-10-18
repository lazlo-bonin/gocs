using UnityEngine;

namespace Lazlo.Gocs
{
	public sealed class TriggerEventProxy : BaseComponent, ITriggerEventProxy
	{
		public Event<Collider> onTriggerEnter { get; } = new Event<Collider>();
		public Event<Collider> onTriggerStay { get; } = new Event<Collider>();
		public Event<Collider> onTriggerExit { get; } = new Event<Collider>();

		private void OnTriggerEnter(Collider other)
		{
			onTriggerEnter.Invoke(other);
		}

		private void OnTriggerStay(Collider other)
		{
			onTriggerStay.Invoke(other);
		}

		private void OnTriggerExit(Collider other)
		{
			onTriggerEnter.Invoke(other);
		}
	}
}
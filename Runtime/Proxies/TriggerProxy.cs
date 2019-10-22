using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class TriggerProxy : BaseComponent
	{
		public Event<Collider> onEnter { get; } = new Event<Collider>();

		public Event<Collider> onStay { get; } = new Event<Collider>();

		public Event<Collider> onExit { get; } = new Event<Collider>();

		private void OnTriggerEnter(Collider other)
		{
			onEnter.Invoke(other);
		}

		private void OnTriggerStay(Collider other)
		{
			onStay.Invoke(other);
		}

		private void OnTriggerExit(Collider other)
		{
			onExit.Invoke(other);
		}
	}
}
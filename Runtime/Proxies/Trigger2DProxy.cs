using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class Trigger2DProxy : BaseComponent
	{
		public Event<Collider2D> onEnter { get; } = new Event<Collider2D>();

		public Event<Collider2D> onStay { get; } = new Event<Collider2D>();

		public Event<Collider2D> onExit { get; } = new Event<Collider2D>();

		private void OnTriggerEnter2D(Collider2D other)
		{
			onEnter.Invoke(other);
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			onStay.Invoke(other);
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			onExit.Invoke(other);
		}
	}
}
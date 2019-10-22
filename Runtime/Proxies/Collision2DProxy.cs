using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class Collision2DProxy : BaseComponent
	{
		public Event<Collision2D> onEnter { get; } = new Event<Collision2D>();

		public Event<Collision2D> onStay { get; } = new Event<Collision2D>();

		public Event<Collision2D> onExit { get; } = new Event<Collision2D>();

		private void OnCollisionEnter2D(Collision2D collision)
		{
			onEnter.Invoke(collision);
		}

		private void OnCollisionStay2D(Collision2D collision)
		{
			onStay.Invoke(collision);
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
			onExit.Invoke(collision);
		}
	}
}
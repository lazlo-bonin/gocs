using UnityEngine;

namespace Ludiq.Recs
{
	public sealed class CollisionEventProxy : BaseComponent, ICollisionEventProxy
	{
		public Event<Collision> onCollisionEnter { get; } = new Event<Collision>();
		public Event<Collision> onCollisionStay { get; } = new Event<Collision>();
		public Event<Collision> onCollisionExit { get; } = new Event<Collision>();

		private void OnCollisionEnter(Collision collision)
		{
			onCollisionEnter.Invoke(collision);
		}

		private void OnCollisionStay(Collision collision)
		{
			onCollisionStay.Invoke(collision);
		}

		private void OnCollisionExit(Collision collision)
		{
			onCollisionExit.Invoke(collision);
		}
	}
}
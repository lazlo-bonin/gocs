using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class CollisionProxy : BaseComponent
	{
		public Event<Collision> onEnter { get; } = new Event<Collision>();

		public Event<Collision> onStay { get; } = new Event<Collision>();

		public Event<Collision> onExit { get; } = new Event<Collision>();

		private void OnCollisionEnter(Collision collision)
		{
			onEnter.Invoke(collision);
		}

		private void OnCollisionStay(Collision collision)
		{
			onStay.Invoke(collision);
		}

		private void OnCollisionExit(Collision collision)
		{
			onExit.Invoke(collision);
		}
	}
}
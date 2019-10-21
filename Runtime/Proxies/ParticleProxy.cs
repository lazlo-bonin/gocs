using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class ParticleProxy : BaseComponent
	{
		public Event<GameObject> onCollision { get; } = new Event<GameObject>();

		public Event onTrigger { get; } = new Event();

		private void OnParticleCollision(GameObject other)
		{
			onCollision.Invoke(other);
		}

		private void OnParticleTrigger()
		{
			onTrigger.Invoke();
		}
	}
}
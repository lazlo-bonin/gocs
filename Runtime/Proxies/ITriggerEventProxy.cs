using UnityEngine;

namespace Lazlo.Recs
{
	public interface ITriggerEventProxy : IComponent
	{
		Event<Collider> onTriggerEnter { get; }
		Event<Collider> onTriggerStay { get; }
		Event<Collider> onTriggerExit { get; }
	}
}

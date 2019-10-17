using UnityEngine;

namespace Ludiq.Recs
{
	public interface ICollisionEventProxy : IComponent
	{
		Event<Collision> onCollisionEnter { get; }
		Event<Collision> onCollisionStay { get; }
		Event<Collision> onCollisionExit { get; }
	}
}

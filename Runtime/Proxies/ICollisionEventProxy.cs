using UnityEngine;

namespace Lazlo.Gocs
{
	public interface ICollisionEventProxy : IComponent
	{
		Event<Collision> onCollisionEnter { get; }
		Event<Collision> onCollisionStay { get; }
		Event<Collision> onCollisionExit { get; }
	}
}

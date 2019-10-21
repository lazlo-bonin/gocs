using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class ControllerColliderProxy : BaseComponent
	{
		public Event<ControllerColliderHit> onHit { get; } = new Event<ControllerColliderHit>();

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			onHit.Invoke(hit);
		}
	}
}

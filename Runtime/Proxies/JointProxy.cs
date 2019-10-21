using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class JointProxy : BaseComponent
	{
		public Event<float> onBreak { get; } = new Event<float>();

		private void OnJointBreak(float breakForce)
		{
			onBreak.Invoke(breakForce);
		}
	}
}
using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class AnimatorProxy : BaseComponent
	{
		public Event onMove { get; } = new Event();

		public Event<int> onIK { get; } = new Event<int>();

		private void OnAnimatorMove()
		{
			onMove.Invoke();
		}

		private void OnAnimatorIK(int layerIndex)
		{
			onIK.Invoke(layerIndex);
		}
	}
}
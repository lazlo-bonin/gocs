using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class TransformProxy : BaseComponent
	{
		public Event onChildrenChanged { get; } = new Event();

		public Event onParentChanged { get; } = new Event();

		private void OnTransformChildrenChanged()
		{
			onChildrenChanged.Invoke();
		}

		private void OnTransformParentChanged()
		{
			onChildrenChanged.Invoke();
		}
	}
}
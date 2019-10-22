using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class VisibilityProxy : BaseComponent
	{
		public Event onBecameVisible { get; } = new Event();

		public Event onBecameInvisible { get; } = new Event();

		private void OnBecameVisible()
		{
			onBecameVisible.Invoke();
		}

		private void OnBecameInvisible()
		{
			onBecameInvisible.Invoke();
		}
	}
}
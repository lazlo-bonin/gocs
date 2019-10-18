using UnityEngine;
using Event = Lazlo.Gocs.Event;

namespace Lazlo.Gocs.Examples.Interaction
{
	public sealed class DebugInteractable : BaseComponent, IInteractable
	{
		protected override void Awake()
		{
			base.Awake();

			onHoverEnter = new Event(() => Debug.Log(nameof(onHoverEnter), this));
			onHoverExit = new Event(() => Debug.Log(nameof(onHoverExit), this));
			onPress = new Event(() => Debug.Log(nameof(onPress), this));
			onRelease = new Event(() => Debug.Log(nameof(onRelease), this));
		}

		public float range => 999;

		public bool isHovered { get; set; }

		public bool isPressed { get; set; }

		public Event onHoverEnter { get; private set; }

		public Event onHoverExit { get; private set; }

		public Event onPress { get; private set; }

		public Event onRelease { get; private set; }
	}
}
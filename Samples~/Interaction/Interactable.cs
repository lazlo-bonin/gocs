using UnityEngine;
using UnityEngine.Events;

namespace Lazlo.Gocs.Examples.Interaction
{
	public sealed class Interactable : BaseComponent, IInteractable
	{
		protected override void Awake()
		{
			base.Awake();
			onHoverEnter.AddHandler(_onHoverEnter.Invoke);
			onHoverExit.AddHandler(_onHoverExit.Invoke);
			onPress.AddHandler(_onPress.Invoke);
			onRelease.AddHandler(_onRelease.Invoke);
		}
		
		public float range = 5;
		float IInteractable.range => range;
		
		public bool isHovered { get; set; }
		public bool isPressed { get; set; }

		public Event onHoverEnter { get; } = new Event();
		public Event onHoverExit { get; } = new Event();
		public Event onPress { get; } = new Event();
		public Event onRelease { get; } = new Event();

		[SerializeField] private UnityEvent _onHoverEnter = default;
		[SerializeField] private UnityEvent _onHoverExit = default;
		[SerializeField] private UnityEvent _onPress = default;
		[SerializeField] private UnityEvent _onRelease = default;
	}
} 
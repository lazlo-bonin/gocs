namespace Lazlo.Gocs.Examples.Interaction
{
	public abstract class BaseInteractable : BaseComponent, IInteractable
	{
		protected override void Awake()
		{
			base.Awake();
			onHoverEnter = new Event(OnHoverEnter);
			onHoverExit = new Event(OnHoverExit);
			onPress = new Event(OnPress);
			onRelease = new Event(OnRelease);
		}

		public float range = 5;

		float IInteractable.range => range;

		public bool isHovered { get; set; }

		public bool isPressed { get; set; }

		public Event onHoverEnter { get; private set; }

		public Event onHoverExit { get; private set; }

		public Event onPress { get; private set; }

		public Event onRelease { get; private set; }

		protected virtual void OnHoverEnter() { }

		protected virtual void OnHoverExit() { }

		protected virtual void OnPress() { }

		protected virtual void OnRelease() { }
	}
}
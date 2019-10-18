namespace Lazlo.Gocs.Examples.Interaction
{
	public interface IInteractable : IComponent
	{
		// Attributes
		float range { get; }

		// Data
		bool isHovered { get; set; }
		bool isPressed { get; set; }

		// Events
		Event onHoverEnter { get; }
		Event onHoverExit { get; }
		Event onPress { get; }
		Event onRelease { get; }
	}
}
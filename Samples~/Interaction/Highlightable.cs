using UnityEngine;

namespace Lazlo.Gocs.Examples.Interaction
{
	[RequireComponent(typeof(Renderer))]
	public class Highlightable : BaseComponent, IInteractable
	{
		protected override void Awake()
		{
			base.Awake();
			renderer = GetComponent<Renderer>();
			onHoverEnter = new Event(StartHighlighting);
			onHoverExit = new Event(StopHighlighting);
		}
		
		public float range = 5;
		float IInteractable.range => range;

		public Color color = Color.yellow;
		private Color normalColor;
		
		private new Renderer renderer;
		
		public bool isHovered { get; set; }
		public bool isPressed { get; set; }

		public Event onHoverEnter { get; private set; }
		public Event onHoverExit { get; private set; }
		public Event onPress { get; private set; }
		public Event onRelease { get; private set; }
		
		private void StartHighlighting()
		{
			normalColor = renderer.material.color;
			renderer.material.color = color;
		}
		
		private void StopHighlighting()
		{
			renderer.material.color = normalColor;
		}
	}
}
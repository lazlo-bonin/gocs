using UnityEngine;

namespace Lazlo.Gocs.Examples.Interaction
{
	[RequireComponent(typeof(Renderer))]
	public class Highlightable : BaseInteractable
	{
		protected override void Awake()
		{
			base.Awake();
			renderer = GetComponent<Renderer>();
		}

		public Color color = Color.yellow;

		private Color normalColor;

		private new Renderer renderer;

		protected override void OnHoverEnter()
		{
			normalColor = renderer.material.color;
			renderer.material.color = color;
		}

		protected override void OnHoverExit()
		{
			renderer.material.color = normalColor;
		}
	}
}
using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class MouseProxy : BaseComponent
	{
		public Event onDown { get; } = new Event();

		public Event onDrag { get; } = new Event();

		public Event onEnter { get; } = new Event();

		public Event onExit { get; } = new Event();

		public Event onOver { get; } = new Event();

		public Event onUp { get; } = new Event();

		public Event onUpAsButton { get; } = new Event();

		private void OnMouseDown()
		{
			onDown.Invoke();
		}

		private void OnMouseDrag()
		{
			onDrag.Invoke();
		}

		private void OnMouseEnter()
		{
			onEnter.Invoke();
		}

		private void OnMouseExit()
		{
			onExit.Invoke();
		}

		private void OnMouseOver()
		{
			onOver.Invoke();
		}

		private void OnMouseUp()
		{
			onUp.Invoke();
		}

		private void OnMouseUpAsButton()
		{
			onUpAsButton.Invoke();
		}
	}
}
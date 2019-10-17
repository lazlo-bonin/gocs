using UnityEngine;

namespace Lazlo.Recs.Examples.Interaction
{
	public class Grabbable : BaseComponent, IInteractable
	{
		protected override void Awake()
		{
			base.Awake();
			onPress = new Event(Grab);
			onRelease = new Event(Release);
		}

		[SerializeField] private float _range = 5;

		public float range => _range;

		public bool isHovered { get; set; }
		public bool isPressed { get; set; }

		public Event onHoverEnter { get; private set; } 
		public Event onHoverExit { get; private set; }
		public Event onPress { get; private set; }
		public Event onRelease { get; private set; }

		private void Grab()
		{
			transform.parent = Camera.main.transform;
		}
		
		private void Release()
		{
			transform.parent = null;
		}
	}
}
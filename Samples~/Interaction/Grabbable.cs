using UnityEngine;

namespace Lazlo.Gocs.Examples.Interaction
{
	public class Grabbable : BaseInteractable
	{
		protected override void OnPress()
		{
			transform.parent = Camera.main.transform;
		}

		protected override void OnRelease()
		{
			transform.parent = null;
		}
	}
}
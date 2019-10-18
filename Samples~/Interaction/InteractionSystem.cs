using UnityEngine;

namespace Lazlo.Gocs.Examples.Interaction
{
	public sealed class InteractionSystem : BaseSystem
	{
		public float rayRadius = 0.1f;

		public LayerMask layerMask;

		private IInteractable hovered;

		private IInteractable pressed;

		private void Update()
		{
			if (pressed != null && Input.GetMouseButtonUp(0))
			{
				pressed.onRelease?.Invoke();
				pressed.isPressed = false;
				pressed = null;
			}

			if (pressed == null)
			{
				var camera = Camera.main;
				var ray = new Ray(camera.transform.position, camera.transform.forward);

				IInteractable interactable = null;

				if (Physics.SphereCast(ray, rayRadius, out var hit, Mathf.Infinity, layerMask))
				{
					interactable = hit.collider.gameObject?.GetComponentInParent<IInteractable>();

					if (interactable != null && hit.distance > interactable.range)
					{
						interactable = null;
					}
				}

				if (interactable != hovered)
				{
					if (hovered != null)
					{
						hovered.onHoverExit?.Invoke();
						hovered.isHovered = false;
					}

					hovered = interactable;

					if (hovered != null)
					{
						hovered.onHoverEnter?.Invoke();
						hovered.isHovered = true;
					}
				}

				if (hovered != null && Input.GetMouseButtonDown(0))
				{
					pressed = hovered;
					pressed.onPress?.Invoke();
					pressed.isPressed = true;
				}
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.magenta;

			foreach (var interactable in World.EditorQuery<IInteractable>())
			{
				Gizmos.DrawWireSphere(interactable.transform.position, interactable.range);
			}
		}
	}
}
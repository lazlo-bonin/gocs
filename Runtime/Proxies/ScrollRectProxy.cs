using UnityEngine;
using UnityEngine.UI;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class ScrollRectProxy : BaseComponent
	{
		public Event<Vector2> onValueChanged { get; } = new Event<Vector2>();

		private void Start()
		{
			GetComponent<ScrollRect>()?.onValueChanged?.AddListener(OnValueChanged);
		}

		private void OnValueChanged(Vector2 value)
		{
			onValueChanged.Invoke(value);
		}
	}
}
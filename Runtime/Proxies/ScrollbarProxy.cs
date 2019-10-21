using UnityEngine;
using UnityEngine.UI;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class ScrollbarProxy : BaseComponent
	{
		public Event<float> onValueChanged { get; } = new Event<float>();

		private void Start()
		{
			GetComponent<Scrollbar>()?.onValueChanged?.AddListener(OnValueChanged);
		}

		private void OnValueChanged(float value)
		{
			onValueChanged.Invoke(value);
		}
	}
}
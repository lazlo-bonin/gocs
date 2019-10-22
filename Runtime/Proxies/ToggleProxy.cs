using UnityEngine;
using UnityEngine.UI;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class ToggleProxy : BaseComponent
	{
		public Event<bool> onValueChanged { get; } = new Event<bool>();

		private void Start()
		{
			GetComponent<Toggle>()?.onValueChanged?.AddListener(OnValueChanged);
		}

		private void OnValueChanged(bool value)
		{
			onValueChanged.Invoke(value);
		}
	}
}
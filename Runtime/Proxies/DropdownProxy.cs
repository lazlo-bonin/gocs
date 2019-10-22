using UnityEngine;
using UnityEngine.UI;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class DropdownProxy : BaseComponent
	{
		public Event<int> onValueChanged { get; } = new Event<int>();

		private void Start()
		{
			GetComponent<Dropdown>()?.onValueChanged?.AddListener(OnValueChanged);
		}

		private void OnValueChanged(int value)
		{
			onValueChanged.Invoke(value);
		}
	}
}
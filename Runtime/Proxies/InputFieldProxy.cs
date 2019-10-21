using UnityEngine;
using UnityEngine.UI;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class InputFieldProxy : BaseComponent
	{
		public Event<string> onValueChanged { get; } = new Event<string>();

		public Event<string> onEndEdit { get; } = new Event<string>();

		private void Start()
		{
			GetComponent<InputField>()?.onValueChanged?.AddListener(OnValueChanged);
			GetComponent<InputField>()?.onEndEdit?.AddListener(OnEndEdit);
		}

		private void OnValueChanged(string value)
		{
			onValueChanged.Invoke(value);
		}

		private void OnEndEdit(string value)
		{
			onEndEdit.Invoke(value);
		}
	}
}
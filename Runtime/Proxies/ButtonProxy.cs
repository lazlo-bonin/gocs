using UnityEngine;
using UnityEngine.UI;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class ButtonProxy : BaseComponent
	{
		public Event onClick { get; } = new Event();

		private void Start()
		{
			GetComponent<Button>()?.onClick?.AddListener(OnClick);
		}

		private void OnClick()
		{
			onClick.Invoke();
		}
	}
}
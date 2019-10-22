using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class ApplicationProxy : BaseComponent
	{
		public Event<bool> onFocusChanged { get; } = new Event<bool>();

		public Event onGainedFocus { get; } = new Event();

		public Event onLostFocus { get; } = new Event();

		public Event<bool> onPauseChanged { get; } = new Event<bool>();

		public Event onResumed { get; } = new Event();

		public Event onPaused { get; } = new Event();

		public Event onQuit { get; } = new Event();

		private void OnApplicationFocus(bool focus)
		{
			onFocusChanged.Invoke(focus);

			if (focus)
			{
				onGainedFocus.Invoke();
			}
			else
			{
				onLostFocus.Invoke();
			}
		}

		private void OnApplicationPause(bool pause)
		{
			onPauseChanged.Invoke(pause);

			if (pause)
			{
				onPaused.Invoke();
			}
			else
			{
				onResumed.Invoke();
			}
		}

		private void OnApplicationQuit()
		{
			onQuit.Invoke();
		}
	}
}
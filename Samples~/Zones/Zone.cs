using Lazlo.Gocs.Examples.Zones;
using UnityEngine;
using UnityEngine.Events;

namespace Lazlo.Gocs.Examples.Interaction
{
	public sealed class Zone : BaseComponent, IZone
	{
		protected override void Awake()
		{
			base.Awake();

			onEnter.AddHandler(_onEnter.Invoke);
			onExit.AddHandler(_onExit.Invoke);
		}

		[SerializeField] private string _requiredTag;
		[SerializeField] private UnityEvent<GameObject> _onEnter = default;
		[SerializeField] private UnityEvent<GameObject> _onExit = default;

		public string requiredTag => requiredTag;
		public Event<GameObject> onEnter { get; } = new Event<GameObject>();
		public Event<GameObject> onExit { get; } = new Event<GameObject>();
	}
}
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

			onEnter.AddHandler(go => _onEnter.Invoke());
			onExit.AddHandler(go => _onExit.Invoke());
		}

		[SerializeField] private string _requiredTag = default;
		[SerializeField] private UnityEvent _onEnter = default;
		[SerializeField] private UnityEvent _onExit = default;

		public string requiredTag => _requiredTag;
		public Event<GameObject> onEnter { get; } = new Event<GameObject>();
		public Event<GameObject> onExit { get; } = new Event<GameObject>();
	}
}
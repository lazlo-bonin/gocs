using Lazlo.Gocs.Examples.Zones;
using UnityEngine;

namespace Lazlo.Gocs.Examples.Interaction
{
	public sealed class DebugZone : BaseComponent, IZone
	{
		[SerializeField]
		private string _requiredTag = default;

		public string requiredTag => _requiredTag;

		public Event<GameObject> onEnter { get; } = new Event<GameObject>();

		public Event<GameObject> onExit { get; } = new Event<GameObject>();

		protected override void Awake()
		{
			base.Awake();

			onEnter.AddHandler(OnEnter);
			onExit.AddHandler(OnExit);
		}

		private void OnEnter(GameObject go)
		{
			Debug.Log($"{go.name} entered {name}", go);
		}

		private void OnExit(GameObject go)
		{
			Debug.Log($"{go.name} exited {name}", go);
		}
	}
}
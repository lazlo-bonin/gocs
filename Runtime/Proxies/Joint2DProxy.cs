using UnityEngine;

namespace Lazlo.Gocs
{
	[AddComponentMenu("")]
	public sealed class Joint2DProxy : BaseComponent
	{
		public Event<Joint2D> onBreak { get; } = new Event<Joint2D>();

		private void OnJointBreak2D(Joint2D joint)
		{
			onBreak.Invoke(joint);
		}
	}
}
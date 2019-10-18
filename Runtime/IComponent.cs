using UnityEngine;

namespace Lazlo.Gocs
{
	public interface IComponent
	{
		GameObject gameObject { get; }

		Transform transform { get; }
	}
}
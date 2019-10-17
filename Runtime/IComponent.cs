using UnityEngine;

namespace Lazlo.Recs
{
	public interface IComponent
	{
		GameObject entity { get; }

		Transform transform { get; }
	}
}
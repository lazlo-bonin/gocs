using UnityEngine;

namespace Ludiq.Recs
{
	public interface IComponent
	{
		GameObject entity { get; }

		Transform transform { get; }
	}
}
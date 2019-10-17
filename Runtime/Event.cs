using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lazlo.Recs
{
	public sealed class Event
	{
		private readonly HashSet<Action> handlers;

		public Event()
		{
			handlers = new HashSet<Action>();
		}

		public Event(Action handler) : this()
		{
			AddHandler(handler);
		}

		public void AddHandler(Action handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException(nameof(handler));
			}

			handlers.Add(handler);
		}

		public void RemoveHandler(Action handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException(nameof(handler));
			}

			handlers.Remove(handler);
		}

		public void Invoke()
		{
			foreach (var handler in handlers)
			{
				try
				{
					handler.Invoke();
				}
				catch (Exception ex)
				{
					// Keep going
					Debug.LogException(ex);
				}
			}
		}
	}
}

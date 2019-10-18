using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lazlo.Gocs
{
	public sealed class Event<TArgs>
	{
		private readonly HashSet<Action<TArgs>> handlers;

		public Event()
		{
			handlers = new HashSet<Action<TArgs>>();
		}

		public Event(Action<TArgs> handler) : this()
		{
			AddHandler(handler);
		}

		public void AddHandler(Action<TArgs> handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException(nameof(handler));
			}

			handlers.Add(handler);
		}

		public void RemoveHandler(Action<TArgs> handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException(nameof(handler));
			}

			handlers.Remove(handler);
		}
		
		public void Invoke(TArgs args)
		{
			foreach (var handler in handlers)
			{
				try
				{
					handler.Invoke(args);
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
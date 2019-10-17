using System;
using System.Collections.Generic;

namespace Lazlo.Recs
{
	public sealed class SystemEvents<TArgs>
	{
		private readonly Dictionary<Event<TArgs>, Action<TArgs>> handlers = new Dictionary<Event<TArgs>, Action<TArgs>>();

		public void AddHandler(Event<TArgs> @event, Action<TArgs> handler)
		{
			if (@event == null)
			{
				return;
			}

			@event.AddHandler(handler);
			handlers.Add(@event, handler);
		}

		public void RemoveHandler(Event<TArgs> @event)
		{
			if (@event == null)
			{
				return;
			}

			@event.RemoveHandler(handlers[@event]);
			handlers.Remove(@event);
		}
	}
}
using System;
using System.Collections.Generic;

namespace Ludiq.Recs
{
	public sealed class SystemEvents
	{
		private readonly Dictionary<Event, Action> handlers = new Dictionary<Event, Action>();

		public void AddHandler(Event @event, Action handler)
		{
			if (@event == null)
			{
				throw new ArgumentNullException(nameof(@event));
			}

			@event.AddHandler(handler);
			handlers.Add(@event, handler);
		}

		public void RemoveHandler(Event @event)
		{
			if (@event == null)
			{
				throw new ArgumentNullException(nameof(@event));
			}

			@event.RemoveHandler(handlers[@event]);
			handlers.Remove(@event);
		}
	}
}
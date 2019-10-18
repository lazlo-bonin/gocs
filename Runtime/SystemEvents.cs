using System;
using System.Collections.Generic;

namespace Lazlo.Gocs
{
	public sealed class SystemEvents
	{
		private readonly Dictionary<Event, Action> handlers = new Dictionary<Event, Action>();

		public Action this[Event @event]
		{
			get
			{
				if (handlers.TryGetValue(@event, out var handler))
				{
					return handler;
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (@event == null)
				{
					return;
				}

				if (value != null)
				{
					if (handlers.ContainsKey(@event))
					{
						throw new InvalidOperationException("System events can only add one handler per event.");
					}

					@event.AddHandler(value);
					handlers.Add(@event, value);
				}
				else if (value == null)
				{
					if (!handlers.TryGetValue(@event, out var handler))
					{
						return;
					}
					
					@event.RemoveHandler(handler);
					handlers.Remove(@event);
				}
			}
		}
	}
}
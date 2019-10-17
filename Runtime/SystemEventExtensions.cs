using System;

namespace Lazlo.Recs
{
	// Just inverts the calling order to improve readability.
	public static class SystemEventsExtensions
	{
		public static void AddHandler(this Event @event, SystemEvents system, Action handler)
		{
			system.AddHandler(@event, handler);
		}

		public static void RemoveHandler(this Event @event, SystemEvents system)
		{
			system.RemoveHandler(@event);
		}

		public static void AddHandler<TArgs>(this Event<TArgs> @event, SystemEvents<TArgs> system, Action<TArgs> handler)
		{
			system.AddHandler(@event, handler);
		}

		public static void RemoveHandler<TArgs>(this Event<TArgs> @event, SystemEvents<TArgs> system)
		{
			system.RemoveHandler(@event);
		}
	}
}
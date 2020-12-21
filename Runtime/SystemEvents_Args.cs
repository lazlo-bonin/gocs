using System;
using System.Collections.Generic;

namespace Lazlo.Gocs
{
	/// <summary>
	/// Manages event handler registration for a system.
	/// <para>
	/// This version supports event arguments.
	/// </para>
	/// </summary>
	/// 
	/// <typeparam name="TArgs">The type of argument for the events.</typeparam>
	/// 
	/// <seealso cref="SystemEvents"/>
	public sealed class SystemEvents<TArgs>
	{
		private readonly Dictionary<Event<TArgs>, Action<TArgs>> handlers = new Dictionary<Event<TArgs>, Action<TArgs>>();
		
		/// <summary>
		/// Adds or removes a system event handler for the specified event.
		/// <para>
		/// In <see cref="IWorldCallbackReceiver.OnCreatedComponent"/>, pass a handler to add it to the event.
		/// </para>
		/// <para>
		/// In <see cref="IWorldCallbackReceiver.OnDestroyingComponent"/>, pass null to remove the handler from the event.
		/// </para>
		/// </summary>
		/// 
		/// <remarks>
		/// System events can only add one handler per event.
		/// </remarks>
		/// 
		/// <param name="event">The event on which to add or remove the handler.</param>
		/// <returns>The event handler.</returns>
		public Action<TArgs> this[in Event<TArgs> @event]
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
				else // if (value == null)
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
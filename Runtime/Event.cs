using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lazlo.Gocs
{
	/// <summary>
	/// Represents an event without arguments.
	/// <para>
	/// Events support assigning handlers and invoking from anywhere.
	/// </para> 
	/// </summary>
	/// <seealso cref="Event{TArgs}"/>
	public sealed class Event
	{
		private readonly HashSet<Action> handlers;

		/// <summary>
		/// Creates a new event without any handler.
		/// </summary>
		public Event()
		{
			handlers = new HashSet<Action>();
		}

		/// <summary>
		/// Creates a new event with a specified handler.
		/// </summary>
		/// <param name="handler">The event handler.</param>
		public Event(Action handler) : this()
		{
			AddHandler(handler);
		}

		/// <summary>
		/// Adds a handler to the event.
		/// </summary>
		/// <param name="handler">The event handler.</param>
		public void AddHandler(Action handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException(nameof(handler));
			}

			handlers.Add(handler);
		}

		/// <summary>
		/// Removes a handler from the event.
		/// </summary>
		/// <param name="handler">The event handler.</param>
		public void RemoveHandler(Action handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException(nameof(handler));
			}

			handlers.Remove(handler);
		}

		/// <summary>
		/// Invokes every handler in the event.
		/// </summary>
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

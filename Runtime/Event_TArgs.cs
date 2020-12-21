using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lazlo.Gocs
{
	/// <summary>
	/// Represents an event with arguments.
	/// <para>
	/// Events support assigning handlers and invoking from anywhere.
	/// </para> 
	/// </summary>
	/// 
	/// <remarks>
	/// Use an arguments struct or class if you need to pass multiple arguments.
	/// </remarks>
	///
	/// <typeparam name="TArgs">The type of argument.</typeparam>
	/// 
	/// <seealso cref="Event"/>
	public sealed class Event<TArgs>
	{
		private readonly HashSet<Action<TArgs>> handlers;

		/// <summary>
		/// Creates a new event without any handler.
		/// </summary>
		public Event()
		{
			handlers = new HashSet<Action<TArgs>>();
		}

		/// <summary>
		/// Creates a new event with a specified handler handler.
		/// </summary>
		/// <param name="handler">The event handler.</param>
		public Event(in Action<TArgs> handler) : this()
		{
			AddHandler(handler);
		}

		/// <summary>
		/// Adds a handler to the event.
		/// </summary>
		/// <param name="handler">The event handler.</param>
		public void AddHandler(in Action<TArgs> handler)
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
		public void RemoveHandler(in Action<TArgs> handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException(nameof(handler));
			}

			handlers.Remove(handler);
		}
		
		/// <summary>
		/// Invokes every handler on the event.
		/// </summary>
		/// <param name="args">The event arguments.</param>
		public void Invoke(in TArgs args)
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
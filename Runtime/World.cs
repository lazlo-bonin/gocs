using System;
using System.Collections.Generic;

namespace Lazlo.Gocs
{
	/// <summary>
	/// Provides root-level access to systems and components.
	/// </summary>
	public static class World
	{

		/// <summary>
		/// Whether cached registries should be used for managed <see cref="IComponent"/>s.
		/// <para>
		/// Disable to improve initialization and destruction speed of <see cref="IComponent"/>s.
		/// </para><para>
		/// However, when disabled, managed queries will no longer be available
		/// and <see cref="SystemComponents{T}"/> should be used instead.
		/// </para>
		/// </summary>
		public static bool enableRegistries { get; set; } = true;

		#region Systems & Components
		
		private static readonly List<ISystem> systems = new List<ISystem>();

		private static readonly List<IComponent> components = new List<IComponent>();

		internal static void AddSystem(ISystem system)
		{
			if (system == null)
			{
				throw new ArgumentNullException(nameof(system));
			}

			if (system is IWorldCallbackReceiver callbackReceiver)
			{
				foreach (var component in components)
				{
					callbackReceiver.OnCreatedComponent(component);
				}
			}

			systems.Add(system);
		}

		internal static void RemoveSystem(ISystem system)
		{
			if (system == null)
			{
				throw new ArgumentNullException(nameof(system));
			}

			if (system is IWorldCallbackReceiver callbackReceiver)
			{
				foreach (var component in components)
				{
					callbackReceiver.OnDestroyedComponent(component);
				}
			}

			systems.Remove(system);
		}

		internal static void AddComponent(IComponent component)
		{
			if (component == null)
			{
				throw new ArgumentNullException(nameof(component));
			}

			components.Add(component);

			if (enableRegistries)
			{
				Registries.Add(component);
			}

			foreach (var system in systems)
			{
				if (system is IWorldCallbackReceiver callbackReceiver)
				{
					callbackReceiver.OnCreatedComponent(component);
				}
			}
		}

		internal static void RemoveComponent(IComponent component)
		{
			if (component == null)
			{
				throw new ArgumentNullException(nameof(component));
			}

			foreach (var system in systems)
			{
				if (system is IWorldCallbackReceiver callbackReceiver)
				{
					callbackReceiver.OnDestroyedComponent(component);
				}
			}

			if (enableRegistries)
			{
				Registries.Remove(component);
			}

			components.Remove(component);
		}

		#endregion



		#region Queries

		/// <summary>
		/// Finds all game objects that contain the specified component.
		/// </summary>
		/// <typeparam name="T">The type of the component.</typeparam>
		/// <param name="forceNative">Whether a native query should be forced. Enable when querying in edit-mode.</param>
		/// <returns>The components per game object.</returns>
		public static QueryResult<T> Query<T>(bool forceNative = false)
		{
			using (var filter = QueryFilter.New(1))
			{
				var pass = filter.Pass<T>(forceNative);

				var result = QueryResult<T>.New();

				foreach (var gameObject in filter)
				{
					result.Add(filter.Result<T>(pass, gameObject));
				}

				return result;
			}
		}

		/// <summary>
		/// Finds all game objects that contain all the specified components.
		/// </summary>
		/// <typeparam name="T1">The type of the first component.</typeparam>
		/// <typeparam name="T2">The type of the second component.</typeparam>
		/// <param name="forceNative">Whether a native query should be forced. Enable when querying in edit-mode.</param>
		/// <returns>The tuples of components per game object.</returns>
		public static QueryResult<(T1, T2)> Query<T1, T2>(bool forceNative = false)
		{
			using (var filter = QueryFilter.New(2))
			{
				var pass1 = filter.Pass<T1>(forceNative);
				var pass2 = filter.Pass<T2>(forceNative);

				var result = QueryResult<(T1, T2)>.New();

				foreach (var gameObject in filter)
				{
					result.Add
					(
						(
							filter.Result<T1>(pass1, gameObject),
							filter.Result<T2>(pass2, gameObject)
						)
					);
				}

				return result;
			}
		}
		
		/// <summary>
		/// Finds all game objects that contain all the specified components.
		/// </summary>
		/// <typeparam name="T1">The type of the first component.</typeparam>
		/// <typeparam name="T2">The type of the second component.</typeparam>
		/// <typeparam name="T3">The type of the third component.</typeparam>
		/// <param name="forceNative">Whether a native query should be forced. Enable when querying in edit-mode.</param>
		/// <returns>The tuples of components per game object.</returns>
		public static QueryResult<(T1, T2, T3)> Query<T1, T2, T3>(bool forceNative = false)
		{
			using (var filter = QueryFilter.New(3))
			{
				var pass1 = filter.Pass<T1>(forceNative);
				var pass2 = filter.Pass<T2>(forceNative);
				var pass3 = filter.Pass<T3>(forceNative);

				var result = QueryResult<(T1, T2, T3)>.New();

				foreach (var gameObject in filter)
				{
					result.Add
					(
						(
							filter.Result<T1>(pass1, gameObject),
							filter.Result<T2>(pass2, gameObject),
							filter.Result<T3>(pass3, gameObject)
						)
					);
				}

				return result;
			}
		}
		
		/// <summary>
		/// Finds all game objects that contain all the specified components.
		/// </summary>
		/// <typeparam name="T1">The type of the first component.</typeparam>
		/// <typeparam name="T2">The type of the second component.</typeparam>
		/// <typeparam name="T3">The type of the third component.</typeparam>
		/// <typeparam name="T4">The type of the fourth component.</typeparam>
		/// <param name="forceNative">Whether a native query should be forced. Enable when querying in edit-mode.</param>
		/// <returns>The tuples of components per game object.</returns>
		public static QueryResult<(T1, T2, T3, T4)> Query<T1, T2, T3, T4>(bool forceNative = false)
		{
			using (var filter = QueryFilter.New(4))
			{
				var pass1 = filter.Pass<T1>(forceNative);
				var pass2 = filter.Pass<T2>(forceNative);
				var pass3 = filter.Pass<T3>(forceNative);
				var pass4 = filter.Pass<T4>(forceNative);

				var result = QueryResult<(T1, T2, T3, T4)>.New();

				foreach (var gameObject in filter)
				{
					result.Add
					(
						(
							filter.Result<T1>(pass1, gameObject),
							filter.Result<T2>(pass2, gameObject),
							filter.Result<T3>(pass3, gameObject),
							filter.Result<T4>(pass4, gameObject)
						)
					);
				}

				return result;
			}
		}
		
		/// <summary>
		/// Finds all game objects that contain all the specified components.
		/// </summary>
		/// <typeparam name="T1">The type of the first component.</typeparam>
		/// <typeparam name="T2">The type of the second component.</typeparam>
		/// <typeparam name="T3">The type of the third component.</typeparam>
		/// <typeparam name="T4">The type of the fourth component.</typeparam>
		/// <typeparam name="T5">The type of the fifth component.</typeparam>
		/// <param name="forceNative">Whether a native query should be forced. Enable when querying in edit-mode.</param>
		/// <returns>The tuples of components per game object.</returns>
		public static QueryResult<(T1, T2, T3, T4, T5)> Query<T1, T2, T3, T4, T5>(bool forceNative = false)
		{
			using (var filter = QueryFilter.New(5))
			{
				var pass1 = filter.Pass<T1>(forceNative);
				var pass2 = filter.Pass<T2>(forceNative);
				var pass3 = filter.Pass<T3>(forceNative);
				var pass4 = filter.Pass<T4>(forceNative);
				var pass5 = filter.Pass<T5>(forceNative);

				var result = QueryResult<(T1, T2, T3, T4, T5)>.New();

				foreach (var gameObject in filter)
				{
					result.Add
					(
						(
							filter.Result<T1>(pass1, gameObject),
							filter.Result<T2>(pass2, gameObject),
							filter.Result<T3>(pass3, gameObject),
							filter.Result<T4>(pass4, gameObject),
							filter.Result<T5>(pass5, gameObject)
						)
					);
				}

				return result;
			}
		}

		#endregion
	}
}
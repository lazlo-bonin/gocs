using System;
using System.Collections.Generic;

namespace Lazlo.Gocs
{
	public static class World
	{
		#region Systems & Components

		private static readonly List<ISystem> systems = new List<ISystem>();

		private static readonly List<IComponent> components = new List<IComponent>();

		public static void AddSystem(ISystem system)
		{
			if (system == null)
			{
				throw new ArgumentNullException(nameof(system));
			}

			if (system is IWorldCallbackReceiver callbackReceiver)
			{
				foreach (var component in components)
				{
					callbackReceiver.OnAddComponent(component);
				}
			}

			systems.Add(system);
		}

		public static void RemoveSystem(ISystem system)
		{
			if (system == null)
			{
				throw new ArgumentNullException(nameof(system));
			}

			if (system is IWorldCallbackReceiver callbackReceiver)
			{
				foreach (var component in components)
				{
					callbackReceiver.OnRemoveComponent(component);
				}
			}

			systems.Remove(system);
		}

		public static void AddComponent(IComponent component)
		{
			if (component == null)
			{
				throw new ArgumentNullException(nameof(component));
			}

			components.Add(component);

			Registries.Add(component);

			foreach (var system in systems)
			{
				if (system is IWorldCallbackReceiver callbackReceiver)
				{
					callbackReceiver.OnAddComponent(component);
				}
			}
		}

		public static void RemoveComponent(IComponent component)
		{
			if (component == null)
			{
				throw new ArgumentNullException(nameof(component));
			}

			foreach (var system in systems)
			{
				if (system is IWorldCallbackReceiver callbackReceiver)
				{
					callbackReceiver.OnRemoveComponent(component);
				}
			}

			Registries.Remove(component);

			components.Remove(component);
		}

		#endregion



		#region Queries

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

		public static QueryResult<(T1, T2, T3, T4)> Query<T1, T2, T3, T4>(bool forceNative = false)
		{
			using (var filter = QueryFilter.New(3))
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

		public static QueryResult<(T1, T2, T3, T4, T5)> Query<T1, T2, T3, T4, T5>(bool forceNative = false)
		{
			using (var filter = QueryFilter.New(3))
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
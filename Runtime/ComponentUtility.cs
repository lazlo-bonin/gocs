using UnityEngine;

namespace Lazlo.Gocs
{
	/// <summary>
	/// Provides extension methods to facilitate component access on game objects.
	/// </summary>
	public static class ComponentUtility
	{
#if !UNITY_2019_2_OR_NEWER
		public static bool TryGetCompoennt<T>(this GameObject go, out T component)
		{
			component = go.GetComponent<T>();

			return component != null;
		}

		public static bool TryGetCompoennt<T>(this Component c, out T component)
		{
			component = c.GetComponent<T>();

			return component != null;
		}
#endif

		/// <summary>
		/// Checks the game object for the specified component.
		/// </summary>
		/// <typeparam name="T">The type of the component.</typeparam>
		/// <param name="go">The game object.</param>
		/// <param name="component">The returned component.</param>
		/// <returns>Whether the game object contains the specified component type.</returns>
		public static bool Has<T>(this GameObject go, out T component)
		{
			return go.TryGetComponent(out component);
		}

		/// <summary>
		/// Checks the game object for the specified components.
		/// </summary>
		/// <typeparam name="T1">The type of the first component.</typeparam>
		/// <typeparam name="T2">The type of the second component.</typeparam>
		/// <param name="go">The game object.</param>
		/// <param name="component1">The first returned component.</param>
		/// <param name="component2">The second returned component.</param>
		/// <returns>Whether the game object contains all specified component types.</returns>
		public static bool Has<T1, T2>(this GameObject go, out T1 component1, out T2 component2)
		{
			component1 = default;
			component2 = default;

			return go.TryGetComponent(out component1) &&
			       go.TryGetComponent(out component2);
		}
		
		/// <summary>
		/// Checks the game object for the specified components.
		/// </summary>
		/// <typeparam name="T1">The type of the first component.</typeparam>
		/// <typeparam name="T2">The type of the second component.</typeparam>
		/// <typeparam name="T3">The type of the third component.</typeparam>
		/// <param name="go">The game object.</param>
		/// <param name="component1">The first returned component.</param>
		/// <param name="component2">The second returned component.</param>
		/// <param name="component3">The third returned component.</param>
		/// <returns>Whether the game object contains all specified component types.</returns>
		public static bool Has<T1, T2, T3>(this GameObject go, out T1 component1, out T2 component2, out T3 component3)
		{
			component1 = default;
			component2 = default;
			component3 = default;

			return go.TryGetComponent(out component1) &&
			       go.TryGetComponent(out component2) &&
			       go.TryGetComponent(out component3);
		}
		
		/// <summary>
		/// Checks the game object for the specified components.
		/// </summary>
		/// <typeparam name="T1">The type of the first component.</typeparam>
		/// <typeparam name="T2">The type of the second component.</typeparam>
		/// <typeparam name="T3">The type of the third component.</typeparam>
		/// <typeparam name="T4">The type of the fourth component.</typeparam>
		/// <param name="go">The game object.</param>
		/// <param name="component1">The first returned component.</param>
		/// <param name="component2">The second returned component.</param>
		/// <param name="component3">The third returned component.</param>
		/// <param name="component4">The fourth returned component.</param>
		/// <returns>Whether the game object contains all specified component types.</returns>
		public static bool Has<T1, T2, T3, T4>(this GameObject go, out T1 component1, out T2 component2, out T3 component3, out T4 component4)
		{
			component1 = default;
			component2 = default;
			component3 = default;
			component4 = default;

			return go.TryGetComponent(out component1) &&
			       go.TryGetComponent(out component2) &&
			       go.TryGetComponent(out component3) &&
			       go.TryGetComponent(out component4);
		}
		
		/// <summary>
		/// Checks the game object for the specified components.
		/// </summary>
		/// <typeparam name="T1">The type of the first component.</typeparam>
		/// <typeparam name="T2">The type of the second component.</typeparam>
		/// <typeparam name="T3">The type of the third component.</typeparam>
		/// <typeparam name="T4">The type of the fourth component.</typeparam>
		/// <typeparam name="T5">The type of the fifth component.</typeparam>
		/// <param name="go">The game object.</param>
		/// <param name="component1">The first returned component.</param>
		/// <param name="component2">The second returned component.</param>
		/// <param name="component3">The third returned component.</param>
		/// <param name="component4">The fourth returned component.</param>
		/// <param name="component5">The fifth returned component.</param>
		/// <returns>Whether the game object contains all specified component types.</returns>
		public static bool Has<T1, T2, T3, T4, T5>(this GameObject go, out T1 component1, out T2 component2, out T3 component3, out T4 component4, out T5 component5)
		{
			component1 = default;
			component2 = default;
			component3 = default;
			component4 = default;
			component5 = default;

			return go.TryGetComponent(out component1) &&
			       go.TryGetComponent(out component2) &&
			       go.TryGetComponent(out component3) &&
			       go.TryGetComponent(out component4) &&
			       go.TryGetComponent(out component5);
		}

		/// <summary>
		/// Gets the specified component from the game object.
		/// </summary>
		/// <typeparam name="T">The type of the component.</typeparam>
		/// <param name="go">The game object.</param>
		/// <returns>The component, or null if not contained in the game object.</returns>
		public static T Get<T>(this GameObject go)
		{
			return go.GetComponent<T>();
		}

		/// <summary>
		/// Gets the specified components from the game object.
		/// </summary>
		/// <typeparam name="T1">The type of the first component.</typeparam>
		/// <typeparam name="T2">The type of the second component.</typeparam>
		/// <param name="go">The game object.</param>
		/// <returns>The components. Each component can be null if not contained in the game object.</returns>
		public static (T1, T2) Get<T1, T2>(this GameObject go)
		{
			return
			(
				go.GetComponent<T1>(),
				go.GetComponent<T2>()
			);
		}
		
		/// <summary>
		/// Gets the specified components from the game object.
		/// </summary>
		/// <typeparam name="T1">The type of the first component.</typeparam>
		/// <typeparam name="T2">The type of the second component.</typeparam>
		/// <typeparam name="T3">The type of the third component.</typeparam>
		/// <param name="go">The game object.</param>
		/// <returns>The components. Each component can be null if not contained in the game object.</returns>
		public static (T1, T2, T3) Get<T1, T2, T3>(this GameObject go)
		{
			return
			(
				go.GetComponent<T1>(),
				go.GetComponent<T2>(),
				go.GetComponent<T3>()
			);
		}
		
		/// <summary>
		/// Gets the specified components from the game object.
		/// </summary>
		/// <typeparam name="T1">The type of the first component.</typeparam>
		/// <typeparam name="T2">The type of the second component.</typeparam>
		/// <typeparam name="T3">The type of the third component.</typeparam>
		/// <typeparam name="T4">The type of the fourth component.</typeparam>
		/// <param name="go">The game object.</param>
		/// <returns>The components. Each component can be null if not contained in the game object.</returns>
		public static (T1, T2, T3, T4) Get<T1, T2, T3, T4>(this GameObject go)
		{
			return
			(
				go.GetComponent<T1>(),
				go.GetComponent<T2>(),
				go.GetComponent<T3>(),
				go.GetComponent<T4>()
			);
		}
		
		/// <summary>
		/// Gets the specified components from the game object.
		/// </summary>
		/// <typeparam name="T1">The type of the first component.</typeparam>
		/// <typeparam name="T2">The type of the second component.</typeparam>
		/// <typeparam name="T3">The type of the third component.</typeparam>
		/// <typeparam name="T4">The type of the fourth component.</typeparam>
		/// <typeparam name="T5">The type of the fifth component.</typeparam>
		/// <param name="go">The game object.</param>
		/// <returns>The components. Each component can be null if not contained in the game object.</returns>
		public static (T1, T2, T3, T4, T5) Get<T1, T2, T3, T4, T5>(this GameObject go)
		{
			return
			(
				go.GetComponent<T1>(),
				go.GetComponent<T2>(),
				go.GetComponent<T3>(),
				go.GetComponent<T4>(),
				go.GetComponent<T5>()
			);
		}
	}
}
using System;
using UnityEngine;

namespace Lazlo.Gocs
{
	/// <summary>
	/// Automatically adds the required component as a dependency at runtime.
	/// <para>
	/// Unlike <see cref="RequireComponent"/>, this attribute will not require the component during edit mode.
	/// </para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
	public sealed class RuntimeRequireComponentAttribute : Attribute
	{
		public Type componentType { get; }

		public RuntimeRequireComponentAttribute(Type componentType)
		{
			if (componentType == null)
			{
				throw new ArgumentNullException(nameof(componentType));
			}

			if (!typeof(Component).IsAssignableFrom(componentType))
			{
				throw new ArgumentException("Type must be a component.", nameof(componentType));
			}

			this.componentType = componentType;
		}
	}
}
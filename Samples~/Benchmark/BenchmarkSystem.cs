using UnityEngine;
using UnityEngine.Profiling;

namespace Lazlo.Gocs.Benchmark
{
	/* Benchmark results, 10K objects:
	 *
	 * Native Query:  36.28ms, 195.2KB
	 * Managed Query: 13.58ms, 0B		(~3x faster)
	 * System Query:   0.16ms, 0B		(~200x faster)
	*/

	public class BenchmarkSystem : BaseSystem
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void BeforeLoad()
		{
			World.enableRegistries = true;
		}

		private readonly SystemComponents<BenchmarkComponent1, BenchmarkComponent2> components = new SystemComponents<BenchmarkComponent1, BenchmarkComponent2>();

		public int count = 1000;

		private int objective;

		private int tally;

		public override void OnCreatedComponent(IComponent component)
		{
			components.Add(component.gameObject);
		}

		public override void OnDestroyingComponent(IComponent component)
		{
			components.Remove(component.gameObject);
		}

		private void Start()
		{
			Spawn();
		}

		private void Spawn()
		{
			for (var i = 0; i < count; i++)
			{
				var go = new GameObject();
				go.AddComponent<BenchmarkComponent1>();

				if (Random.value < 0.5f)
				{
					go.AddComponent<BenchmarkComponent2>();
					objective++;
				}
			}
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Spawn();
			}

			tally = 0;
			Profiler.BeginSample("System Query");
			SystemQuery();
			Profiler.EndSample();
			Debug.Assert(tally == objective);

			tally = 0;
			Profiler.BeginSample("Managed Query");
			ManagedQuery();
			Profiler.EndSample();
			Debug.Assert(tally == objective);

			tally = 0;
			Profiler.BeginSample("Native Query");
			NativeQuery();
			Profiler.EndSample();
			Debug.Assert(tally == objective);
		}

		void SystemQuery()
		{
			foreach (var (component1, component2) in components)
			{
				IncreaseTally(component1, component2);
			}
		}

		void ManagedQuery()
		{
			foreach (var (component1, component2) in World.Query<BenchmarkComponent1, BenchmarkComponent2>())
			{
				IncreaseTally(component1, component2);
			}
		}

		void NativeQuery()
		{
			foreach (var (component1, component2) in World.Query<BenchmarkComponent1, BenchmarkComponent2>(true))
			{
				IncreaseTally(component1, component2);
			}
		}

		void IncreaseTally(BenchmarkComponent1 component1, BenchmarkComponent2 component2)
		{
			tally++;
		}
	}
}
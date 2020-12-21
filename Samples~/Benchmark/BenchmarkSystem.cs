using System.Collections.Generic;
using System.Linq;
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
		private readonly SystemComponents<BenchmarkComponent1, BenchmarkComponent2> components = new SystemComponents<BenchmarkComponent1, BenchmarkComponent2>();

		private const int COUNT = 10_000;

		private int objective;

		private int tally;

		private uint frameCount;
		
		private CustomSampler 
		    systemQuerySampler, 
		    worldManagedQuerySampler, 
		    worldNativeQuerySampler;
		
		private Recorder 
		    systemQueryRecorder, 
		    worldManagedQueryRecorder, 
		    worldNativeQueryRecorder;
		
		[SerializeField] private List<long> 
			systemQueryTimes,
			worldManagedQueryTimes,
			worldNativeQueryTimes;

		[SerializeField] private double
			systemQueryAverage,
			worldManagedQueryAverage,
			worldNativeQueryAverage;

		public override void OnCreatedComponent(in IComponent component)
		{
			components.Add(component.gameObject);
		}

		public override void OnDestroyedComponent(in IComponent component)
		{
			components.Remove(component.gameObject);
		}

		private void Start()
		{
			Spawn();
			CreateSamplers();
		}

		private void Spawn()
		{
			for (var i = 0; i < COUNT; i++)
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
		
		private void CreateSamplers()
		{
		    systemQuerySampler = CustomSampler.Create(name: "System Query");
		    worldManagedQuerySampler = CustomSampler.Create(name: "World Query (Managed)");
		    worldNativeQuerySampler = CustomSampler.Create(name: "World Query (Native)");
		    
            systemQueryRecorder = systemQuerySampler.GetRecorder();
            if (systemQueryRecorder.isValid)
            {
                systemQueryRecorder.enabled = true;
            }
            
            worldManagedQueryRecorder = worldManagedQuerySampler.GetRecorder();
            if (worldManagedQueryRecorder.isValid)
            {
                systemQueryRecorder.enabled = true;
            }
                        
            worldNativeQueryRecorder = worldNativeQuerySampler.GetRecorder();
            if (worldNativeQueryRecorder.isValid)
            {
                worldNativeQueryRecorder.enabled = true;
            }
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Spawn();
			}

			NativeQuery();
			ManagedQuery();
			SystemQuery();
		}

		private void SystemQuery()
		{
			tally = 0;
			
			systemQuerySampler.Begin();
			foreach (var (__component1, component2) in components)
			{
				tally++;
			}
			systemQuerySampler.End();

			if (systemQueryRecorder.isValid)
			{
				systemQueryTimes.Add(systemQueryRecorder.elapsedNanoseconds);	
			}
			systemQueryAverage = ConvertNanosecondsToMilliseconds(nanoseconds: systemQueryTimes.Count > 0 ? systemQueryTimes.Average() : 0.0);
			
			Debug.Assert(condition: tally == objective);
			
			
		}

		private void ManagedQuery()
		{
			tally = 0;
			
			worldManagedQuerySampler.Begin();
			foreach (var (component1, component2) in World.Query<BenchmarkComponent1, BenchmarkComponent2>())
			{
				tally++;
			}
			worldManagedQuerySampler.End();

			if (worldManagedQueryRecorder.isValid)
			{
				worldManagedQueryTimes.Add(worldManagedQueryRecorder.elapsedNanoseconds);	
			}
			worldManagedQueryAverage = ConvertNanosecondsToMilliseconds(nanoseconds: worldManagedQueryTimes.Count > 0 ? worldManagedQueryTimes.Average() : 0.0);
			
			Debug.Assert(condition: tally == objective);
		}

		private void NativeQuery()
		{
			tally = 0;
			
			worldNativeQuerySampler.Begin();
			foreach (var (component1, component2) in World.Query<BenchmarkComponent1, BenchmarkComponent2>(forceNative: true))
			{
				tally++;
			}
			worldNativeQuerySampler.End();

			if (worldNativeQueryRecorder.isValid)
			{
				worldNativeQueryTimes.Add(worldNativeQueryRecorder.elapsedNanoseconds);	
			}
			worldNativeQueryAverage = ConvertNanosecondsToMilliseconds(nanoseconds: worldNativeQueryTimes.Count > 0 ? worldNativeQueryTimes.Average() : 0.0);
			
			Debug.Assert(condition: tally == objective);
		}

		private static double ConvertNanosecondsToMilliseconds(in double nanoseconds)
		{
			return nanoseconds * 0.000001;
		}

	}
}
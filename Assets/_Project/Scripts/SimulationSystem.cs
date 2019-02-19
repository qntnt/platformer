using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace _Project.Scripts {
    public class SimulationSystem : JobComponentSystem {

        [BurstCompile]
        private struct SimulationJob : IJobProcessComponentData<SimulationData> {

            public float DeltaTime;
            
            public void Execute(ref SimulationData simulation) {
                simulation.deltaTime = DeltaTime;
            }
        }
        
        protected override JobHandle OnUpdate(JobHandle inputDeps) {
            return new SimulationJob {
                DeltaTime = Time.deltaTime
            }.Schedule(this, inputDeps);
        }
    }
}
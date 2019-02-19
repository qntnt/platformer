using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace _Project.Scripts {
    public class GravitySystem : JobComponentSystem {
        [BurstCompile]
        private struct GravityJob : IJobProcessComponentDataWithEntity<Position, MovementData, GravityForce, SimulationData> {
            public float DeltaTime;

            public void Execute(Entity entity, int i, ref Position position, ref MovementData moveData, ref GravityForce gravityForce, ref SimulationData simulation) {
                if (simulation.isPaused) return;
                moveData.velocity += math.normalize(gravityForce.direction) * gravityForce.magnitude * DeltaTime;
                position.Value += moveData.velocity * DeltaTime;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps) {
            var gravityJob = new GravityJob {
                DeltaTime = Time.deltaTime
            };
            return gravityJob.Schedule(this, inputDeps);
        }
    }
}
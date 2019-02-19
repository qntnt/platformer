using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace _Project.Scripts {
    public class PlayerMovementSystem : JobComponentSystem {
        private struct MoveJob : IJobProcessComponentData<Position, MovementData, SimulationData, InputData> {

            public void Execute(
                ref Position position, 
                ref MovementData moveData, 
                ref SimulationData simulation, 
                ref InputData inputData
                ) {
                if (simulation.isPaused) return;
                
                if (inputData.jump > 0) {
                    moveData.velocity.y = moveData.jumpVelocity;
                }

                var moveVector = new float3(inputData.horizontal, 0, 0) * moveData.speed;
                position.Value = position.Value + moveVector * simulation.deltaTime;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps) {
            var moveJob = new MoveJob { };
            return moveJob.Schedule(this, inputDeps);
        }
    }
}
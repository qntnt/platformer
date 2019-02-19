using System;
using Unity.Entities;

namespace _Project.Scripts {
    [Serializable]
    public struct SimulationData : IComponentData {
        public float deltaTime;
        public BlittableBool isPaused;
    }

    public class SimulationComponent : ComponentDataWrapper<SimulationData> { }
}
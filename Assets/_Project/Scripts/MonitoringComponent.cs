using System;
using Unity.Entities;

namespace _Project.Scripts {
    [Serializable]
    public struct MonitoringData : IComponentData {
        public float fps;
    }

    public class MonitoringComponent : ComponentDataWrapper<MonitoringData> { }
}
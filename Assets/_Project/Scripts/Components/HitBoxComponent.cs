using System;
using Unity.Entities;
using Unity.Mathematics;

namespace _Project.Scripts {
    [Serializable]
    public struct HitBox : IComponentData {
        public float3 center;
        public float3 dimensions;
    }

    public class HitBoxComponent : ComponentDataWrapper<HitBox> { }
}
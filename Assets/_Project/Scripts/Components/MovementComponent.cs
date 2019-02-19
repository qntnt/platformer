using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.Serialization;

namespace _Project.Scripts {
    [Serializable]
    public struct MovementData : IComponentData {
        public float speed;

        public float3 velocity;

        public float jumpVelocity;
    }

    public class MovementComponent : ComponentDataWrapper<MovementData> { }
}
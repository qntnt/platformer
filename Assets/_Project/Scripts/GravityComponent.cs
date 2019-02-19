using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.Serialization;

namespace _Project.Scripts {
    
    [Serializable]
    public struct GravityForce : IComponentData {
        public float magnitude;
        public float3 direction;
    }

    public class GravityComponent : ComponentDataWrapper<GravityForce> { }
}
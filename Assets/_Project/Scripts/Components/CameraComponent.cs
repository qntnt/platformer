using System;
using Unity.Entities;
using Unity.Mathematics;

namespace _Project.Scripts {
    [Serializable]
    public struct CameraFocalPoint : IComponentData {
        public float3 center;
        public float width;
        public float height;
    }

    [UnityEngine.DisallowMultipleComponent]
    public class CameraComponent : ComponentDataWrapper<CameraFocalPoint> { }
}
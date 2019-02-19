using System;
using Unity.Entities;

namespace _Project.Scripts {
    [Serializable]
    public struct CameraTarget : IComponentData { }

    public class CameraTargetComponent : ComponentDataWrapper<CameraTarget> { }
}
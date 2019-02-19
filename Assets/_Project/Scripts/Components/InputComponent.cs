using System;
using Unity.Entities;

namespace _Project.Scripts {
    [Serializable]
    public struct InputData : IComponentData {
        public float horizontal;
        public float jump;
        public float cancel;
    }

    [UnityEngine.DisallowMultipleComponent]
    public class InputComponent : ComponentDataWrapper<InputData> { }
}
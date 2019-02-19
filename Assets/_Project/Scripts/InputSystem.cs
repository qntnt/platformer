using Unity.Entities;
using UnityEngine;

namespace _Project.Scripts {
    public class InputSystem : ComponentSystem {
        private ComponentGroup group;

        protected override void OnCreateManager() {
            group = GetComponentGroup(typeof(InputData));
        }

        protected override void OnUpdate() {
            var horizontal = Input.GetAxis("Horizontal");
            var jump = Input.GetAxis("Jump");
            var cancel = Input.GetAxis("Cancel");
            SetSingleton(new InputData {
                horizontal = horizontal,
                jump = jump,
                cancel = cancel
            });
        }
    }
}
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace _Project.Scripts {
    public class CameraSystem : ComponentSystem {
        private ComponentGroup _cameraGroup;

        protected override void OnCreateManager() {
            _cameraGroup = GetComponentGroup(
                typeof(Position),
                typeof(CameraFocalPoint),
                typeof(Camera)
            );
        }

        protected override void OnUpdate() {
            var cameraEntities = _cameraGroup.GetEntityArray();
            var cameraPositions = _cameraGroup.GetComponentDataArray<Position>();
            var focuses = _cameraGroup.GetComponentDataArray<CameraFocalPoint>();
            var cameras = _cameraGroup.GetComponentArray<Camera>();
            if (cameraEntities.Length > 0) {
                PostUpdateCommands.SetComponent<Position>(
                    cameraEntities[0],
                    new Position {
                        Value = focuses[0].center
                    }
                );
            }
        }
    }
}
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;
using _Project.Scripts;

public class RoomSystem : ComponentSystem {
    ComponentGroup cameraGroup;
    ComponentGroup roomGroup;
    ComponentGroup targetGroup;

    protected override void OnCreateManager() {
        cameraGroup = GetComponentGroup(typeof(CameraFocalPoint));
        roomGroup = GetComponentGroup(
            typeof(Position),
            typeof(Scale),
            typeof(RoomData));
        targetGroup = GetComponentGroup(
            typeof(Position), typeof(CameraTarget));
    }

    protected override void OnUpdate() {
        var cameraEntities = cameraGroup.GetEntityArray();
        var cameraFocuses = cameraGroup.GetComponentDataArray<CameraFocalPoint>();
        var targets = targetGroup.GetComponentDataArray<Position>();
        var roomPositions = roomGroup.GetComponentDataArray<Position>();
        var roomScales = roomGroup.GetComponentDataArray<Scale>();
        var roomDataArray = roomGroup.GetComponentDataArray<RoomData>();
        if (targets.Length <= 0 || cameraFocuses.Length <= 0) return;
        var cameraEntity = cameraEntities[0];
        var cameraFocus = cameraFocuses[0];
        var target = targets[0];
        for (var i = 0; i < roomPositions.Length; i++) {
            var roomPosition = roomPositions[i];
            var roomScale = roomScales[i];
            if (
                target.Value.x < roomPosition.Value.x + roomScale.Value.x
                && target.Value.y < roomPosition.Value.y + roomScale.Value.y
                && target.Value.x > roomPosition.Value.x - roomScale.Value.x
                && target.Value.y > roomPosition.Value.y - roomScale.Value.y
            ) {
                PostUpdateCommands.SetComponent<CameraFocalPoint>(cameraEntity, new CameraFocalPoint {
                    center = roomPosition.Value,
                    width = roomScale.Value.x,
                    height = roomScale.Value.y
                });
            }
        }
    }
}
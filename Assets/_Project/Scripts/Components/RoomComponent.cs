using Unity.Entities;
using System;
using Unity.Transforms;
using Unity.Mathematics;

[Serializable]
public struct RoomData : IComponentData {
    public float2 dimensions;
    public float3 center;
}

public class RoomComponent : ComponentDataWrapper<RoomData> { }
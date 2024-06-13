using System;
using Unity.Mathematics;

[Serializable]
public struct PlayerData
{


public PlayerMovementData movementData;
public PlayerMeshData meshData;
public PlayerForceData forceData;
        
        
}

[Serializable]
public struct PlayerMovementData
{
    public float ForwardSpeed;
    public float SidewaySpeed;
}
[Serializable]
 public struct PlayerMeshData
 {
    public float ScaleCounter;
 }

 [Serializable]
 public struct PlayerForceData
 {
    public float3 ForceParameters;

 }
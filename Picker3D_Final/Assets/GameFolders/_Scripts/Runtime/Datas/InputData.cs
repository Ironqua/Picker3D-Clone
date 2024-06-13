using System;
using Unity.Mathematics;

[Serializable]
public struct InputData
{
    public float HorizontalInputSpeed;
    public float2 ClampValues; 
    public float ClampSpeed;
}

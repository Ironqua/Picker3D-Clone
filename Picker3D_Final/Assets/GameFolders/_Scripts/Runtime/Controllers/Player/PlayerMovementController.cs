using Runtime.Keys;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField] private new Rigidbody rigidbody;
    
    PlayerMovementData _data;
    private bool _isReadyToMove,_isReadyToPlay;
    private float _xValue;

    float2 _clampValues;


internal void SetData(PlayerMovementData data)
{
_data = data;
}


void FixedUpdate()
{
    if(!_isReadyToPlay)
    {
        StopPlayer();
        return;
    }

    if(_isReadyToMove==true)
    {
        MovePlayer();
    }
    else
    {
        StopPlayerHorizontally();
    }
}
internal void IsReadyToPlay(bool condition)
{
    _isReadyToPlay=condition;
}
internal void IsReadyToMove(bool condition)
{
    _isReadyToMove=condition;
}

internal void UpdateInputParams(HorizontalInputParams inputParams)
{
    _xValue=inputParams.HorizontalValue;
    _clampValues=inputParams.ClampValues;
}




private void MovePlayer()
{
    var velocity=rigidbody.velocity;
    velocity=new Vector3(_xValue*_data.SidewaySpeed,velocity.y,_data.ForwardSpeed);
    rigidbody.velocity=velocity;
    var positon1=rigidbody.position;
    Vector3 positon=new Vector3(Mathf.Clamp(positon1.x,_clampValues.x,_clampValues.y),(positon=rigidbody.position).y,positon.z);
    rigidbody.position=positon;
}

    private void StopPlayer()
    {
        rigidbody.velocity=Vector3.zero;
        rigidbody.angularVelocity=Vector3.zero;
    }

    private void StopPlayerHorizontally()
    {
        rigidbody.velocity=new Vector3(0,rigidbody.velocity.y,_data.ForwardSpeed);
        rigidbody.angularVelocity=Vector3.zero;

    }

 

    internal void OnReset()
    {
        StopPlayer();
        _isReadyToMove=false;
        _isReadyToPlay=false;
    }
    

}

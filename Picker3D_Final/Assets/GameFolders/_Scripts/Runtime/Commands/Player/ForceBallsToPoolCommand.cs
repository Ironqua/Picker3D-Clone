using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ForceBallsToPoolCommand 
{
    private PlayerManager _playerManager;
    private PlayerForceData _playerForceData;
    public ForceBallsToPoolCommand(PlayerManager playerManager,PlayerForceData playerForceData)
    {
        _playerForceData = playerForceData;
        _playerManager = playerManager;
    }
    internal void Execute()
     {
        var transform1=_playerManager.transform;
        var positon1=transform1.position;
        var forcePos=new Vector3(positon1.x,positon1.y-1,positon1.z);

        var collider=Physics.OverlapSphere(forcePos,1f);
        
        var collectableColliderList=collider.Where(collider=>collider.CompareTag("Collectable")).ToList();

        foreach (var col in collectableColliderList)
        {
            if(col.GetComponent<Rigidbody>()==null) continue;
            Rigidbody rb;
            rb=col.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0,_playerForceData.ForceParameters.y,_playerForceData.ForceParameters.z),ForceMode.Impulse);
        }

        collectableColliderList.Clear();
        
     }
}

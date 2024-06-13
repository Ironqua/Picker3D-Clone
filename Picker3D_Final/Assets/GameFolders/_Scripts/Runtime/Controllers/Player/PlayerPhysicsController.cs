using DG.Tweening;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
   [SerializeField] private PlayerManager manager;
   [SerializeField] private new Collider collider;
   [SerializeField] private new Rigidbody rigidbody;

  float count;

PlayerForceData  _data;
public void SetData(PlayerForceData data)
{
_data = data;
}


void OnTriggerEnter(Collider other)
{
    if(other.gameObject.CompareTag("StageArea"))
    {
        manager.ForceCommand.Execute();
        CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
        InputSignals.Instance.onDisableInput?.Invoke();


        DOVirtual.DelayedCall(1.5f,()=>
        {
             var result=other.transform.parent.GetComponentInChildren<PoolController>()
            .TakeResults(manager.StageValue);
            
            
Debug.Log($"{result}");
            if(result)
            {
                CoreGameSignals.Instance.onStageAreaSuccesfull?.Invoke(manager.StageValue);
                InputSignals.Instance.onEnableInput?.Invoke();
                Debug.Log($"{manager.StageValue}");
              
            }
            else
            {
                CoreGameSignals.Instance.onLevelFailed?.Invoke();
            }
        });

        return;

    }


    if(other.CompareTag("FinishArea"))
    {
        CoreGameSignals.Instance.onFinishAreaEntered?.Invoke();
        InputSignals.Instance.onDisableInput?.Invoke();
        Debug.Log($"finish");
        CoreGameSignals.Instance.onLevelSuccesful?.Invoke();

        return;
    }

    if(other.CompareTag("MiniGameArea"))
    {
       
        CoreGameSignals.Instance.onMiniGameAreaEntered?.Invoke();
       Debug.Log($"minigame");
      
        
    }

}





public void OnReset()
{

}
}

using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    [SerializeField] private TextMeshPro poolText;
    [SerializeField] byte stageId;
    [SerializeField] new Renderer renderer;
    [SerializeField] GameObject prefab;
    
   


private PoolData _data;

public byte CollectedCount;


void Awake()
{
   
    _data = GetPoolData();
   
   SubscribeEvents();

    
}

    
    private PoolData GetPoolData()
    {
        return Resources.Load<CD_Level>($"Datas/CD_Level").Levels[(int)CoreGameSignals.Instance.onGetLevelValue?.Invoke()].PoolDataList[stageId];
    }
    

    private void OnEable()
    {
       SubscribeEvents();
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onStageAreaSuccesfull+=OnAtivateTween;
        CoreGameSignals.Instance.onStageAreaSuccesfull+=OnChangePoolColor;
    }

    private void OnChangePoolColor(byte value)
    {
      if (stageId != value) return;
     
            renderer.material.DOColor(Color.green, .5f)
                .SetEase(Ease.Flash)
                .SetRelative(false);


    }
    private void OnAtivateTween(byte value)
    {
         if(value!=stageId) return;
     prefab.transform.DOMoveX(15f,0.5f);
      
          
    }

    private void UnSubscribeEvents()
    {
        CoreGameSignals.Instance.onStageAreaSuccesfull-=OnAtivateTween;
        CoreGameSignals.Instance.onStageAreaSuccesfull-=OnChangePoolColor;
    }

    void Start()
    {
        SetRequiredAmountText();
    }

    private void SetRequiredAmountText()
    {
        poolText.text=$"{_data.RequiredObjCount}";
    }

    public bool TakeResults(byte value)
    {
        if(stageId==value)
        {
            return CollectedCount>=_data.RequiredObjCount;
        }
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Collectable")) return;
        IncreaseCollectedAmount();
        SetCollectedAmountToPooll();

        if(other.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void SetCollectedAmountToPooll()
    {
        poolText.text=$"{CollectedCount}/{_data.RequiredObjCount}";
    }

    private void IncreaseCollectedAmount()
    {
        
        CollectedCount++;
         PlayerCollectedCount.Instance.PlayerCollectedBall++;
   // Debug.Log($"{PlayerCollectedCount.Instance.PlayerCollectedBall} sinleton ball");
  //  Debug.Log($"{CollectedCount} collected ball");
    

   
    }
    void OnTriggerExit(Collider other)
    {
           if(!other.CompareTag("Collectable")) return;
             SetCollectedAmountToPooll();
             DecreaseCollectedAmount();
    }

    private void DecreaseCollectedAmount()
    {
       
    }
}

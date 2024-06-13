using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UISignals : MonoBehaviour
{
    public static UISignals Instance { get; set; } 

    
    public UnityAction<byte> onSetStageColor=delegate { };
    public UnityAction<byte> onSetLevelValue=delegate { };
    public UnityAction onPlay=delegate { };
    public UnityAction onScoreText=delegate { };
    
    
    
    
    
    
    
    
    
    
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
}

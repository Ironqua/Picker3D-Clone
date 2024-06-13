using System;
using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoBehaviour
{
    public static CoreGameSignals Instance { get; private set; }


    public UnityAction<byte> onLevelInitialize=delegate {  };
    public UnityAction onClearActiveLevel=delegate {  };

    public UnityAction onLevelSuccesful=delegate {  };
    public UnityAction onLevelFailed=delegate {  };
    
    //public UnityAction<byte> onGetLevelValue=delegate {  };
    public Func<byte> onGetLevelValue=delegate {  return 0; }; 
    public UnityAction onReset=delegate {  };
    public UnityAction onNextLevel=delegate {  };
    public UnityAction onRestartLevel=delegate {  };
    public UnityAction onStageAreaEntered=delegate {  };
    public UnityAction<byte> onStageAreaSuccesfull=delegate  {  };
    public UnityAction onFinishAreaEntered=delegate {  };
    public UnityAction onMiniGameAreaEntered=delegate {  };
    public UnityAction<byte> onMiniGameAreaCompleted=delegate {  };
    


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

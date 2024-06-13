using UnityEngine;
using UnityEngine.Events;

public class CoreUISignals : MonoBehaviour
{
    public static CoreUISignals Instance { get; set; }



    public UnityAction<UIPanelTypes,int> onOpenPanel = delegate { };

    public UnityAction<int> onClosePanel = delegate { };
    public UnityAction onCloseAllPanel=delegate { };


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

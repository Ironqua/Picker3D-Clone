using System.Collections.Generic;
using UnityEngine;

public class UIPanelController : MonoBehaviour
{
   [SerializeField] private List<Transform> layers = new List<Transform>();


[SerializeField] UIPanelTypes panelType;
[SerializeField] int value;



    void OnEnable()
    {
        SubscribeEvents();
    }


    void OnDisable()
    {
        UnSubscribeEvents();
    }





    private void SubscribeEvents()
    {
        CoreUISignals.Instance.onOpenPanel += OnOpenPanel;
        CoreUISignals.Instance.onClosePanel += OnClosePanel;
        CoreUISignals.Instance.onCloseAllPanel += OnCloseAllPanel;
    }

    private void OnCloseAllPanel()
    {
        foreach (var layer in layers)
        {
            if(layer.childCount<=0) return;
        #if UNITY_EDITOR
        Destroy(layer.GetChild(0).gameObject);
        #else
        
        Destroy(layer.GetChild(0).gameObject);
        #endif
        }
    }

    private void OnClosePanel(int value)
    {
        if(layers[value].childCount<=0) return;
        #if UNITY_EDITOR
        Destroy(layers[value].GetChild(0).gameObject);
        #else
        
        Destroy(layers[value].GetChild(0).gameObject);
        #endif
    }

    private void OnOpenPanel(UIPanelTypes panelType, int value)
    {
        OnClosePanel(value);
Instantiate(Resources.Load<GameObject>($"Screens/{panelType}Panel"),layers[value]);

   
    }

    private void UnSubscribeEvents()
    {
        CoreUISignals.Instance.onOpenPanel -= OnOpenPanel;
        CoreUISignals.Instance.onClosePanel -= OnClosePanel;
        CoreUISignals.Instance.onCloseAllPanel -= OnCloseAllPanel;
    }   

}

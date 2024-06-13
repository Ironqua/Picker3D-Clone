using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIEventSubscriber : MonoBehaviour
{
    [SerializeField] private UIEventSubscriptionTypes type;
    [SerializeField] private Button button;
    private UIManager _manager;

    void Awake()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        _manager = FindObjectOfType<UIManager>();
    }

    void OnEnable()
    {
        SubscribeEvents();
    }

    void OnDisable()
    {
        UnsubscribeEvents();
    }

    void SubscribeEvents()
    {
        switch (type)
        {
            case UIEventSubscriptionTypes.Play:
                button.onClick.AddListener(_manager.Play); 
                break;
            case UIEventSubscriptionTypes.NextLevel:
                button.onClick.AddListener(_manager.NextLevel);
                break;
            case UIEventSubscriptionTypes.RestartLevel:
                button.onClick.AddListener(_manager.RestartLevel);
                break;
        }
    }

    void UnsubscribeEvents()
    {
        switch (type)
        {
            case UIEventSubscriptionTypes.Play:
                button.onClick.RemoveListener(_manager.Play);
                break;
            case UIEventSubscriptionTypes.NextLevel:
                button.onClick.RemoveListener(_manager.NextLevel);
                break;
            case UIEventSubscriptionTypes.RestartLevel:
                button.onClick.RemoveListener(_manager.RestartLevel);
                break;
        }
    }
}

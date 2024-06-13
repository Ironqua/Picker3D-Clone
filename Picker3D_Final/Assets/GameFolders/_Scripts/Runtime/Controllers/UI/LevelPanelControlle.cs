using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanelControlle : MonoBehaviour
{
 [SerializeField]  private List<Image> stageImages=new List<Image>();
   [SerializeField] private List<TextMeshProUGUI> levelTexts=new List<TextMeshProUGUI>();
   

   void OnEnable()
   {
    SubscribeEvents();
   }
   void OnDisable()
   {
    UnSubscribeEvents();
   }

   void SubscribeEvents()
   {
        UISignals.Instance.onSetLevelValue+=OnSetLevelValue;
        UISignals.Instance.onSetStageColor+=OnSetStageColor;

   }

    private void OnSetStageColor(byte stageValue)
    {
        stageImages[stageValue].DOColor(Color.yellow,0.5f);
    }

    private void OnSetLevelValue(byte levelValue)
    {
        var additionalValue=++levelValue;
        levelTexts[0].text=additionalValue.ToString();
        additionalValue++;
        levelTexts[1].text=additionalValue.ToString();



    }

    private void UnSubscribeEvents()
    {
        UISignals.Instance.onSetLevelValue-=OnSetLevelValue;
        UISignals.Instance.onSetStageColor-=OnSetStageColor;
    }
}

using Runtime.Keys;
using UnityEngine;
using UnityEngine.Events;

public class InputSignals : MonoBehaviour
{
public static InputSignals Instance{ get; set; }



public UnityAction onFirstTimeTouchTaken =delegate{};
public UnityAction onInputTaken=delegate{};
public UnityAction onInputReleased=delegate{};
public UnityAction<HorizontalInputParams> onInputDragged=delegate {};
public UnityAction onEnableInput=delegate{};  
public UnityAction onDisableInput=delegate{};




void Awake()
{
    Instance = this;
}






}

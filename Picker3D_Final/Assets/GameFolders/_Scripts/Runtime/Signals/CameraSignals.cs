using UnityEngine;
using UnityEngine.Events;


public class CameraSignals : MonoBehaviour
{
   public static CameraSignals Instance { get; set; }

public UnityAction onSetCameraTarget=delegate { };




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

using Cinemachine;
using Unity.Mathematics;
using UnityEngine;


    public class CameraManager : MonoBehaviour
    {
   

        [SerializeField] private CinemachineVirtualCamera virtualCamera;

      

        private float3 _firstPosition;

     

       

        private void Start()
        {
            Init();
            SubscribeEvents();
        }

        private void Init()
        {
            _firstPosition = transform.position;
        }

        private void OnEnable()
        {
           SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CameraSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void OnSetCameraTarget()
        {
           var player = FindObjectOfType<PlayerManager>().transform;
          virtualCamera.Follow = player;
            //virtualCamera.LookAt = player;
           
        
        }

        private void OnReset()
        {
            transform.position = _firstPosition;
        }

        private void UnSubscribeEvents()
        {
            CameraSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }

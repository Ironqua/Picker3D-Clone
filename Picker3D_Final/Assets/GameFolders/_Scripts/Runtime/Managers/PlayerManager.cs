
using System;
using DG.Tweening;
using Runtime.Keys;
using UnityEngine;


    public class PlayerManager : MonoBehaviour
    {
       

        public byte StageValue;

        internal ForceBallsToPoolCommand ForceCommand;

        

       

        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerMeshController meshController;
        [SerializeField] private PlayerPhysicsController physicsController;

    

        private PlayerData _data;
        private PlayerMovementData _movementData;
        private byte decraseRate;
        private byte _value;

      

        
        private void Awake()
        {
            _data = GetPlayerData();
            _movementData=GetMovementData();
            SendDataToControllers();
            Init();
        }
       

    private PlayerMovementData GetMovementData()
    {
        return Resources.Load<CD_Player>("Datas/CD_Player").PlayerData.movementData;
    }

    private PlayerData GetPlayerData()
        {
            return Resources.Load<CD_Player>("Datas/CD_Player").PlayerData;
        }
        

        private void SendDataToControllers()
        {
            movementController.SetData(_data.movementData);
            meshController.SetData(_data.meshData);
        }

        private void Init()
        {
            ForceCommand = new ForceBallsToPoolCommand(this, _data.forceData);
            
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputTaken += () => movementController.IsReadyToMove(true);
            InputSignals.Instance.onInputReleased += () => movementController.IsReadyToMove(false);
            InputSignals.Instance.onInputDragged += OnInputDragged;
            UISignals.Instance.onPlay += () => movementController.IsReadyToPlay(true);
            CoreGameSignals.Instance.onLevelSuccesful += () => movementController.IsReadyToPlay(false);
            CoreGameSignals.Instance.onLevelFailed += () => movementController.IsReadyToPlay(false);
            CoreGameSignals.Instance.onStageAreaEntered += () => movementController.IsReadyToPlay(false);
            CoreGameSignals.Instance.onMiniGameAreaCompleted += OnMiniGameAreaCompleted;
            CoreGameSignals.Instance.onStageAreaSuccesfull += OnStageAreaSuccessful;
            CoreGameSignals.Instance.onReset += OnReset;
        }

    private void OnMiniGameAreaCompleted(byte value)
    {
        
        DOTween.To(() => value, x => value =(byte) x, 0, 1.5f)
            .OnUpdate(() =>
            {
               _movementData.ForwardSpeed=25f;
               movementController.SetData(_movementData);
               Debug.Log($"{value}");
            })
            .OnComplete(() =>
            {
                CoreGameSignals.Instance.onLevelSuccesful?.Invoke();
                
            });
    }

    private void OnInputDragged(HorizontalInputParams inputParams)
        {
            movementController.UpdateInputParams(inputParams);
        }

        private void OnStageAreaSuccessful(byte value)
        {
            StageValue = ++value;
            movementController.IsReadyToPlay(true);
            meshController.ScaleUpPlayer();
           
        }

        private void OnFinishAreaEntered()
        {
            CoreGameSignals.Instance.onLevelSuccesful?.Invoke();
        }


        private void OnReset()
        {
            StageValue = 0;
            movementController.OnReset();
            physicsController.OnReset();
            meshController.OnReset();
        }

        private void UnSubscribeEvents()
        {
            InputSignals.Instance.onInputTaken -= () => movementController.IsReadyToMove(true);
            InputSignals.Instance.onInputReleased -= () => movementController.IsReadyToMove(false);
            InputSignals.Instance.onInputDragged -= OnInputDragged;
            UISignals.Instance.onPlay -= () => movementController.IsReadyToPlay(true);
            CoreGameSignals.Instance.onLevelSuccesful -= () => movementController.IsReadyToPlay(false);
            CoreGameSignals.Instance.onLevelFailed -= () => movementController.IsReadyToPlay(false);
            CoreGameSignals.Instance.onStageAreaEntered -= () => movementController.IsReadyToPlay(false);
            
            CoreGameSignals.Instance.onStageAreaSuccesfull -= OnStageAreaSuccessful;
            CoreGameSignals.Instance.onFinishAreaEntered -= OnFinishAreaEntered;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }


    }


using UnityEngine;


    public class UIManager : MonoBehaviour
    {
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize += OnLevelInitialize;
            CoreGameSignals.Instance.onLevelSuccesful += OnLevelSuccessful;
            CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onStageAreaSuccesfull += OnStageAreaSuccessful;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize -= OnLevelInitialize;
            CoreGameSignals.Instance.onLevelSuccesful -= OnLevelSuccessful;
            CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onStageAreaSuccesfull -= OnStageAreaSuccessful;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void OnLevelInitialize(byte levelValue)
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Level, 0);
            UISignals.Instance.onSetLevelValue?.Invoke(levelValue);
        }

        private void OnLevelSuccessful()
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Win, 2);
        }

        private void OnLevelFailed()
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Fail, 2);
        }

        public void NextLevel()
        {
            CoreGameSignals.Instance.onNextLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
        }

        public void RestartLevel()
        {
            CoreGameSignals.Instance.onRestartLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
        }

        public void Play()
        {
            UISignals.Instance.onPlay?.Invoke();
            CoreUISignals.Instance.onClosePanel?.Invoke(1);
            InputSignals.Instance.onEnableInput?.Invoke();
            CameraSignals.Instance.onSetCameraTarget?.Invoke();
        }

        private void OnStageAreaSuccessful(byte stageValue)
        {
            UISignals.Instance.onSetStageColor?.Invoke(stageValue);
        }

        private void OnReset()
        {
            CoreUISignals.Instance.onCloseAllPanel?.Invoke();
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 1);
        }
    }

using System;
using Architecture.StateMachine;
using Audio;
using DG.Tweening;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Pausing
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private Toggle musicToggle;
        [SerializeField] private Toggle fxToggle;
        
        private CanvasGroup canvasGroup;
    
        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            GameStateMachine.OnGameStateChanged += HandleGameStateChanged;
            canvasGroup.alpha = 0;
        }

        private void Start()
        {
            musicToggle.SetIsOnWithoutNotify(!AudioManager.Instance.musicMuted);
            fxToggle.SetIsOnWithoutNotify(!AudioManager.Instance.fxMuted);
        }

        private void OnDestroy() => GameStateMachine.OnGameStateChanged -= HandleGameStateChanged;

        private void HandleGameStateChanged(IState state)
        {
            Tweener tween = canvasGroup.DOFade(state is Pause || state is GameOver ? 1f : 0f, .5f);
            tween?.SetUpdate(true);
            
            titleText.SetText(ScoreManager.GoalReached ? "Goal Reached" : "Paused");
        }

        public void ToggleFX(bool toggle)
        {
            AudioManager.Instance.ToggleFx(fxToggle.isOn);
        }
        public void ToggleMusic(bool toggle)
        {
            AudioManager.Instance.ToggleMusic(musicToggle.isOn);
        }
    }
}

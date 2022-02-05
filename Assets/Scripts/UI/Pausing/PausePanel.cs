using Architecture.StateMachine;
using DG.Tweening;
using Managers;
using TMPro;
using UnityEngine;

namespace UI.Pausing
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text titleText;
        
        private CanvasGroup canvasGroup;
    
        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            GameStateMachine.OnGameStateChanged += HandleGameStateChanged;
            canvasGroup.alpha = 0;
        }

        private void OnDestroy() => GameStateMachine.OnGameStateChanged -= HandleGameStateChanged;

        private void HandleGameStateChanged(IState state)
        {
            Tweener tween = canvasGroup.DOFade(state is Pause || state is GameOver ? 1f : 0f, .5f);
            tween?.SetUpdate(true);
            
            titleText.SetText(ScoreManager.GoalReached ? "Goal Reached" : "Paused");
        }
    }
}

using System;
using Architecture.Persistence;
using Architecture.StateMachine;
using Architecture.Variables;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private static  bool _goalReached = false;
        
        [Header("Setup")] 
        [SerializeField] private FloatVariable goldScoreTime;
        [SerializeField] private FloatVariable silverScoreTime;
        [SerializeField] private FloatVariable bronzeScoreTime;

        [Header("Variables")] 
        [SerializeField] private FloatVariable levelTime;

        private int powerUpsCollected = 0;
        private MedalType medalType = MedalType.None;
        
        public static event Action BronzeTimePassed;
        public static event Action SilverTimePassed;
        public static event Action GoldTimePassed;
    
        private void Awake()
        {
            ResetTime();
            GameStateMachine.OnGameStateChanged += GameStateMachineOnGameStateChanged;
        }
        private void OnDestroy() => GameStateMachine.OnGameStateChanged -= GameStateMachineOnGameStateChanged;

        private void Update()
        {
            levelTime.Value += Time.deltaTime;

            //TODO: Make This better to not keep invoking
            if (levelTime.Value > bronzeScoreTime.Value)
            {
                BronzeTimePassed?.Invoke();
                medalType = MedalType.Bronze;
            }

            if (levelTime.Value > silverScoreTime.Value)
            {
                SilverTimePassed?.Invoke();
                medalType = MedalType.Silver;
            }

            if (levelTime.Value > goldScoreTime.Value)
            {
                GoldTimePassed?.Invoke();
                medalType = MedalType.Gold;
            }
        }

        public static bool OnGoalReached() => _goalReached;

        private void GameStateMachineOnGameStateChanged(IState state)
        {
            if (state is GameOver)
            {
                GamePersistence.Instance.SetTimeTrialScores(levelTime.Value,powerUpsCollected, medalType);
            }
        }

        private void ResetTime()
        {
            levelTime.Value = 0;
            _goalReached = false;
        }
    }
}
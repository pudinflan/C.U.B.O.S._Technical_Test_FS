using System;
using Architecture.Persistence;
using Architecture.StateMachine;
using Architecture.Variables;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public static  bool GoalReached { get; private set; }
        
        [Header("Setup")] 
        [SerializeField] private FloatVariable goldScoreTime;
        [SerializeField] private FloatVariable silverScoreTime;
        [SerializeField] private FloatVariable bronzeScoreTime;

        [Header("Variables")] 
        [SerializeField] private FloatVariable levelTime;

        private GamePersistence gamePersistence;
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

        private void Start() => gamePersistence = FindObjectOfType<GamePersistence>();

        private void OnDestroy() => GameStateMachine.OnGameStateChanged -= GameStateMachineOnGameStateChanged;

        private void Update()
        {
            levelTime.Value += Time.deltaTime;

            //TODO: Make This better to not keep invoking
            if (levelTime.Value > bronzeScoreTime.Value)
            {
                BronzeTimePassed?.Invoke();
            }

            if (levelTime.Value > silverScoreTime.Value)
            {
                SilverTimePassed?.Invoke();
            }

            if (levelTime.Value > goldScoreTime.Value)
            {
                GoldTimePassed?.Invoke();
            }
        }

        public void VictoryCondition()
        {
            GoalReached = true;
        }

        private void GameStateMachineOnGameStateChanged(IState state)
        {
            if (state is GameOver)
            {
                if (levelTime.Value < goldScoreTime.Value) 
                    medalType = MedalType.Gold;
                else if (levelTime.Value < silverScoreTime.Value)
                    medalType = MedalType.Silver;
                else if (levelTime.Value < bronzeScoreTime.Value)
                    medalType = MedalType.Bronze;

                gamePersistence.SetTimeTrialScores(levelTime.Value,powerUpsCollected, medalType);
            }
        }

        private void ResetTime()
        {
            levelTime.Value = 0;
            GoalReached = false;
        }
    }
}
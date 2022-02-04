using System;
using UnityEngine;

namespace Architecture.Persistence
{
    public class GamePersistence : MonoBehaviour
    {
        public static GamePersistence Instance;
        
        private static bool _initialized;
        
        public GameData _gameData;

        public static Action<GameData> OnGameDataLoaded;

        private void Awake()
        {
            if (_initialized)
            {
                Destroy(gameObject);
                return;
            }
            _initialized = true;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        void Start() => LoadGame();

        private void OnDisable() => SaveGame();
        
        public void SaveGame()
        {
            var json = JsonUtility.ToJson(_gameData);
            PlayerPrefs.SetString("GameData", json);
            Debug.Log(json);
            Debug.Log("Save data complete");
        }

        private void LoadGame()
        {
            var json = PlayerPrefs.GetString("GameData"); 
            _gameData = JsonUtility.FromJson<GameData>(json) ?? new GameData();

            //do Something with data like binding if needed
            OnGameDataLoaded?.Invoke(_gameData);
        }
        
        /// <summary>
        /// Saves Set Trial Scores if conditions are met
        /// </summary>
        /// <param name="levelTimeValue">How long we took to pass the level</param>
        /// <param name="powerUpsCollected">How many power ups were collected</param>
        /// <param name="medalType">The medal that was awarded</param>
        public void SetTimeTrialScores(float levelTimeValue, int powerUpsCollected, MedalType medalType)
        {
            //increment PowerUps collected on Game Data
            _gameData.TimeTrialData.PowerUpsCollected += powerUpsCollected;

            //Set Best time if new levelTimeValues is lower
            if (_gameData.TimeTrialData.BestTime > levelTimeValue )
                _gameData.TimeTrialData.BestTime = levelTimeValue;

            //Set Best Medal Reached if new medal is Higher
            if (_gameData.TimeTrialData.BestMedalReached < medalType)
                _gameData.TimeTrialData.BestMedalReached = medalType;
            
            SaveGame();
        }
    }
}
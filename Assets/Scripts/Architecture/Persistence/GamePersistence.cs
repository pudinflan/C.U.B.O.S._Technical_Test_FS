using System;
using UnityEngine;

namespace Architecture.Persistence
{
    public class GamePersistence : MonoBehaviour
    {
        public GameData gameData;

        public static Action<GameData> OnGameDataLoaded;

        private void Start() => LoadGame();

        public void SaveGame()
        {
            var json = JsonUtility.ToJson(gameData);
            PlayerPrefs.SetString("GameData", json);
            Debug.Log(json);
            Debug.Log("Save data complete");
        }

        private void LoadGame()
        {
            var json = PlayerPrefs.GetString("GameData"); 
            gameData = JsonUtility.FromJson<GameData>(json);
            
            if (gameData == null) 
                gameData = new GameData (float.MaxValue,0,0,MedalType.None);

            //do Something with data like binding if needed
            OnGameDataLoaded?.Invoke(gameData);
            Debug.Log("Load data complete");
        }
        
        /// <summary>
        /// Saves Set Trial Scores if conditions are met
        /// </summary>
        /// <param name="levelTimeValue">How long we took to pass the level</param>
        /// <param name="powerUpsCollected">How many power ups were collected</param>
        /// <param name="medalType">The medal that was awarded</param>
        public void SetTimeTrialScores(float levelTimeValue, int powerUpsCollected, MedalType medalType)
        {
            gameData.TimesPlayed++;
            
            //increment PowerUps collected on Game Data
            gameData.PowerUpsCollected += powerUpsCollected;

            //Set Best time if new levelTimeValues is lower
            if (gameData.BestTime > levelTimeValue )
                gameData.BestTime = levelTimeValue;

            //Set Best Medal Reached if new medal is Higher
            if (gameData.BestMedalReached < medalType)
                gameData.BestMedalReached = medalType;
            
            SaveGame();
        }
    }
}
using System;
using UnityEngine;

namespace Architecture.Persistence
{
    public class GamePersistence : MonoBehaviour
    {
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
    }
}
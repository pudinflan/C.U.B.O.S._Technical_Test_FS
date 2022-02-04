using System;
using Architecture.Persistence;
using TMPro;
using UnityEngine;
using Utils;

namespace UI.Menu
{
    public class TimeTrialDataDisplay : MonoBehaviour
    {
        public TMP_Text bestTimeValueText;
        public TMP_Text bestMedalValueText;
        public TMP_Text timesPlayedValueText;
        public TMP_Text powerUpsCollectedValueText;

        private void Awake() => GamePersistence.OnGameDataLoaded += OnGameDataLoaded;

        private void OnDestroy() => GamePersistence.OnGameDataLoaded -= OnGameDataLoaded;

        private void OnGameDataLoaded(GameData gameData)
        {
            var bestMedal = gameData.BestMedalReached;
            var timesPlayedData = gameData.TimesPlayed;
            var powerUpsCollectedData = gameData.PowerUpsCollected;
            var timeData = gameData.BestTime;
            
            bestTimeValueText.SetText(timesPlayedData > 0 ? StringFormatHelper.FormatTime(timeData) : "--:--:--");
            timesPlayedValueText.SetText(timesPlayedData.ToString());
            powerUpsCollectedValueText.SetText(powerUpsCollectedData.ToString());
            bestMedalValueText.SetText(bestMedal.ToString());
        }
    }
}

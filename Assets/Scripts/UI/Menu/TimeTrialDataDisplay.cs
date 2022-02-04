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
            var timeData = gameData.TimeTrialData.BestTime;
            var bestMedal = gameData.TimeTrialData.BestMedalReached;
            var timesPlayedData = gameData.TimeTrialData.TimesPlayed;
            var powerUpsCollectedData = gameData.TimeTrialData.PowerUpsCollected;
            
            bestTimeValueText.SetText(StringFormatHelper.FormatTime(timeData));
            timesPlayedValueText.SetText(timesPlayedData.ToString());
            powerUpsCollectedValueText.SetText(powerUpsCollectedData.ToString());
            bestMedalValueText.SetText(bestMedal.ToString());
        }
    }
}

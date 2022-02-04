using System.Threading.Tasks;
using Architecture.Variables;
using Interactables.PowerUps;
using TMPro;
using UnityEngine;
using Utils;

namespace UI.Scoring
{
    /// <summary>
    /// Displays time on UI
    /// </summary>
    public class DisplayTime : MonoBehaviour
    {
        [SerializeField] private FloatVariable levelTime;
        [SerializeField] private TMP_Text levelTimeText;
        [SerializeField] private TMP_Text subtractTimePowerUpText;

        private void Awake() => SubtractTimePowerUp.OnLevelTimeReduced += SubtractTimePowerUpOnLevelTimeReduced;

        private void OnDisable() => SubtractTimePowerUp.OnLevelTimeReduced -= SubtractTimePowerUpOnLevelTimeReduced;

        private void FixedUpdate()
        {
            levelTimeText.SetText(StringFormatHelper.FormatTime(levelTime.Value));
        }

        private void SubtractTimePowerUpOnLevelTimeReduced(float timeReduced)
        {
            subtractTimePowerUpText.SetText("-" + StringFormatHelper.FormatTime(timeReduced));
            RemoveTime();
        }

        private async Task RemoveTime()
        {
            var end = Time.time + 3;
            while (Time.time < end)
                await Task.Yield();

            subtractTimePowerUpText.SetText("");
        }
    }
}
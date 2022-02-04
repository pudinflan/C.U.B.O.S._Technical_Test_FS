using System.Collections;
using Interactables.PowerUps;
using TMPro;
using UnityEngine;
using Utils;

namespace UI.Scoring
{
    public class DisplayPowerUpTime : MonoBehaviour
    {
        [SerializeField] private TMP_Text powerUpTimerText;

        private void Awake() => TimedPowerUp.OnPowerUpUsed += StartCount;
        private void OnDisable() => TimedPowerUp.OnPowerUpUsed -= StartCount;
        private  void StartCount(float duration) => StartCoroutine(CountTime(duration)) ;

        /// <summary>
        /// Counts Time and displays on Ui
        /// </summary>
        /// <param name="duration"></param>
        private IEnumerator  CountTime(float duration)
        {
            const float step = .1f;
            var end = Time.time + duration;
        
            while (Time.time < end)
            {
                powerUpTimerText.SetText(StringFormatHelper.FormatTime(duration));
                duration -= step;
            
                yield return new WaitForSeconds(step);
            }
            powerUpTimerText.SetText("");
        }
    }
}

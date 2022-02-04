using Architecture.Variables;
using DG.Tweening;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Scoring
{
    public class DisplayScoreCubes : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] private Image bronzeImage;
        [SerializeField] private Image silverImage;
        [SerializeField] private Image goldImage;

        [SerializeField] private TMP_Text bronzeText;
        [SerializeField] private TMP_Text silverText;
        [SerializeField] private TMP_Text goldText;

        [Header("Variables")]
        [SerializeField] private FloatVariable bronzeScoreTime;
        [SerializeField] private FloatVariable silverScoreTime;
        [SerializeField] private FloatVariable goldScoreTime;
    
        private void Awake()
        {
            ScoreManager.BronzeTimePassed += ScoreManagerOnBronzeTimePassed;
            ScoreManager.SilverTimePassed += ScoreManagerOnSilverTimePassed;
            ScoreManager.GoldTimePassed += ScoreManagerOnGoldTimePassed;

            SetupTimesOnUI();
        }
    
        private void OnDisable()
        {
            ScoreManager.BronzeTimePassed -= ScoreManagerOnBronzeTimePassed;
            ScoreManager.SilverTimePassed -= ScoreManagerOnSilverTimePassed;
            ScoreManager.GoldTimePassed -= ScoreManagerOnGoldTimePassed;
        }
    
        private void SetupTimesOnUI()
        {
            bronzeText.SetText(StringFormatHelper.FormatTime(bronzeScoreTime.Value,false));
            silverText.SetText(StringFormatHelper.FormatTime(silverScoreTime.Value, false));
            goldText.SetText(StringFormatHelper.FormatTime(goldScoreTime.Value, false));
        }

        private void ScoreManagerOnBronzeTimePassed()
        {
            bronzeImage.DOFade(0.3f, 1f);
            bronzeText.DOFade(0.3f, 1f);
        }

        private void ScoreManagerOnSilverTimePassed()
        {
            silverImage.DOFade(0.3f, 1f);
            silverText.DOFade(0.3f, 1f);
        }

        private void ScoreManagerOnGoldTimePassed()
        {
            goldImage.DOFade(0.3f, 1f);
            goldText.DOFade(0.3f, 1f);
        }
    }
}
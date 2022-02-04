using Architecture.Variables;
using TMPro;
using UnityEngine;
using Utils;

/// <summary>
/// Displays time on UI
/// </summary>
public class DisplayTime : MonoBehaviour
{
    [SerializeField] private FloatVariable levelTime;
    [SerializeField] private TMP_Text levelTimeText;

    private void FixedUpdate()
    {
        levelTimeText.SetText(StringFormatHelper.FormatTime(levelTime.Value));
    }
}

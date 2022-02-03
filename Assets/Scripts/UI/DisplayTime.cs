using Architecture.Variables;
using TMPro;
using UnityEngine;

/// <summary>
/// Displays time on UI
/// </summary>
public class DisplayTime : MonoBehaviour
{
    [SerializeField] private FloatVariable levelTime;
    [SerializeField] private TMP_Text levelTimeText;

    private void FixedUpdate()
    {
        levelTimeText.SetText(FormatTime(levelTime.Value));
    }

    //Code by  Hellium
    //http://answers.unity.com/answers/1476304/view.html
    private string FormatTime( float time )
    {
        int minutes = (int) time / 60 ;
        int seconds = (int) time - 60 * minutes;
        int milliseconds = (int) (100 * (time - minutes * 60 - seconds));
        return $"{minutes:00}:{seconds:00}:{milliseconds:00}";
    }
}

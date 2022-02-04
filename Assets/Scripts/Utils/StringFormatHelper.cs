namespace Utils
{
    public class StringFormatHelper
    {
        ///  <summary>
        ///  Formats time by 00:00:00
        ///  Original Code by  Hellium
        /// http://answers.unity.com/answers/1476304/view.html
        /// Edited by Fernando M. Soares
        ///  </summary>
        ///  <param name="time">time as float</param>
        ///  <param name="showMiliseconds">will it show the milliseconds?</param>
        ///  <returns>A time string as 00:00:00</returns>
        public static string FormatTime(float time, bool showMiliseconds = true)
        {
            int minutes = (int)time / 60;
            int seconds = (int)time - 60 * minutes;
            int milliseconds = (int)(100 * (time - minutes * 60 - seconds));

            return showMiliseconds ? $"{minutes:00}:{seconds:00}:{milliseconds:00}" : $"{minutes:00}:{seconds:00}";
        }
    }
}
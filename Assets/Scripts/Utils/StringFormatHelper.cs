namespace Utils
{
    public class StringFormatHelper
    {
        /// <summary>
        /// Formats time by 00:00:00
        /// Code by  Hellium
        ///http://answers.unity.com/answers/1476304/view.html
        /// </summary>
        /// <param name="time">time as float</param>
        /// <returns>A time string as 00:00:00</returns>
        public static string FormatTime( float time )
        {
            int minutes = (int) time / 60 ;
            int seconds = (int) time - 60 * minutes;
            int milliseconds = (int) (100 * (time - minutes * 60 - seconds));
            return $"{minutes:00}:{seconds:00}:{milliseconds:00}";
        }
    }
}
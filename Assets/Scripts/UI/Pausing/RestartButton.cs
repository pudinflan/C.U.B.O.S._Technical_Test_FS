using UnityEngine.UI;

namespace UI.Pausing
{
    public class RestartButton : Button
    {
        public static bool Pressed => _instance != null && _instance.IsPressed();
        
        private static RestartButton _instance;
        
        protected override void OnEnable()
        {
            _instance = this;
            base.OnEnable();
        }
    }
}

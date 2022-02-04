using UnityEngine.UI;

namespace UI.Buttons
{
    public class MenuButton : Button
    {
        public static bool Pressed => _instance != null && _instance.IsPressed();
        
        private static MenuButton _instance;
        
        protected override void OnEnable()
        {
            _instance = this;
            base.OnEnable();
        }
        
    }
}
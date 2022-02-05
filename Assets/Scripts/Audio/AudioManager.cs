using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        private static bool _initialized;
        
        [SerializeField] private audiomi
        
        void Awake()
        {
            if (_initialized)
            {
                Destroy(gameObject);
                return;
            }
            _initialized = true;
            DontDestroyOnLoad(gameObject);
        }

    }
}

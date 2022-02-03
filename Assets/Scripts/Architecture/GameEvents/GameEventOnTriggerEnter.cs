using UnityEngine;

namespace Architecture.GameEvents
{
    public class GameEventOnTriggerEnter : MonoBehaviour
    {
        [SerializeField] private string triggerTag = "Player";
        [SerializeField] private GameEvent triggerEvent;
        [SerializeField] private bool triggerOnlyOnce = true;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(triggerTag))
            {
                triggerEvent?.Invoke();
                
                if (triggerOnlyOnce) 
                    Destroy(this);
            }
        }
    }
}

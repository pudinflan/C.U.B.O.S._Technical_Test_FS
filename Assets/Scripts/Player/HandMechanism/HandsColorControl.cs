using UnityEngine;

namespace Player.HandMechanism
{
    public class HandsColorControl : MonoBehaviour
    {
        private static readonly int ColorProperty = Shader.PropertyToID("_Glow_Color");

        [SerializeField] 
        [Tooltip("The Material to base to be instanced and shared by the renderers")] 
        private Material baseGlowMaterial;
    
        [SerializeField] 
        [Tooltip("Assign the MeshRenderer of the various batteryObjects ")] 
        private MeshRenderer[] batteryRenderers;

        private Material materialInstance;

        private void Awake()
        {
            CreateMaterialInstanceAndAssignToBatteryRenderers();
        }

        /// <summary>
        /// Creates a single Material instance and assigns them to multiple renderers
        /// Changing the color on the instance will change the color of all batteries
        /// </summary>
        private void CreateMaterialInstanceAndAssignToBatteryRenderers()
        {
            materialInstance = Instantiate(baseGlowMaterial);

            foreach (var batteryRenderer in batteryRenderers)
            {
                batteryRenderer.material = materialInstance;
            }
        }

        /// <summary>
        /// Sets the Glow color of the Battery_glow material instance
        /// </summary>
        /// <param name="color"></param>
        public void SetGlowColor(Color color)
        {
            materialInstance.SetColor(ColorProperty, color);
        }
    }
}
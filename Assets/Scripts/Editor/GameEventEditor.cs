using Architecture.GameEvents;
using UnityEditor;
using UnityEngine;

namespace Editor
{
   [CustomEditor(typeof(GameEvent))]
   public class GameEventEditor : UnityEditor.Editor
   {
      private GameEvent gameEvent;
      private void OnEnable() => gameEvent = (GameEvent) target;
   
      public override void OnInspectorGUI()
      {      base.OnInspectorGUI();
      
         GUILayout.Label("DEBUG");
         //Draws Button On GameEvent scriptable objects to do a Debug On Demand Invoke
         if (GUILayout.Button("Invoke")) 
            gameEvent?.Invoke();
      
      }
   }
}

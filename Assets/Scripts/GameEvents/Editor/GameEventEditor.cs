using GameEvents;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
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

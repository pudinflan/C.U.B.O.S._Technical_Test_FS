using System;
using Architecture.Variables;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   [SerializeField] private FloatVariable levelTime;

   private void Awake()
   {
      ResetTime();
   }

   private void Update()
   {
      levelTime.Value += Time.deltaTime;
   }

   private void ResetTime()
   {
      levelTime.Value = 0;
   }
}

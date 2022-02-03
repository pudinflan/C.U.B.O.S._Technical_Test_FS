using System;
using UnityEngine;

namespace Architecture.Variables
{
  public class Variable<T> : ScriptableObject
  {
    [SerializeField] private T defaultValue;
    [NonSerialized] public T Value;
    
    private void OnValidate() => Value = defaultValue;
  }
}

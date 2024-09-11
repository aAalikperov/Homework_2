using System;
using UnityEngine;

[Serializable]
public class FastRunningStateConfig
{
    [field: SerializeField, Range( 0, 20 )] public float Speed { get; private set; }

    [field: SerializeField, Range( 0, 2 )] public float StaminaConsumPerSec { get; private set; }

}

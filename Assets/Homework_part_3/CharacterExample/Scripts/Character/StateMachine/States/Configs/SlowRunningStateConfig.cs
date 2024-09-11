using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SlowRunningStateConfig
{
    [field: SerializeField, Range( 0, 5 )] public float Speed { get; private set; }
}

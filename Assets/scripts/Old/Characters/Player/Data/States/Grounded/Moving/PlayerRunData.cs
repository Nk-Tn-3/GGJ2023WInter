using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovementNS
{
    [System.Serializable]
    public class PlayerRunData
    {
        [field: SerializeField] public float SpeedModifier { get; private set; } = 1f;
    }
}

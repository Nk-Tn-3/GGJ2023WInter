using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovementNS
{

    [System.Serializable]
    public class PlayerSprintData 
    {
        [field: SerializeField] [field: Range(1f, 5f)] public float SpeedModifier { get; private set; } = 1.7f;
        [field: SerializeField] [field: Range(0f, 10f)] public float SprintToRunTime { get; private set; } = 1f;
        [field: SerializeField] [field: Range(0f, 3f)] public float RunToWalkTime { get; private set; } = 0.5f;
    }
}

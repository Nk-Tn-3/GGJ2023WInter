
using UnityEngine;

namespace PlayerMovementNS
{
    [System.Serializable]
    public class PlayerJumpData 
    {
    [field:SerializeField] public Vector3 StationaryForce { get; private set; }
        [field: SerializeField] public Vector3 WeakForce { get; private set; }
        [field: SerializeField] [field: Range(0, 10f)] public float JumpToGroundDistance { get; private set; } = 2f;
       [field:SerializeField] public AnimationCurve JumpForceModifierUpwardSlope { get; private set; }
        [field: SerializeField] public AnimationCurve JumpForceModifierDownwardSlope { get; private set; }
        [field: SerializeField] public Vector3 MediumForce { get; private set; }

        [field: SerializeField] public Vector3 StrongForce { get; private set; }
        [field: SerializeField] public PlayerRotationData RotationData { get; private set; }
        [field: SerializeField] [field: Range(0f, 10f)] public float DecelerationForce { get; private set; } = 1.5f;
    
    }
}
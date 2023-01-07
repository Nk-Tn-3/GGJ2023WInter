
using UnityEngine;

namespace PlayerMovementNS
{
    [System.Serializable]
    public class PlayerGroundedData
    {
        [field: SerializeField] public float BaseSpeed { get; private set; }

        [field: SerializeField] [field: Range(0f,10f)] public float GroundToFallRayDistance { get; private set; } = 1.5f;

        [field: SerializeField] public AnimationCurve SlopeAngles { get; private set; }
        [field: SerializeField] public PlayerRotationData BaseRotationData { get; private set; }
        [field: SerializeField] public PlayerWalkData WalkData { get; private set; }
        [field: SerializeField] public PlayerRunData RunData { get; private set; }
        [field: SerializeField] public PlayerSprintData SprintData { get; private set; }

        [field: SerializeField] public PlayerDashData DashData { get; private set; }
        [field: SerializeField] public PlayerStoppingData StopData { get; private set; }

        [field: SerializeField] public PlayerRestrictionData RestrictionData { get; private set;}
    }
}

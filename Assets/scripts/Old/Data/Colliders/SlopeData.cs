
using UnityEngine;

namespace PlayerMovementNS
{
    [System.Serializable]
    public class SlopeData
    {
        [field:SerializeField] [field:Range(0,1f)]public float StepHeightPercentage { get; private set; }
        [field: SerializeField] [field: Range(0, 5f)] public float RayDistance { get; private set; } = 2.5f;
        [field: SerializeField] [field: Range(0, 50f)] public float StepReachForce { get; private set; } = 25f;
    }
}

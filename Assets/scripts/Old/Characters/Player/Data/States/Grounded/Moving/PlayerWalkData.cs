
using UnityEngine;

namespace PlayerMovementNS
{
    [System.Serializable]
    public class PlayerWalkData
    {
        [field: SerializeField] public float SpeedModifier { get; private set; } = 0.25f;
    }
}


using UnityEngine;

namespace PlayerMovementNS
{
    [System.Serializable]
    public class PlayerFallData 
    {
        [field: SerializeField] [field: Range(1f, 25f)] public float FallSpeedLimit { get; private set; } = 15f;
    }
}

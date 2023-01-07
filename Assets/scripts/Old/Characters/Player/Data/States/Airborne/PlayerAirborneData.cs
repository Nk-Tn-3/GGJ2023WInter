
using UnityEngine;

namespace PlayerMovementNS
{
    [System.Serializable]
    public class PlayerAirborneData 
    {
        [field: SerializeField] public PlayerJumpData JumpData;
        [field: SerializeField] public PlayerFallData FallData;
    }
}

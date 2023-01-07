
using UnityEngine;

namespace PlayerMovementNS
{
    [System.Serializable]
    public class PlayerCapsuleColliderUtility : CapsuleColliderUtility
    {
        [field:SerializeField] public PlayerTriggerColliderData triggerColliderData { get; private set; }
    }
}

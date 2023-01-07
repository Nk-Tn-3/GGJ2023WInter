
using UnityEngine;

namespace PlayerMovementNS
{
    [System.Serializable]
    public class PlayerTriggerColliderData 
    {
        [field:SerializeField] public BoxCollider GroundCheckCollider { get; private set; }
    }
}

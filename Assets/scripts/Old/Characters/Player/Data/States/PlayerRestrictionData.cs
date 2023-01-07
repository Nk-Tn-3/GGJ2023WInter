using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovementNS
{
    [System.Serializable]
    public class PlayerRestrictionData 
    {
        [field:SerializeField] public bool CanJump { get; private set; }
        [field: SerializeField] public bool CanDash { get; private set; }
    }
}

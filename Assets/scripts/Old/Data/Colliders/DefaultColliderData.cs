using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovementNS
{
    [System.Serializable]
    public class DefaultColliderData 
    {
      [field:SerializeField] public float Height { get; private set; }
        [field: SerializeField] public float CenterY { get; private set; }
        [field: SerializeField] public float Radius { get; private set; }
    }
}

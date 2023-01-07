
using UnityEngine;

namespace PlayerNS
{

   [CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
    public class PlayerSO: ScriptableObject
    {
        [field:SerializeField] public PlayerMovementNS.PlayerGroundedData GroundedData { get; private set; }
        [field: SerializeField] public PlayerMovementNS.PlayerAirborneData AirborneData { get; private set; }


        [field: SerializeField] public PlayerStats stats;
    }
}

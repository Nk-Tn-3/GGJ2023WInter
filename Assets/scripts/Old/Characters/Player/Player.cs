
using UnityEngine;
using PlayerMovementNS;
namespace PlayerNS
{

    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    
    public class Player : MonoBehaviour
    {
        [Header("References")]
        
         public PlayerSO playerData;

        
        
        [field:Header("Collisions")]
        [field: SerializeField] public PlayerCapsuleColliderUtility ColliderUtility { get; private set; }
        [field:SerializeField] public PlayerLayerData LayerData { get; private set; }
        public Rigidbody Rigidbody { get; private set; }

        public Transform MainCameraTransform { get; private set; }



        private PlayerMovementStateMachine movementStateMachine;
        public PlayerInput input { get; private set; }

        

        //Stats
        public PlayerStats Stats { get; private set; }

        private void Awake()

        {
            Rigidbody = GetComponent<Rigidbody>();
            input = GetComponent<PlayerInput>();

            //Collision
            ColliderUtility.Initialize(gameObject);
            ColliderUtility.CalculateCapsuleColliderDimensions();
            
            
            
           
            MainCameraTransform = Camera.main.transform;
            
            movementStateMachine = new PlayerMovementStateMachine(this);

        }
        public void OnValidate()
        {
            //Collision
            ColliderUtility.Initialize(gameObject);
            ColliderUtility.CalculateCapsuleColliderDimensions();
        }
        private void Start()
        {
           
            
            movementStateMachine.ChangeState(movementStateMachine.idlingState);
        }

        public void OnTriggerEnter(Collider collider)
        {
            movementStateMachine.OnTriggerEnter(collider);
        }
        public void OnTriggerExit(Collider collider)
        {
            movementStateMachine.OnTriggerExit(collider);   
        }
        private void Update()
        {
            movementStateMachine.HandleInput();
            movementStateMachine.Update();
        }
        private void FixedUpdate()
        {
            movementStateMachine.PhysicsUpdate();

        }
    }
}

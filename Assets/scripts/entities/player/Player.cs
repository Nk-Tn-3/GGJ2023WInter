using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public PlayerMovementNS.PlayerInput input { get; private set; }
    [SerializeField]private Animator animator;
    [SerializeField] private SphereCollider pickUpCollider;
    private AnimationController playerAnimationController;


    private Vector2 movementData;
    

    // Start is called before the first frame update
    void Awake()
    {
        input = GetComponent<PlayerMovementNS.PlayerInput>();
        playerAnimationController = new AnimationController();
        playerAnimationController.Initizalize(animator); 
        pickUpCollider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        
    }



    void HandleInput()
    {
  
            ReadMovementInput();

      
    }


    void ReadMovementInput()
    {
        movementData = input.GetMovement();
        bool pick = input.GetPickTrigger();
        playerAnimationController.Update(movementData,pick);
        
    }

    public void AnimationExitEvent()
    {
        playerAnimationController.PickUpEnd();
        pickUpCollider.gameObject.SetActive(false);

    }
    public void AnimationEnterEvent() {
        playerAnimationController.PickUpStart();

    }

    public void PikcUpColliderEnterEvent()
    {
        pickUpCollider.gameObject.SetActive(true);
    }

    public void PickUp()
    {
        pickUpCollider.gameObject.SetActive(false);
    }

    
}

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
    [field:SerializeField]private PlayerMovement movement;
    [SerializeField] private float playerSpeed=5f;
    private float currSpeed = 5f;
    public Rigidbody Rigidbody { get; private set; }
    private Vector2 movementData;
    private bool pick;
    

    // Start is called before the first frame update
    void Awake()
    {
        input = GetComponent<PlayerMovementNS.PlayerInput>();
        Rigidbody = GetComponent<Rigidbody>();
        playerAnimationController = new AnimationController();
        playerAnimationController.Initizalize(animator); 
        pickUpCollider.gameObject.SetActive(false);
        movement = new PlayerMovement(this);
        movement.Initialize();
        currSpeed = playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        movement.CallFixedUpdate();
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
        
        //not in use from trying to merge
        /*if(pick)
            pick = false;*/
    }

    public void AnimationExitEvent()
    {
        playerAnimationController.PickUpEnd();
        pickUpCollider.gameObject.SetActive(false);
        currSpeed = playerSpeed;

    }
    public void AnimationEnterEvent() {
        playerAnimationController.PickUpStart();
        currSpeed = 0;

    }

    public void PikcUpColliderEnterEvent()
    {
        pickUpCollider.gameObject.SetActive(true);
    }

    public void PickUp()
    {
        pickUpCollider.gameObject.SetActive(false);
    }

    public float GetPlayeSpeed()
    {
        return currSpeed;
    }

    /*public void UpdateDirection(Vector2 dir)
    {
        movementData = dir;
    }

    public void UpdateInteract()
    {
        pick = true;
    }*/
}

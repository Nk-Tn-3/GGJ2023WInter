using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    
    [SerializeField]private Animator animator;
    [SerializeField] private SphereCollider pickUpCollider;
    private AnimationController playerAnimationController;
    public PlayerMovement movement;
    [SerializeField] private float playerSpeed=5f;
    private float currSpeed = 5f;
    public Rigidbody Rigidbody { get; private set; }
    private Vector2 movementData;
    private bool pick;
    public Vector3 currentRotation;
    [SerializeField] Transform rightHand;
    [SerializeField] Vector3 ItemPositionInHand;
    [SerializeField] CharacterColor playerColors;
    PlayerColor color;
    

    public bool hasItemPickedUp;

    private GameObject itemInHand;
    

    // Start is called before the first frame update
    void Awake()
    {
        
        Rigidbody = GetComponent<Rigidbody>();
        playerAnimationController = new AnimationController();
        playerAnimationController.Initizalize(animator); 
        pickUpCollider.gameObject.SetActive(false);
        movement = new PlayerMovement(this);
      
        movement.Initialize();
        
      

        currSpeed = playerSpeed;
    }
    private void Start()
    {
        if (playerColors != null)
        {
            color = new PlayerColor(this, playerColors);
            color.Initialize();
        }
        ReadMovementInput(Vector2.zero);
    }
    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        movement.Movement(movementData);
    }



    void HandleInput()
    {
  
           

      
    }


    public void ReadMovementInput(Vector2 moveDir)
    {
        movementData = moveDir;
        playerAnimationController.Update(movementData);
     
    }
    public void ReadInteract()
    {

        playerAnimationController.Update(true,hasItemPickedUp);
    }
    public void AnimationExitEvent()
    {
        playerAnimationController.PickUpEnd();
        pickUpCollider.gameObject.SetActive(false);
        currSpeed = playerSpeed;
        playerAnimationController.Update(false,hasItemPickedUp);
    }
    public void AnimationEnterEvent() {
        playerAnimationController.PickUpStart();
        currSpeed = 0;

    }

    public void PikcUpColliderEnterEvent()
    {
        pickUpCollider.gameObject.SetActive(true);
    }

    public void PickUp(GameObject obj)
    {
        pickUpCollider.gameObject.SetActive(false);

        obj.GetComponent<PickUpable>().setNewPartent(rightHand);
        obj.transform.localPosition = ItemPositionInHand;
        obj.transform.localRotation= Quaternion.identity;
        itemInHand= obj;
        hasItemPickedUp = true;

    }

    public float GetPlayeSpeed()
    {
        return currSpeed;
    }

    public void Throw()
    {
        hasItemPickedUp = false;
        itemInHand.GetComponent<PickUpable>().Throw(currentRotation*7);
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

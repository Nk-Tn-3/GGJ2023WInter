using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public PlayerMovementNS.PlayerInput input { get; private set; }
    [SerializeField]private Animator animator;

    private AnimationController playerAnimationController;


    private Vector2 movementData;
    

    // Start is called before the first frame update
    void Awake()
    {
        input = GetComponent<PlayerMovementNS.PlayerInput>();
        playerAnimationController = new AnimationController();
        playerAnimationController.Initizalize(animator);
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
        movementData=input.playerActions.Movement.ReadValue<Vector2>();
        playerAnimationController.Update(movementData);
        
    }

    public void AnimationExitEvent()
    {

    }
    public void AnimationEnterEvent() {
    }


    
}

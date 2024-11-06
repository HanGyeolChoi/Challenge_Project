using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    private PlayerStats stats;
    private Vector2 curMovementInput;
    private Vector2 aimDirection;

    private bool aimOption = false;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        stats = CharacterManager.Instance.Player.stats;
    }

    private void FixedUpdate()
    {
        //Move();

        //if (aimOption)
        //{
        //    Aim();
        //}
    }

    //private void Move()
    //{
    //    _rigidbody.velocity = curMovementInput * stats.moveSpeed;
    //}

    //public void OnMoveInput(InputAction.CallbackContext context)
    //{
    //    if(context.phase == InputActionPhase.Performed)
    //    {
    //        curMovementInput = context.ReadValue<Vector2>();
    //    }

    //    if(context.phase == InputActionPhase.Canceled)
    //    {
    //        curMovementInput = Vector2.zero;
    //    }
    //}

    //private void Aim()
    //{
        
    //}

    //public void OnAimInput(InputAction.CallbackContext context)
    //{
    //    aimDirection = context.ReadValue<Vector2>();   
    //}
}

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private PlayerStats stats;
    private Vector2 curMovementInput;
    private Vector2 aimDirection;

    private bool aimOption = false;
    private Rigidbody2D _rigidbody;
    [SerializeField] private Image aimImage;
    [SerializeField] private GameObject cameraContainer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        stats = CharacterManager.Instance.Player.stats;
    }

    private void FixedUpdate()
    {
        Move();

        if (aimOption)
        {
            Aim();
        }
    }

    private void Move()
    {
        _rigidbody.velocity = curMovementInput * stats.moveSpeed;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    private void Aim()
    {
        aimImage.transform.position = aimDirection;
    }

    public void OnAimInput(InputAction.CallbackContext context)
    {
        aimDirection = context.ReadValue<Vector2>();
    }
}

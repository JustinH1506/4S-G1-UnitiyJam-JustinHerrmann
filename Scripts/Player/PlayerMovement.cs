using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    
    [SerializeField] float moveSpeed;
    
    [SerializeField] float jumpSpeed;
    
    [SerializeField] float inputX;

    [SerializeField] private bool isGrounded;

    [SerializeField] private LayerMask layerMask;
    
    private Rigidbody rb;
    
    private void Awake()
    {
        playerInput = new PlayerInput();
        
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerInput.Enable();

        playerInput.Player.Movement.performed += Move;
        playerInput.Player.Movement.canceled += Move;

        playerInput.Player.Jump.performed += Jump;
    }

    private void OnDisable()
    {
        playerInput.Disable();

        playerInput.Player.Movement.performed -= Move;
        playerInput.Player.Movement.canceled -= Move;
        
        playerInput.Player.Jump.performed -= Jump;

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(inputX * moveSpeed, rb.velocity.y, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }

    private void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }
    }
    
}

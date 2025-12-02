/*using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameInput _input;   // сгенерированный класс
    private Vector2 _moveInput;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody _rb;
    private bool _isGrounded = true;

    private void Awake()
    {
        _input = new GameInput();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _input.Gameplay.Enable();

        _input.Gameplay.Move.performed += OnMove;
        _input.Gameplay.Move.canceled  += OnMove;

        _input.Gameplay.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        _input.Gameplay.Move.performed -= OnMove;
        _input.Gameplay.Move.canceled  -= OnMove;
        _input.Gameplay.Jump.performed -= OnJump;

        _input.Gameplay.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(_moveInput.x, 0, _moveInput.y);
        Vector3 velocity = dir * moveSpeed;
        Vector3 newPos = _rb.position + velocity * Time.fixedDeltaTime;
        _rb.MovePosition(newPos);
    }

    private void OnCollisionEnter(Collision other)
    {
        _isGrounded = true;
    }
}
*/
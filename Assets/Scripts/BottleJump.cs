using UnityEngine;

public class BottleJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _doubleJumpForce = 3f; 
    [SerializeField] private float _fallMultiplier = 2.5f;
    [SerializeField] public float _lowJumpMultiplier = 2f;
    [SerializeField] private float _flipTorque = 10f;
    [SerializeField] private float _horizontalForce = 2f;

    private bool _isGrounded;
    private bool _canDoubleJump;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector3(_horizontalForce, _jumpForce, _rb.velocity.z);
            _rb.AddTorque(Vector3.forward * _flipTorque, ForceMode.Impulse);
            _canDoubleJump = true;
        }
        else if (_canDoubleJump)
        {
            _rb.velocity = new Vector3(_horizontalForce, _doubleJumpForce, _rb.velocity.z);
            _rb.AddTorque(Vector3.forward * _flipTorque, ForceMode.Impulse);
            _canDoubleJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Surface>(out _))
        {
            _isGrounded = true;
            _canDoubleJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Surface>(out _))
        {
            _isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector3.up * Physics.gravity.y * (_fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (_rb.velocity.y > 0 && Input.GetButton("Jump") == false)
        {
            _rb.velocity += Vector3.up * Physics.gravity.y * (_lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
}
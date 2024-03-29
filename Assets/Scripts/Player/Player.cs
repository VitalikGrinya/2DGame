using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    private const string Speed = "Speed";
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private GroundDetecter _groundChecker;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private bool _isFaceRight = true;
    private bool _isGrounded;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Reflect();
        AnimateMovement();
        Run();
        Jump();
    }

    private void OnEnable()
    {
        _groundChecker.IsGrounded += SetGround;
    }

    private void OnDisable()
    {
        _groundChecker.IsGrounded -= SetGround;
    }

    private void SetGround(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpPower);
    }

    private void Run()
    {
        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _rigidbody.velocity.y);
    }

    private void AnimateMovement()
    {
        _animator.SetFloat(Speed, Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    private void Reflect()
    {
        if (Input.GetAxis("Horizontal") > 0 && _isFaceRight == true)
        {
            var transformRotation = transform.localRotation;
            transformRotation.y = 0;
            transform.localRotation = transformRotation;

            _isFaceRight = !_isFaceRight;
        }

        if(Input.GetAxis("Horizontal") < 0 && _isFaceRight == false)
        {
            var transformRotation = transform.localRotation;
            transformRotation.y = 180;
            transform.localRotation = transformRotation;

            _isFaceRight = !_isFaceRight;
        }
    }
}